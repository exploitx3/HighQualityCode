using System;

namespace CustomLinkedList.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CustomLinkedListTest
    {
        DynamicList<int> linkedList;

        [TestInitialize()]
        public void LinkedListInitialize()
        {
            linkedList = new DynamicList<int>();
        }

        [TestMethod]
        public void TestCount_WrongCount()
        {
            linkedList.Add(5);
            linkedList.Add(6);
            linkedList.Add(7);

            Assert.AreEqual(3, linkedList.Count, "The count function of the linked list doesn't right.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIndexer_Get_NegativeIndex()
        {
           

            int testVar = linkedList[-4];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIndexer_Get_IndexBiggerThanCount()
        {
           

            linkedList.Add(3);

            int testVar = linkedList[6];
        }

        [TestMethod]
        public void TestIndexer_Get_InvalidReturnValue()
        {
           

            linkedList.Add(4);
            linkedList.Add(5);

            Assert.AreEqual(5, linkedList[1], "The indexer's returned value is invalid");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIndexer_Set_NegativeIndex()
        {
           

            linkedList[-5] = 34;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIndexer_Set_IndexBiggerThanCount()
        {
           

            linkedList.Add(3);

            linkedList[4] = 5;
        }

        [TestMethod]
        public void TestIndexer_Set_InvalidSetValue()
        {
           

            linkedList.Add(4);
            linkedList.Add(5);

            linkedList[0] = 45;

            Assert.AreEqual(45, linkedList[0], "The linked list's set function isn't working correctly.");
        }

        [TestMethod]
        public void TestAdd_CannotAddElement()
        {
           

            linkedList.Add(34);


            Assert.AreEqual(34, linkedList[0], "The element has not been added.");
            Assert.AreEqual(1, linkedList.Count, "The count has not been incremented after adding an element.");
        }

        [TestMethod]
        public void TestRemove_ElementHasNotBennRemoved()
        {
            const int ElementToBeRemoved = 4;

           
            linkedList.Add(4);
            linkedList.Add(55);
            linkedList.Add(34);

            int indexOfRemovedElement = linkedList.Remove(ElementToBeRemoved);
            
            Assert.AreEqual(0 , indexOfRemovedElement, "The element " + ElementToBeRemoved + " has not been removed");
            Assert.AreEqual(2, linkedList.Count, "The count has not been decremented after removal");
        }

        [TestMethod]
        public void TestRemoveAt_ElementHasNotBennRemoved()
        {
            const int IndexOfElementToBeRemoved = 2;

           
            linkedList.Add(4);
            linkedList.Add(55);
            linkedList.Add(34);

            int elementAtRemovedIndex = linkedList.RemoveAt(IndexOfElementToBeRemoved);
            
            Assert.AreEqual(34 , elementAtRemovedIndex, "The element with index " + IndexOfElementToBeRemoved + " has not been removed");
            Assert.AreEqual(2, linkedList.Count, "The count has not been decremented after removal");
        }

        [TestMethod]
        public void TestIndexOf_IncorrectIndexOfElement()
        {
            const int IndexOfElement = 1;

           
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.Add(4);

            int returnedIndex = linkedList.IndexOf(IndexOfElement);

            Assert.AreEqual(0, returnedIndex, "Invalid index was found");
            Assert.AreNotEqual(-1, returnedIndex, "The searched element was not found, despite it was in the linked list");
        }

        [TestMethod]
        public void TestContains_ShouldNotReturnInvalidValue()
        {
            const int ElementToBeSearched = 4;

           
            linkedList.Add(4);
            linkedList.Add(55);
            linkedList.Add(34);

            bool containsElement = linkedList.Contains(ElementToBeSearched);

            Assert.IsTrue(containsElement, "The element " + ElementToBeSearched + " has not been found, despite it was in the linked list");
        }
    }
}
