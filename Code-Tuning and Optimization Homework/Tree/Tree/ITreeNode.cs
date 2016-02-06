using System.Collections.Generic;

namespace Tree
{
    public interface ITreeNode<T>
    {
        T Value { get; set; }

        IList<ITreeNode<T>> Children { get; set; }
    }
}