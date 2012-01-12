namespace HelloWorld.Sass
{
    public class SassController
    {
        public SassOut Sass(SassIn sassIn)
        {
            return new SassOut();
        }
    }

    public class SassIn { }
    public class SassOut { }
}