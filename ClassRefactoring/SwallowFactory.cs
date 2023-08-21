namespace DeveloperSample.ClassRefactoring
{
    public class SwallowFactory
    {
        public Swallow GetSwallow(SwallowType swallowType) => new Swallow(swallowType);
    }
}