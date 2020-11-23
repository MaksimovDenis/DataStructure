using NUnit.Framework;
using DataStructures;
using DataStructuresConsole;

namespace DataStructureTest
{
    public class ArrayListTEST
    {

        //Пункт 1
        [TestCase(3, new int[] { 3 })]
        [TestCase(0, new int[] { 0 })]
        [TestCase(4, new int[] { 4 })]
        public void AddTest(int value, int[] expArray)
        {
            ArrayList actual = new ArrayList();
            ArrayList expected = new ArrayList(expArray);

            actual.Add(value);

            Assert.AreEqual(expected, actual);
        }

        //Пункт 2
        [TestCase(3, new int[] { 3, 4, 5 }, new int[] { 3, 3, 4, 5 })]
        [TestCase(56, new int[] { 3, 4, 5 }, new int[] { 56, 3, 4, 5 })]
        [TestCase(23, new int[] { 3 }, new int[] { 23, 3 })]
        public void AddByFirstTest(int value, int[] array, int[] expArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expArray);

            actual.AddByFirst(value);

            Assert.AreEqual(expected, actual);
        }

        //Пункт 3
        [TestCase(2, 4, new int[] { 0, 3 }, new int[] { 0, 3, 4 })]
        [TestCase(3, 5, new int[] { 0, 3, 1 }, new int[] { 0, 3, 1, 5 })]
        [TestCase(0, 4, new int[] { 0, 3 }, new int[] { 4, 0, 3 })]
        public void AddByIndexTest(int value, int j, int[] array, int[] expArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expArray);

            actual.AddElementByIndex(value, j);

            Assert.AreEqual(expected, actual);
        }

        //Пункт 4
        [TestCase(new int[] { 0, 3, 2, 4 }, new int[] { 0, 3, 2 })]
        [TestCase(new int[] { 0, 3 }, new int[] { 0 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        public void DeleteLastElementTest(int[] array, int[] expArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expArray);

            actual.DeleteLastElement();

            Assert.AreEqual(expected, actual);
        }

        //Пункт 5
        [TestCase(new int[] { 0 }, new int[] { })]
        [TestCase(new int[] { 0, 3 }, new int[] { 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
        public void DeleteFirstElementTest(int[] array, int[] expArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expArray);

            actual.DeleteFirstElement();

            Assert.AreEqual(expected, actual);
        }

        //Пункт 6
        [TestCase(2, new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        [TestCase(0, new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [TestCase(0, new int[] { }, new int[] { })]
        public void RemoveAtTest(int value, int[] array, int[] expArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expArray);

            actual.RemoveAt(value);

            Assert.AreEqual(expected, actual);
        }

        //Пункт 8
        [TestCase(new int[] { 1, 2, 3, 4 }, 1, 1)]
        [TestCase(new int[] { 5, 3, 3 }, 2, 3)]
        [TestCase(new int[] { -23, 434, 43 }, 2, 434)]
        public void FindeValueByIndexTest(int[] array, int index, int expected)
        {
            ArrayList MyList = new ArrayList(array);
            int actual = MyList.FindeValueByIndex(index);
            Assert.AreEqual(expected, actual);
        }

        //Пункт 9
        [TestCase(new int[] { 1, 2, 3, 4 }, 1, 1)]
        [TestCase(new int[] { 5, 3, 3 }, 3, 3)]
        [TestCase(new int[] { -23, 434, 43 }, 434, 2)]
        public void FindeIndexByValueTest(int[] array, int value, int expected)
        {
            ArrayList MyList = new ArrayList(array);
            int actual = MyList.FindeIndexByValue(value);
            Assert.AreEqual(expected, actual);
        }


        //Пункт 11
        [TestCase(new int[] { 3, 2, 1 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 0 }, new int[] { 0 })]
        [TestCase(new int[] { }, new int[] { })]
        public void ReverseTest(int[] array, int[] expArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expArray);

            actual.Reverse();

            Assert.AreEqual(expected, actual);
        }

        //Пункт 12
        [TestCase(new int[] { 3, 2, 1 }, 3)]
        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { -23, -343, -1 }, -1)]
        public void FindMaxTests(int[] array, int expected)
        {

            ArrayList actual = new ArrayList(array);

            Assert.AreEqual(expected, actual.FindMaxElement());
        }

        //Пункт 13
        [TestCase(new int[] { 3, 2, 1 }, 1)]
        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { -23, -343, -1 }, -343)]
        public void FindMinTests(int[] array, int expected)
        {

            ArrayList actual = new ArrayList(array);

            Assert.AreEqual(expected, actual.FindMinElement());
        }

        //Пункт 14
        [TestCase(new int[] { 3, 2, 1 }, 1)]
        [TestCase(new int[] { 0 }, 1)]
        [TestCase(new int[] { -23, -343, -1 }, 3)]
        public void FindMaxIndexOfElementTest(int[] array, int expected)
        {

            ArrayList actual = new ArrayList(array);

            Assert.AreEqual(expected, actual.FindMaxIndexOfElement());
        }

        //Пункт 15
        [TestCase(new int[] { 3, 2, 1 }, 3)]
        [TestCase(new int[] { 0 }, 1)]
        [TestCase(new int[] { -23, -343, -1 }, 2)]
        public void FindMinIndexOfElementTest(int[] array, int expected)
        {

            ArrayList actual = new ArrayList(array);

            Assert.AreEqual(expected, actual.FindMinIndexOfElement());
        }

        //Пункт 16
        [TestCase(new int[] { 1, 2, 1 }, new int[] { 1, 1, 2 })]
        [TestCase(new int[] { 0 }, new int[] { 0 })]
        [TestCase(new int[] { -43, -12, -343 }, new int[] { -343, -43, -12 })]
        [TestCase(new int[] { }, new int[] { })]
        public void SortMinToMaxTest(int[] array, int[] expArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expArray);

            actual.SortMinToMax();

            Assert.AreEqual(expected, actual);
        }

        //Пункт 17
        [TestCase(new int[] { 1, 2, 1 }, new int[] { 2, 1, 1 })]
        [TestCase(new int[] { 0 }, new int[] { 0 })]
        [TestCase(new int[] { -43, -12, -343 }, new int[] { -12, -43, -343 })]
        [TestCase(new int[] { }, new int[] { })]
        public void SortMaxToMinTest(int[] array, int[] expArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expArray);

            actual.SortMaxToMin();

            Assert.AreEqual(expected, actual);
        }

        //Пункт 19
        [TestCase(new int[] { 1, 2, 1 }, 2, new int[] { 1, 1 })]
        [TestCase(new int[] { 0 }, 0, new int[] { })]
        [TestCase(new int[] { -43, -12, -343, -343 }, -343, new int[] { -43, -12 })]
        public void RemoveAllTest(int[] array, int value, int[] expArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expArray);

            actual.RemoveAll(value);

            Assert.AreEqual(expected, actual);
        }

        //Пункт 21
        [TestCase(new int[] { 1, 2, 1 }, new int[] { 0, 34, 53 }, new int[] { 1, 2, 1, 0, 34, 53 })]
        [TestCase(new int[] { }, new int[] { 0, 34, 53 }, new int[] { 0, 34, 53 })]
        [TestCase(new int[] { 0, 34, 321 }, new int[] { 0 }, new int[] { 0, 34, 321, 0 })]
        public void AddRangeTest(int[] array, int[] AddArray, int[] expArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expArray);

            actual.AddRange(AddArray);

            Assert.AreEqual(expected, actual);
        }

        //Пункт 22
        [TestCase(new int[] { 1, 2, 1 }, new int[] { 0, 34, 53 }, new int[] { 0, 34, 53, 1, 2, 1 })]
        [TestCase(new int[] { }, new int[] { 0, 34, 53 }, new int[] { 0, 34, 53 })]
        [TestCase(new int[] { 0, 34, 321 }, new int[] { 0 }, new int[] { 0, 0, 34, 321 })]
        public void AddRangeByFirstTest(int[] array, int[] AddArray, int[] expArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expArray);

            actual.AddRangeByFirst(AddArray);

            Assert.AreEqual(expected, actual);
        }

        //Пункт 23
        [TestCase(new int[] { 1, 2, 1 }, 2, new int[] { 0, 34, 53 }, new int[] { 1, 2, 0, 34, 53, 1 })]
        [TestCase(new int[] { 1, 2, 1 }, 3, new int[] { 0, 34, 53 }, new int[] { 1, 2, 1, 0, 34, 53 })]

        public void AddRagneByIndexTest(int[] array, int index, int[] AddArray, int[] expArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expArray);

            actual.AddRagneByIndex(index, AddArray);

            Assert.AreEqual(expected, actual);
        }

        //Пункт 25
        [TestCase(new int[] { 3, 0, -23, 31, 54, 32 }, 3, new int[] { 31, 54, 32 })]
        [TestCase(new int[] {25, 32, 124, 54}, 2, new int[] {124,54 })]


        public void DeleteByFirstTest(int[] array, int value, int[] expArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expArray);

            actual.DeleteByFirst(value);

            Assert.AreEqual(expected, actual);
        }

        //Пункт 26
        [TestCase(new int[] { 3, 0, -23, 31, 54, 32 }, 3,2, new int[] { 3, 31,54,32 })]
        [TestCase(new int[] { 3, 0, -23, 31, 54, 32 }, 1,1, new int[] { 0, -23, 31, 54, 32 })]
        [TestCase(new int[] { 3, 0, -23, 31, 54, 32 }, 1,0, new int[] { 3, 0, -23, 31, 54, 32 })]

        public void DeleteElementByIndexTest(int[] array, int value, int index, int[] expArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expArray);

            actual.DeleteElementByIndex(value, index);

            Assert.AreEqual(expected, actual);
        }
    }
}