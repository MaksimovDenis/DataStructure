using System;
using DataStructures;

namespace DataStructuresConsole
{
    public class Programm
    {

        static void Main(string[] args)
        {

            ArrayList myList1 = new ArrayList(new int[] { 3, 0, -23, 31, 54, 32 });

            myList1.FindeValueByIndex(2);

            Console.WriteLine("");

            for (int i = 0; i < myList1.Length; i++)
            {
                Console.Write("{0} ", myList1[i]);
            }









        }
    }
}
