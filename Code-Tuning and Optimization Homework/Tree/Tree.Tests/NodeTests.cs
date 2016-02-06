using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tree.Tests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void TestCreateEmptyNode()
        {
            ITreeNode<int> node = new TreeNode<int>(5);
            Assert.AreEqual(node.Value, 5);
            Assert.IsNotNull(node.Children);
        }

        [TestMethod]
        public void TestCreateEmptyNodeWithObject()
        {
            ITreeNode<StringBuilder> node = new TreeNode<StringBuilder>();
            Assert.IsNull(node.Value);
        }

        [TestMethod]
        public void TestCreateNonEmptyNodeWithObject()
        {
            var stringBuilder = new StringBuilder();
            ITreeNode<StringBuilder> node =
                new TreeNode<StringBuilder>(stringBuilder);

            Assert.AreSame(stringBuilder, node.Value);
        }

        [TestMethod]
        public void TestCreateNonEmptyNodeWithCollection()
        {
            var collection = new LinkedList<int>();
            var node = new TreeNode<LinkedList<int>>(collection);

            Assert.AreSame(collection, node.Value);
        }
    }
}
