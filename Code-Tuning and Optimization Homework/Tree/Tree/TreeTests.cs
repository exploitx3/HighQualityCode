using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tree
{
    [TestClass]
    public class TreeTests
    {
        [TestMethod]
        public void CreateEmptyTree()
        {
            ITree<int> tree = new Tree<int>(6);
            Assert.AreEqual(6, tree.Root.Value);
        }
    }
}