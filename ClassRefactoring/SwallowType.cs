namespace DeveloperSample.ClassRefactoring
{
    public class SwallowType
    {

        public static readonly SwallowType African = new SwallowType(22);
        public static readonly SwallowType European = new SwallowType(20);
        public SwallowType(double baseSpeed)
        {
            BaseSpeed = baseSpeed;
        }
        public double BaseSpeed { get; }
    }
}