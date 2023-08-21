using System;

namespace DeveloperSample.ClassRefactoring
{

    public class Swallow
    {
        public SwallowType Type { get; }
        public SwallowLoad Load { get; private set; }

        public Swallow(SwallowType swallowType)
        {
            Type = swallowType;
            Load = SwallowLoad.None;
        }

        public void ApplyLoad(SwallowLoad load)
        {
            Load = load;
            if(Load == null)
                Load = SwallowLoad.None;
        }

        public double GetAirspeedVelocity()
        {
            return Type.BaseSpeed - Load.BaseSpeedReduction;
        }
    }
}