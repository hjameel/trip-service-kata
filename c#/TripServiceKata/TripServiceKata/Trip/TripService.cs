using System.Collections.Generic;
using TripServiceKata.Exception;
using TripServiceKata.User;

namespace TripServiceKata.Trip
{
    public class TripService
    {
        private readonly ITripDAO _tripDao;

        public TripService(ITripDAO tripDao)
        {
            _tripDao = tripDao;
        }

        public List<Trip> GetFriendsTrips(User.User friend, User.User loggedInUser)
        {
            CheckThatUserIsLoggedIn(loggedInUser);

            return friend.IsFriendsWith(loggedInUser) ? _tripDao.FindUsersTrips(friend) : NoTrips();
        }

        private void CheckThatUserIsLoggedIn(User.User loggedInUser)
        {
            if (loggedInUser == null)
            {
                throw new UserNotLoggedInException();
            }
        }

        private List<Trip> NoTrips()
        {
            return new List<Trip>();
        }
    }
}
