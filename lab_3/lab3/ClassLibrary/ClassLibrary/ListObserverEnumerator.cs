using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class ListObserverEnumerator<T> : IEnumerator<T>
    {
        private ObservableList<T> ol;
        private int idx;

        public ListObserverEnumerator(ObservableList<T> ol)
        {
            this.ol = ol;
            this.idx = -1;
        }

        bool IEnumerator.MoveNext()
        {
            this.idx++;
            if (this.ol.getList().Count <= this.idx)
            {
                return false;
            }
            else
                return true;
        }

        void IEnumerator.Reset()
        {
            idx = -1;
        }

        /*T IEnumerator<T>.Current
        {
            get{
                return ol[idx];
            }
            
        }*/

        void IDisposable.Dispose()
        {
        }

        object IEnumerator.Current
        {
            get { return ol[idx]; }
        }

        T IEnumerator<T>.Current
        {
            get { return ol[idx]; }
        }
    }
}
