using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab22
{
    class Program
    {
        static int n;
        static int[] array;
        static int MetodSum()
        {
            int sum = 0;
            for (int i=0;i<n;i++)
                sum += array[i];
            Console.WriteLine("Сумма");
            return (sum);
        }
        static int MetodMax(Task task)
        {
            int a = array[0];
            foreach (int m in array)
                if (m > a)
                    a = m;
            Console.WriteLine("Самое большое число");
            return (a);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество чисел в массиве");
            n = Convert.ToInt32(Console.ReadLine());
            array= new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
                array[i] = random.Next();

            Func<int> func1 = new Func<int>(MetodSum);
            Task<int> task1 = new Task<int>(func1);
            
            
            Func<Task,int> func2 = new Func<Task,int>(MetodMax);
            Task<int> task2 = task1.ContinueWith<int>(func2);
            task1.Start();

            Console.WriteLine(task1.Result);
            Console.WriteLine(task2.Result);
            Console.WriteLine("Метод Mine закончил работу");
            Console.ReadKey();
        }
    }
}
