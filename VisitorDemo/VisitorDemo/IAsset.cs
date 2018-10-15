namespace VisitorDemo
{
    public interface IAsset
    {
        void Accept(IVisitor visitor);
    }
}