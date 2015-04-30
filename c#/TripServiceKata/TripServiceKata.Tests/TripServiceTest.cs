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
                var tripService = new TestableTripService() { LoggedInUser = NotLoggedInUser };

                Assert.That(() => tripService.GetTripsByUser(AnotherUser), Throws.TypeOf<UserNotLoggedInException>());
            }
        }

        [TestFixture]
        public class given_user_is_logged_in
        {
            User.User _user;
            User.User _anotherUser;
            List<Trip.Trip> _tripList;
            TripService tripService;

            [SetUp]
            public void SetUp()
            {
                _user = new User.User();
                _anotherUser = new User.User();
                _tripList = new List<Trip.Trip> {new Trip.Trip() };
                tripService = new TestableTripService() { LoggedInUser = _user, Trips = _tripList };
            }

            [Test]
            public void it_should_return_no_trips_if_users_are_not_friends()
            {
                Assert.That(tripService.GetTripsByUser(_anotherUser), Is.Empty);
            }

            [Test]
            public void it_should_return_list_of_trips_if_users_are_friends()
            {
                _anotherUser.AddFriend(_user);

                Assert.That(tripService.GetTripsByUser(_anotherUser), Is.EqualTo(_tripList));
            }
        }

        public class TestableTripService : TripService
        {
            public User.User LoggedInUser { get; set; }

            public List<Trip.Trip> Trips { get; set; }

            protected override User.User GetLoggedInUser()
            {
                return LoggedInUser;
            }

            protected override List<Trip.Trip> FindTripsByUser(User.User user)
            {
                return Trips;
            }
        }
    }
}
