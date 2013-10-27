using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;

namespace TestyJednostkowe
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ObservableList<String> o = new ObservableList<String>();

            o.Added += o_Added;

            o.Add("czesc");
        }

        void o_Added(object sender, ListObserverArgs<string> observer)
        {
            throw new NotImplementedException();
        }

    }
}
