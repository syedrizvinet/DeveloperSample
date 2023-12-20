using Xunit;

namespace DeveloperSample.ClassRefactoring
{
    public class ClassRefactorTest
    {
        [Fact]
        public void AfricanSwallowHasCorrectSpeed()
        {
            var swallowFactory = new AfricanSwallowFactory();
            var swallow = swallowFactory.GetSwallow();
            Assert.Equal(22, swallow.GetAirspeedVelocity());
        }

        [Fact]
        public void LadenAfricanSwallowHasCorrectSpeed()
        {
            var swallowFactory = new AfricanSwallowFactory();
            var swallow = swallowFactory.GetSwallow();
            swallow.ApplyLoad(SwallowLoad.Coconut);
            Assert.Equal(18, swallow.GetAirspeedVelocity());
        }

        [Fact]
        public void EuropeanSwallowHasCorrectSpeed()
        {
            var swallowFactory = new EuropeanSwallowFactory();
            var swallow = swallowFactory.GetSwallow();
            Assert.Equal(20, swallow.GetAirspeedVelocity());
        }

        [Fact]
        public void LadenEuropeanSwallowHasCorrectSpeed()
        {
            var swallowFactory = new EuropeanSwallowFactory();
            var swallow = swallowFactory.GetSwallow();
            swallow.ApplyLoad(SwallowLoad.Coconut);
            Assert.Equal(16, swallow.GetAirspeedVelocity());
        }
    }
}