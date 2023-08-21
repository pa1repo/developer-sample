namespace DeveloperSample.ClassRefactoring
{
    public class SwallowLoad
    {
        public static readonly SwallowLoad None = new SwallowLoad(0);
        public static readonly SwallowLoad Coconut = new SwallowLoad(4);
        public SwallowLoad(int baseSpeedReduction)
        {
            BaseSpeedReduction = baseSpeedReduction;
        }

        public int BaseSpeedReduction { get; }
    }
}