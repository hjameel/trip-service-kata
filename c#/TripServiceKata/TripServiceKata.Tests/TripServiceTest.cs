using NUnit.Framework;
using TripServiceKata.Exception;
using TripServiceKata.Trip;

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
				var tripService = new TestableTripService() { LoggedInUser = NotLoggedInUser };

				Assert.That(() => tripService.GetTripsByUser(AnotherUser), Throws.TypeOf<UserNotLoggedInException>());
			}
		}

		[TestFixture]
		public class given_user_is_logged_in
		{
			[Test]
			public void it_should_return_no_trips_if_users_are_not_friends()
			{
				var user = new User.User();
				var friend = new User.User();
				var tripService = new TestableTripService() { LoggedInUser = user };

				Assert.That(tripService.GetTripsByUser(friend), Is.Empty);
			}
		}

		private const User.User NotLoggedInUser = null;
		private const User.User AnotherUser = null;

		public class TestableTripService : TripService
		{
			public User.User LoggedInUser { get; set; }

			protected override User.User GetLoggedInUser()
			{
				return LoggedInUser;
			}
		}
	}
}
