using System;
using System.Linq;

namespace Akmal
{
    public static class ArrayHelemper<Tarray>
    {
        public static Tarray Pop(ref Tarray[] arr)
        {
            Tarray elem = arr[arr.Length - 1];
            Array.Resize(ref arr, arr.Length - 1);
            return elem;
        }
        public static int Push (ref Tarray[] arr, Tarray elem)
        {
            Array.Resize(ref arr, arr.Length + 1);
            arr[arr.Length - 1] = elem;
            return arr.Length;
        }
        public static Tarray Shift(ref Tarray[] arr)
        {
            Tarray elem = arr[0];
            for (int i = 0; i < arr.Length - 1; i++)
                arr[i] = arr[i + 1];
            Array.Resize(ref arr, arr.Length - 1);
            return elem;
        }
        public static int UnShift(ref Tarray[] arr, Tarray elem)
        {
            Array.Resize(ref arr, arr.Length + 1);
            for (int i = arr.Length - 1; i >= 1; i--)
                arr[i] = arr[i - 1];
            arr[0] = elem;
            return arr.Length;
        }
        public static Tarray[] Slice(Tarray[] arr, int bindex = 0, int eIndex = 0)
        {
            int length = 0;
            int j = 0;
            Tarray[] newArr = new Tarray[length];
            if (eIndex == 0) eIndex = arr.Length;
            if (bindex > arr.Length - 1 || eIndex > arr.Length) return newArr;
            if (bindex >= 0 && eIndex > 0 && eIndex <= arr.Length)
            {
                for (int i = bindex; i < eIndex; i++)
                {
                    Array.Resize(ref newArr, newArr.Length + 1);
                    newArr[j] = arr[i];
                    j++;
                }
            }
            if (bindex >=0 && eIndex < 0)
            {
                for (int i = bindex; i < arr.Length + eIndex; i++)
                {
                    Array.Resize(ref newArr, newArr.Length + 1);
                    newArr[j] = arr[i];
                    j++;
                }
            }
            if (bindex < 0)
            {
                
                for (int i = arr.Length + bindex; i < arr.Length; i++)
                {
                    Array.Resize(ref newArr, newArr.Length + 1);
                    newArr[j] = arr[i];
                    j++;
                }
            }
            return newArr;
        }
        public static void ShowArray(Tarray[] arr)
        {
            foreach (Tarray elem in arr)
                Console.Write($"{elem} ");
            Console.Writelemine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = { "Sabaka", "Jiraf", "Nosorog", "Utka", "UtkaNos", "Tigr", "Akmal" };
            Console.Writelemine("Ваш массив: ");
            ArrayHelemper<string>.ShowArray(arr);
            Console.Writelemine("Ваш массив после применения метода Pop:");
            Console.Writelemine($"Удалили:  {ArrayHelemper<string>.Pop(ref arr)}");
            Console.Writelemine("Осталось:");
            ArrayHelemper<string>.ShowArray(arr);
            Console.Writelemine("Ваш массив после применения метода Push:");
            Console.Writelemine($"Обновленная длина {ArrayHelemper<string>.Push(ref arr, "Кошка")}");
            Console.Writelemine("Сам массив: ");
            ArrayHelemper<string>.ShowArray(arr);
            Console.Writelemine("Ваш массив после применения метода Shift:");
            Console.Writelemine($"Удалили: {ArrayHelemper<string>.Shift(ref arr)}");
            Console.Writelemine("Осталось:");
            ArrayHelemper<string>.ShowArray(arr);
            Console.Writelemine("Ваш массив после применения метода UnShift:");
            Console.Writelemine($"Обновленная длина {ArrayHelemper<string>.UnShift(ref arr, "Сабака")}");
            Console.Writelemine("Mассив: ");
            ArrayHelemper<string>.ShowArray(arr);
            Console.Writelemine("Метод Slice: ");
            string[] newArr = ArrayHelemper<string>.Slice(arr, -4);
            ArrayHelemper<string>.ShowArray(newArr);
        }
    }
}

