using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;

namespace TestyJednostkowe
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void addAndRemoveListeners()
        {
            ObservableList<String> o = new ObservableList<String>();

            o += event1;
            o.Add("czesc");
            o -= event1;
            o += event2;
            o.Add("czesc2");
        }

        [TestMethod]
        public void indekser()
        {
            ObservableList<String> o = new ObservableList<String>();

            o.Add("element0");
            o.Add("element1");

            String el = o[0];
            String el1 = o[1];

            Assert.AreEqual("element0".ToString(),el.ToString());
            Assert.AreEqual("element1".ToString(),el1.ToString());

            String el2 = null;
            
            try
            {
                el2 = o[2];
            }
            catch (IndexOutOfRangeException e) {
                Assert.IsNull(el2);
            }
            catch (Exception)
            {
                Assert.Fail();
            }

            try
            {
               el2 = o[-1];
            }
            catch (IndexOutOfRangeException e) {
                Assert.IsNull(el2);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        void event1(object sender, ListObserverArgs<string> observer)
        {
            Assert.AreEqual(0, observer.index);
            Console.WriteLine("Event 1");
        }

        void event2(object sender, ListObserverArgs<string> observer)
        {
            Assert.AreEqual(1, observer.index);
            Console.WriteLine("Event 2");
        }

        [TestMethod]
        public void foreachTest()
        {
            ObservableList<String> o = new ObservableList<String>();

            for (int j = 0; j < 10; j++)
            {
                o.Add("Obiekt" + j);
            }

            int k=0;

            foreach (String el in o)
            {
                Assert.AreEqual(("Obiekt" + k).ToString(), el.ToString());
                k++;
            }
        }

    }
}
