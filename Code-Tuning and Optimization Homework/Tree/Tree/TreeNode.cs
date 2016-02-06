using System.Collections.Generic;

namespace Tree
{
    public class TreeNode<T> : ITreeNode<T>
    {
        public TreeNode()
            : this(default(T))
        {
        }
        public TreeNode(T value)
        {
            this.Value = value;
            this.Children = new List<ITreeNode<T>>();
        }
        public T Value { get; set; }
        public IList<ITreeNode<T>> Children { get; set; }
    }
}