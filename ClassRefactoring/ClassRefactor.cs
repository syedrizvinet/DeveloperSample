using System;

namespace DeveloperSample.ClassRefactoring
{
    public enum SwallowType
    {
        African, European
    }

    public enum SwallowLoad
    {
        None, Coconut
    }

    public abstract class SwallowFactory
    {
        public abstract Swallow GetSwallow();
    }

    public class AfricanSwallowFactory : SwallowFactory
    {
        public override Swallow GetSwallow()
        {
            return new Swallow(SwallowType.African);
        }
    }

    public class EuropeanSwallowFactory : SwallowFactory
    {
        public override Swallow GetSwallow()
        {
            return new Swallow(SwallowType.European);
        }
    }

    public class Swallow
    {
        public SwallowType Type { get; }
        public SwallowLoad Load { get; private set; }

        public Swallow(SwallowType swallowType)
        {
            Type = swallowType;
        }

        public void ApplyLoad(SwallowLoad load)
        {
            Load = load;
        }

        public double GetAirspeedVelocity()
        {
            if (Type == SwallowType.African && Load == SwallowLoad.None)
            {
                return 22;
            }
            if (Type == SwallowType.African && Load == SwallowLoad.Coconut)
            {
                return 18;
            }
            if (Type == SwallowType.European && Load == SwallowLoad.None)
            {
                return 20;
            }
            if (Type == SwallowType.European && Load == SwallowLoad.Coconut)
            {
                return 16;
            }
            throw new InvalidOperationException();
        }
    }
}