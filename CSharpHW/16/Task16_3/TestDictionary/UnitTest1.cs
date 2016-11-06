using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using  Task16_3;

namespace TestDictionary
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAdd()
        {
          var myDictionary= new MyDictionary<int, string>(5);
            myDictionary.Add(1,"value1");
            myDictionary.Add(2,"value2");
            Assert.AreEqual(myDictionary[1], "value1");
            Assert.AreEqual(myDictionary[2], "value2");
        }
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException),
         "Key does not exist in the dictionary")]
        public void TestRemove()
        {
            var myDictionary = new MyDictionary<int, string>(5);
            myDictionary.Add(1, "value1");
            myDictionary.Add(2, "value2");
            myDictionary.Remove(2);
            myDictionary.GetValue(2);
        }
    }
}
