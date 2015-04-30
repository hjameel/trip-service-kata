using System.Collections.Generic;
using TripServiceKata.Exception;
using TripServiceKata.User;

namespace TripServiceKata.Trip
{
    public class TripService
    {
        public List<Trip> GetTripsByUser(User.User user)
        {
            if (GetLoggedInUser() == null)
            {
                throw new UserNotLoggedInException();
            }
            return UserIsFriendsWith(GetLoggedInUser(), user)
                ? FindTripsByUser(user) : new List<Trip>();
        }

        bool UserIsFriendsWith(User.User loggedInUser, User.User otherUser)
        {
            return otherUser.GetFriends().Contains(loggedInUser);
        }

        protected virtual TripServiceKata.User.User GetLoggedInUser()
        {
            return UserSession.GetInstance().GetLoggedUser();
        }

        protected virtual List<Trip> FindTripsByUser(TripServiceKata.User.User user)
        {
            return TripDAO.FindTripsByUser(user);
        }
    }
}
