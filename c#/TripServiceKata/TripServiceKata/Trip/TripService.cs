using System.Collections.Generic;
using TripServiceKata.Exception;
using TripServiceKata.User;

namespace TripServiceKata.Trip
{
    public class TripService
    {
        private readonly IUserSession _userSession;

        public TripService(IUserSession userSession)
        {
            _userSession = userSession;
        }

        public List<Trip> GetTripsByUser(User.User user)
        {
            if (_userSession.GetLoggedInUser() == null)
            {
                throw new UserNotLoggedInException();
            }
            return user.IsFriendsWith(_userSession.GetLoggedInUser())
                ? FindTripsByUser(user) : new List<Trip>();
        }

        protected virtual List<Trip> FindTripsByUser(TripServiceKata.User.User user)
        {
            return TripDAO.FindTripsByUser(user);
        }
    }
}
