using System;

namespace sisharp
{
    class Program
    {

        static void Erase_index(ref int[] array,int index)
        {
            if (index >= array.Length || index < 0) return;

            int[] second = new int[array.Length - 1];

            for (int i = 0,k=0; i < second.Length; k++,i++)
            {
                if (i == index) k++;
                second[i] = array[k];
            }

            array = second;
        
        }
        static void Erase_back(ref int[] array)
        {
            if (array.Length == 0) return;
            int[] second = new int[array.Length - 1];

            for (int i = 0, k = 0; i < second.Length; k++, i++)
            {
                second[i] = array[k];
            }

            array = second;
        }
        static void Erase_front(ref int[] array)
        {
            if (array.Length == 0) return;
            int[] second = new int[array.Length -1];

            for (int i = 0,k=1; i < second.Length; k++,i++)
            {
                second[i] = array[k];
            }

            array = second;
        }

        static void Push_index(ref int[] array,int value, int index)
        {
            if (index >= array.Length || index < 0) return;

            int[] second = new int[array.Length + 1];

            second[index] = value;

            for (int i = 0,k=0; i < second.Length; k++,i++)
            {
                if (i == index) i++;
                second[i] = array[k];
            }

            array = second;

        }
        static void Push_front(ref int[] array, int value)
        {
            int[] second = new int[array.Length + 1];

            second[0] = value;

            for (int i = 1,k=0; i < second.Length; k++,i++)
            {
                second[i] = array[k];
            }

            array = second;

        }

        static void Push_back(ref int[] array,int value)
        {
            int[] second = new int[array.Length+1];

            second[array.Length] = value;

            for (int i = 0; i < array.Length; i++)
            {
                second[i] = array[i];
            }


            array = second;

        }

        static void Resize(ref int[] array,int size)
        {
            int lenght = array.Length;
            string exeption = "Error";

            if (size < 0) throw new IndexOutOfRangeException();
            int[] second=new int[size];

            if (lenght<size)
            {
                for (int i = 0; i < lenght; i++)
                {
                    second[i] = array[i];
                }
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    second[i] = array[i];
                }
            }


            array = second;
        }

        static void Main(string[] args)
        {
            int[] array= { 3, 5, 6, 8, 1, 4, 2 };


            Resize(ref array, -3);

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]+" ");
            }
            Console.WriteLine("\nPush_back\n");
            Push_back(ref array, 45);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("\nPush_front\n");
            Push_front(ref array, 45);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("\nIndex\n");

            Push_index(ref array, 45, 2);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("\nErase_front\n");
            Erase_front(ref array);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("\nErase_back\n");
            Erase_back(ref array);            
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("\nErase_index\n");
            Erase_index(ref array, 1);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}
