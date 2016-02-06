namespace Tree
{
    public class Tree<T> : ITree<T>
    {
        public Tree(T value)
        {
            this.Root = new TreeNode<T>(value);
        }
        public ITreeNode<T> Root { get; set; }
    }
}