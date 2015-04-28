using NUnit.Framework;
using TripServiceKata.Trip;
using TripServiceKata.Exception;

namespace TripServiceKata.Tests
{
	public class when_get_trips_by_user_is_called
	{
		[TestFixture]
	    public class given_no_user_logged_in
	    {
			[Test]
			public void it_should_throw_a_user_not_logged_on_exception()
			{
				Assert.That(() => new TestableTripService().GetTripsByUser(null), Throws.TypeOf<UserNotLoggedInException>());
			}
	    }
	}

	public class TestableTripService : TripService
	{
		protected override TripServiceKata.User.User GetLoggedUser()
		{
			return null;
		}
	}
}
