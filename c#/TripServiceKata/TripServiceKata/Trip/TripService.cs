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
            return user.IsFriendsWith(GetLoggedInUser())
                ? FindTripsByUser(user) : new List<Trip>();
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
