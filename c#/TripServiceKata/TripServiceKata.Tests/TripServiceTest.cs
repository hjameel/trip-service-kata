using NUnit.Framework;
using TripServiceKata.Exception;
using TripServiceKata.Trip;
using System.Collections.Generic;

namespace TripServiceKata.Tests
{
    public class when_get_trips_by_user_is_called
    {
        [TestFixture]
        public class given_no_user_logged_in
        {
            private const User.User NotLoggedInUser = null;
            private const User.User AnotherUser = null;

            [Test]
            public void it_should_throw_a_user_not_logged_on_exception()
            {
                var tripService = new TripService(new StubTripDao());

                Assert.That(() => tripService.GetFriendsTrips(AnotherUser, NotLoggedInUser), Throws.TypeOf<UserNotLoggedInException>());
            }
        }

        [TestFixture]
        public class given_user_is_logged_in
        {
            User.User _user;
            User.User _anotherUser;
            List<Trip.Trip> _tripList;
            TripService _tripService;

            [SetUp]
            public void SetUp()
            {
                _user = new User.User();
                _anotherUser = new User.User();
                _tripList = new List<Trip.Trip> { new Trip.Trip() };
                _tripService = new TripService(new StubTripDao() { Trips = _tripList });
            }

            [Test]
            public void it_should_return_no_trips_if_users_are_not_friends()
            {
                Assert.That(_tripService.GetFriendsTrips(_anotherUser, _user), Is.Empty);
            }

            [Test]
            public void it_should_return_list_of_trips_if_users_are_friends()
            {
                _anotherUser.AddFriend(_user);

                Assert.That(_tripService.GetFriendsTrips(_anotherUser, _user), Is.EqualTo(_tripList));
            }
        }

        public class StubTripDao : ITripDAO
        {
            public List<Trip.Trip> Trips { get; set; }

            public List<Trip.Trip> FindUsersTrips(TripServiceKata.User.User user)
            {
                return Trips;
            }
        }
    }
}
