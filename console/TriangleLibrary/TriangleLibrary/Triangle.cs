using System;
using System.Linq;

namespace TriangleLibrary
{
    public class Triangle
    {
        public static void Define()
        {
            try
            {
                Console.WriteLine("Введите, пожалуйста, длины сторон треугольника через пробел:");
                string line = Console.ReadLine();
                int[] triangleSides = line.Split().Select(num => Convert.ToInt32(num)).ToArray();

                if (!CheckIsTriangle(triangleSides))
                {
                    Console.WriteLine("Треугольник не существует!");
                    return;
                }

                int hypotenuse = GetHypotenuse(triangleSides);
                int expressionValue = (int)Math.Round(Math.Pow(hypotenuse, 2));

                switch (true)
                {
                    case true when expressionValue == GetExpression(hypotenuse, triangleSides):
                        Console.WriteLine(GetMessage("прямоугольный"));
                        break;
                    case true when expressionValue < GetExpression(hypotenuse, triangleSides):
                        Console.WriteLine(GetMessage("остроугольный"));
                        break;
                    case true when expressionValue > GetExpression(hypotenuse, triangleSides):
                        Console.WriteLine(GetMessage("тупоугольный"));
                        break;
                    default:
                        break;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Скорее всего Вы ввели не числа, подробности: {0}", e);
            }
        }

        private static int GetHypotenuse(int[] array)
        {
            return array.Max();
        }

        private static int GetExpression(int hypotenuse, int[] array)
        {
            double sum = 0;
            int idx = Array.IndexOf(array, array.First(e => e == hypotenuse));

            for (int i = 0; i < array.Length; i++)
            {
                if (i != idx)
                {
                    sum += Math.Pow(array[i], 2);
                }
            }

            return (int)Math.Round(sum);
        }

        private static string GetMessage(string message)
        {
            return $"Треугольник с заданными сторонами - {message}";
        }

        private static bool CheckIsTriangle(int[] array)
        {
            return (array[0] + array[1] > array[2] && array[0] + array[2] > array[1] && array[1] + array[2] > array[0]);
        }
    }
}
