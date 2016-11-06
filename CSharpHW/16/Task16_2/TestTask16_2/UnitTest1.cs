using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task16_2;

namespace TestTask16_2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPush()
        {
           var stack = new MyStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Assert.AreEqual(stack.Count,3);
            Assert.AreEqual(stack.Peek(),3);
        }
        [TestMethod]
        public void TestPop()
        {
            var stack = new MyStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Assert.AreEqual(stack.Pop(),3);
            Assert.AreEqual(stack.Count,2);
          
            Assert.AreEqual(stack.Pop(),2);
            Assert.AreEqual(stack.Count, 1);
        }

        [TestMethod]
        public void TestPeek()
        {
            var stack = new MyStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Assert.AreEqual(stack.Peek(), 3);
            stack.Pop();
            Assert.AreEqual(stack.Peek(), 2);
        }
    }
}
