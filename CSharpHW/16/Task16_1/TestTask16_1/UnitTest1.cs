using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task16_1;

namespace TestTask16_1
{
    [TestClass]
    public class UnitTest1
    {
        

        

        [TestMethod]
        public void TestingPeek()
        {
            MyQueue<int> queue = new MyQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            Assert.AreEqual(queue.Peek(), 1);
        }

         [TestMethod]
        public void TestingEnqueue()
        {

            MyQueue<int> queue = new MyQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            Assert.AreEqual(queue.Count, 4);
        }

        [TestMethod]
        public  void TestingDenqueue()
         {
             MyQueue<int> queue = new MyQueue<int>();
             queue.Enqueue(1);
             queue.Enqueue(2);
             queue.Enqueue(3);
             queue.Enqueue(4);
           Assert.AreEqual(queue.Dequeue(),1);

            Assert.AreEqual(queue.Count,3);
        }
        [TestMethod]
        public void TestingPeek2()
        {
            MyQueue<int> queue = new MyQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Dequeue();
            Assert.AreEqual(queue.Peek(), 2);
        }
        [TestMethod]
        public void TestingContaints()
        {
            MyQueue<int> queue = new MyQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            Assert.AreEqual(queue.Containts(1), true);
            Assert.AreEqual(queue.Containts(3), true);
            Assert.AreEqual(queue.Containts(4), true);
        }
        [TestMethod]
        public void TestingNotContaints()
        {

            MyQueue<int> queue = new MyQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            Assert.AreEqual(queue.Containts(5), false);
        }
        [TestMethod]
        public void TestingToArray()
        {

           // Assert.AreEqual(queue.ToArray() is  int[], true);
         //   Assert.IsInstanceOfType(queue.ToArray(),typeof(int[]));
        }

       
    }
}
