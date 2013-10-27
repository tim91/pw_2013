using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ObservableList <T> : IEnumerable<T>
    {
        public delegate void ListObserver<T>(object sender, ListObserverArgs<T> observer);
        private event ListObserver<T> ListEvent; 

        private List<T> list = new List<T>();

        public List<T> getList()
        {
            return this.list;
        }

        public void Add(T el)
        {
            this.list.Add(el);
            ListObserverArgs<T> loa = new ListObserverArgs<T>();
            loa.index = this.list.IndexOf(el);
            loa.value = el;
            if (ListEvent != null)
            {
                ListEvent(this, loa);
            }
            
        }

        public void Move(int from, int to)
        {
            T el = this.list.ElementAt(from);
            this.list.RemoveAt(from);
            this.list.Insert(to, el);
            ListObserverArgs<T> loa = new ListObserverArgs<T>();
            loa.index = to;
            loa.value = el;
            if (ListEvent != null)
            {
                ListEvent(this, loa);
            }
        }

        public void Remove(T el)
        {
            this.list.Remove(el);

            ListObserverArgs<T> loa = new ListObserverArgs<T>();
            loa.index = -1;
            loa.value = el;
            if (ListEvent != null)
            {
                ListEvent(this, loa);
            }
        }

        public T this[int i]
        {
           get
           {
               if (this.list.Count <= i || i < 0)
                   throw new IndexOutOfRangeException();
               return  this.list.ElementAt(i);
           }
        }

        public static ObservableList<T> operator +(ObservableList<T> list, ListObserver<T> obj)
        {
            list.ListEvent += obj;
            return list;
        }

        public static ObservableList<T> operator -(ObservableList<T> list, ListObserver<T> obj)
        {
            list.ListEvent -= obj;
            return list;
        }

        //indekser - czyli teraz do elementow moge odwolac sie przy pomocy ObservableList[1]
        //jezeli podamy za duzy indeks to ma rzucac wyjatak indexaoutofrangeexception
    
        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            return new ListObserverEnumerator<T>(this);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new ListObserverEnumerator<T>(this);
        }
    }
}
