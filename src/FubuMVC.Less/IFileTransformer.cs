namespace FubuMVC.Less
{
    public interface IFileTransformer
    {
        bool CanTransform(string name);
        string Transform(string name, string content);
    }
}
