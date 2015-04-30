using System.Collections.Generic;
using TripServiceKata.Exception;

namespace TripServiceKata.Trip
{
    public interface ITripDAO
    {
        List<Trip> FindUsersTrips(TripServiceKata.User.User user);
    }

    public class TripDAO :ITripDAO
    {
        public static List<Trip> FindTripsByUser(User.User user)
        {
            throw new DependendClassCallDuringUnitTestException(
                        "TripDAO should not be invoked on an unit test.");
        }

        public List<Trip> FindUsersTrips(TripServiceKata.User.User user)
        {
            return FindTripsByUser(user);
        }
    }
}
