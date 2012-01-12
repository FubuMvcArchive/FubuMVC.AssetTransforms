namespace HelloWorld.Less
{
    public class LessController
    {
        public LessOut Less(LessIn lessIn)
        {
            return new LessOut();
        }
    }

    public class LessIn {}
    public class LessOut { }
}