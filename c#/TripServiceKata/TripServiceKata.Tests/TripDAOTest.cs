using NUnit.Framework;
using System;
using TripServiceKata.Exception;

namespace TripServiceKata.Tests
{
    [TestFixture]
    public class TripDAOTest
    {
        [Test]
        public void should_throw_an_exception_when_trying_to_find_trips()
        {
            Assert.That(() => new Trip.TripDAO().FindUsersTrips(new User.User()),
                        Throws.TypeOf<DependendClassCallDuringUnitTestException>());
        }
    }
}

