using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLab
{
    public class Queue<T>
    {
        private Node<T> first;
        private Node<T> last;

        public Queue()
        {
            this.first = null;
            this.last = null;
        }
        public void Insert(T value)
        {
            Node<T> newNode = new Node<T>(value);
            if (this.first == null)
                this.first = newNode;
            else
                this.last.SetNext(newNode);
            this.last = newNode;
        }
        public T Remove()
        {
            T value = this.first.GetValue();
            this.first = this.first.GetNext();
            if (this.first == null)
                this.last = null;
            return value;
        }
        public T Head()
        {
            return this.first.GetValue();
        }

        public bool IsEmpty()
        {
            return this.first == null;
        }
        public int GetQLength()
        {//בפונקציה זו נחשב את אורך התור
         //מותר להשתמש בה, רק כאשר האפשרות צויינה בשאלה
            int count = 0;
            Node<T> current = this.first;
            while (current != null)
            {
                count++;
                current = current.GetNext();
            }
            return count;
        }

        public override string ToString()
        {
            return "H[" + this.first;
        }
    }
}
