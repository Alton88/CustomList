using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CustomList
{
    public class CustomList<T> : IEnumerable<T> where T : IComparable
    {
        private T[] items;
        private int capacity;
        private int manyItems;
        public CustomList()
        {
            capacity = 5;
            items = new T[capacity];
            manyItems = 0;
        }
        public int Count
        {
            get { return manyItems; }
        }
        public void Add(T element)
        {
            try { 
                if (manyItems == items.Length) {
                    EnsureCapacity(manyItems * 2 + 1);
                }
                this.items[manyItems] = element;
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            ++manyItems;
        }
        private void EnsureCapacity(int minimumCapacity)
        {
            T[] biggerArray;

            if (items.Length < minimumCapacity)
            {
                biggerArray = new T[minimumCapacity];
                try { 
                    for (int i = 0; i < manyItems; ++i)
                    {
                        biggerArray[i] = items[i];
                    }
                }
                catch (Exception e) { Console.WriteLine(e.Message); }

                items = biggerArray;
            }
        }
        public bool Remove(T target)
        {
            bool foundTarget = false;

            try
            {
                for (int i = 0; i < manyItems; ++i)
                {
                    if (items[i].Equals(target))
                    {
                        foundTarget = true;                   
                    }
                    if (foundTarget)
                    {
                        items[i] = items[i + 1];
                    }
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

            if (foundTarget) { --manyItems; }
            return foundTarget;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < manyItems; ++i) {
                yield return items[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            string output = null;
            
            try { 
                for (int i = 0; i < manyItems; ++i)
                {   
                     output += items[i] + " ";         
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

            return output;
        }
        public static CustomList<T> operator +(CustomList<T> listOne, CustomList<T> listTwo)
        {
            CustomList<T> addedList = new CustomList<T>();
            foreach (T element in listOne)
            {
                addedList.Add(element);
            }
            foreach (T element in listTwo)
            {
                addedList.Add(element);
            }
            return addedList;
        }
        public static CustomList<T> operator -(CustomList<T> listOne, CustomList<T> listTwo)
        {
            foreach (T itemTwo in listTwo)
            {
                listOne.Remove(itemTwo);
            }
            return listOne;
        }
        public CustomList<T> Zipper(CustomList<T> listTwo){
            CustomList<T> zipperedList = new CustomList<T>();
            
            var listTwoItem = listTwo.GetEnumerator();
            
            try
            {
                foreach (T listOneItem in this)
                {           
                    if (listTwoItem.MoveNext()) {
                        zipperedList.Add(listOneItem);
                        zipperedList.Add(listTwoItem.Current); }
                    else {
                        if (listTwo.Count == 0) {
                            zipperedList.Add(listOneItem);
                        }
                        break;  
                    }
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message);  }
            return zipperedList;
        }
        public T ElementAt(int index)
        {
            return items[index];
        }
        public void Sort() 
        {
            int j;
            try
            {
                for (int i = 0; i < manyItems; i++)
                {
                    j = i - 1;
                    while (j >= 0 && items[j].CompareTo(items[j + 1]) > 0)
                    {
                        Swap(j);
                        j = j - 1;
                    }
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message);  }
        }  
        private void Swap(int index) {
            T holdFirstVariable = default(T);
            try
            {
                holdFirstVariable = items[index + 1];
                items[index + 1] = items[index];
                items[index] = holdFirstVariable;
            }         
            catch (Exception e) { Console.WriteLine(e.Message);  }
}
    }
}
