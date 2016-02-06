namespace Tree
{
    public interface ITree<T>
    {
        ITreeNode<T> Root { get; set; }

    }
}