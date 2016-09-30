using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList<int> myList = new CustomList<int>();
            CustomList<int> myOtherList = new CustomList<int>();
            myList.Add(4);
            myList.Add(5);
            myList.Add(3);
            myList.Add(8);
            myList.Add(7);
            myList.Add(6);
            myList.Add(2);
            myList.Add(1);
            myList.Remove(8);
            myList.Remove(7);
            myList.Remove(6);

            myOtherList.Add(1);
            myOtherList.Add(2);
            myOtherList.Add(3);
            myOtherList.Add(4);
            myOtherList.Add(5);
            myOtherList.Add(6);
            myOtherList.Add(7);
            myOtherList.Add(8);
            //myOtherList.Remove(7);
            //myOtherList.Remove(8);
            //myOtherList.Remove(6);
            //Console.WriteLine(myOtherList);
            //myList.ToString();
            //foreach (object o in myList)
            //{
            //    Console.WriteLine(o);
            //}
            //CustomList<int> addTwoList = myList + myOtherList;
            //Console.WriteLine(addTwoList);
            //CustomList<int> subtractCopiesFromList = myList - myOtherList;
            //Console.WriteLine(subtractCopiesFromList);
            //Console.WriteLine(myList);
            //myList.Sort();
            Console.WriteLine("Zipper Output: {0}", myList.Zipper(myList, myOtherList));
            //Console.WriteLine("First {0}", myList);
            //myList.Sort();
            //Console.WriteLine("Second {0}", myList);
            //Console.WriteLine("Testing Sort {0}", myList);



            Console.Read();
        }
    }
}
