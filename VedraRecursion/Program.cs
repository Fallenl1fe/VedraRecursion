using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VedraRecursion
{
    internal class Program
    {
        public static void FirstToSecond(ref int Value1, ref int Value2)
        {
            while (Value1 != 0 && Value2 != 7)
            {
                Value1 -= 1;
                Value2 += 1;
            }
        }
        public static void FirstToThird(ref int Value1, ref int Value3)
        {
            while (Value1 != 0 && Value3 != 3)
            {
                Value1 -= 1;
                Value3 += 1;
            }

        }
        public static void SecondToFirst(ref int Value2, ref int Value1)
        {
            while (Value2 != 0 && Value1 != 10)
            {
                Value2 -= 1;
                Value1 += 1;
            }
        }
        public static void SecondToThird(ref int Value2, ref int Value3)
        {
            while (Value2 != 0 && Value3 != 3)
            {
                Value2 -= 1;
                Value3 += 1;
            }
        }
        public static void ThirdToFirst(ref int Value3, ref int Value1)
        {
            while (Value3 != 0 && Value1 != 10)
            {
                Value3 -= 1;
                Value1 += 1;
            }
        }
        public static void ThirdToSecond(ref int Value3, ref int Value2)
        {
            while (Value3 != 0 && Value2 != 7)
            {
                Value3 -= 1;
                Value2 += 1;
            }
        }

        //Конец методов переливания

        public static void ValueBack(ref int[][] arrayOfArray, int i)
        {  //Вернуть значения к прошлым
            arrayOfArray[i][0] = 0;
            arrayOfArray[i][1] = 0;
            arrayOfArray[i][2] = 0;
        }

        public static bool NotDuplicate(int[][] arrayOfArray, int[] array)
        {  //Поиск дупликатов состояний, убрать зацикливание
            foreach (var ara in arrayOfArray)
            {
                if (Enumerable.SequenceEqual(ara,array))
                {
                    return false;
                }
            }
            
            return true;
        }

        public static void ReturnValueMinusOne(ref int Value1, ref int Value2, ref int Value3, int[][] arrayOfArray,int i) 
        {  //Востановить значения переменных
            Value1 = arrayOfArray[i - 1][0];
            Value2 = arrayOfArray[i - 1][1];
            Value3 = arrayOfArray[i - 1][2];
        } 
        
        static void Recursion(int Value1, int Value2, int Value3, int[][] arrayOfArray,int i, int k)
        {
            if (arrayOfArray[i][0] == 5 && arrayOfArray[i][1] == 5)
            {
                Console.WriteLine("");
                for (int j = 0; j < arrayOfArray.Length; j++)
                {
                    if ( arrayOfArray[j][0] != 0 || arrayOfArray[j][1] != 0 || arrayOfArray[j][2] != 0)
                    Console.WriteLine($"Action: {j}  |  {arrayOfArray[j][0]}  |  {arrayOfArray[j][1]}  |  {arrayOfArray[j][2]}  |");
                }
            }
            else
            {

                if (i < k) // макс действие
                {

                    i++;
                    for (int m = 1; m < 7; m++)
                    {
                        switch (m)
                        {
                            case 1:
                                ReturnValueMinusOne(ref Value1, ref Value2, ref Value3, arrayOfArray, i);
                                FirstToSecond(ref Value1, ref Value2);
                                if (NotDuplicate(arrayOfArray, new int[] {Value1,Value2,Value3}))
                                {
                                    arrayOfArray[i][0] = Value1; arrayOfArray[i][1] = Value2; arrayOfArray[i][2] = Value3;
                                    Recursion(Value1,Value2,Value3, arrayOfArray, i, k);
                                }
                                //else
                                //{ Console.WriteLine($"Branch {arrayOfArray[i - 1][0]}  |  {arrayOfArray[i- 1][1]}  |  {arrayOfArray[i - 1][2]} break "); }
                                break;
                            case 2:
                                ReturnValueMinusOne(ref Value1, ref Value2, ref Value3, arrayOfArray, i);
                                FirstToThird(ref Value1, ref Value3);
                                if (NotDuplicate(arrayOfArray, new int[] { Value1, Value2, Value3 }))
                                {
                                    arrayOfArray[i][0] = Value1; arrayOfArray[i][1] = Value2; arrayOfArray[i][2] = Value3;
                                    Recursion(Value1, Value2, Value3, arrayOfArray, i, k);
                                }
                                //else
                                //{ Console.WriteLine($"Branch {arrayOfArray[i - 1][0]}  |  {arrayOfArray[i - 1][1]}  |  {arrayOfArray[i - 1][2]} break "); }
                                break;
                            case 3:
                                ReturnValueMinusOne(ref Value1, ref Value2, ref Value3, arrayOfArray, i);
                                SecondToFirst(ref Value2, ref Value1);
                                if (NotDuplicate(arrayOfArray, new int[] { Value1, Value2, Value3 }))
                                {
                                    arrayOfArray[i][0] = Value1; arrayOfArray[i][1] = Value2; arrayOfArray[i][2] = Value3;
                                    Recursion(Value1, Value2, Value3, arrayOfArray, i, k);
                                }
                                //else
                                //{ Console.WriteLine($"Branch {arrayOfArray[i - 1][0]}  |  {arrayOfArray[i - 1][1]}  |  {arrayOfArray[i - 1][2]} break "); }
                                break;
                            case 4:
                                ReturnValueMinusOne(ref Value1, ref Value2, ref Value3, arrayOfArray, i);
                                SecondToThird(ref Value2, ref Value3);
                                if (NotDuplicate(arrayOfArray, new int[] { Value1, Value2, Value3 }))
                                {
                                    arrayOfArray[i][0] = Value1; arrayOfArray[i][1] = Value2; arrayOfArray[i][2] = Value3;
                                    Recursion(Value1, Value2, Value3, arrayOfArray, i, k);
                                }
                                //else
                                //{ Console.WriteLine($"Ветка  {arrayOfArray[i - 1][0]}  |  {arrayOfArray[i - 1][1]}  |  {arrayOfArray[i - 1][2]}   break "); }
                                break;
                            case 5:
                                ReturnValueMinusOne(ref Value1, ref Value2, ref Value3, arrayOfArray, i);
                                ThirdToFirst(ref Value3, ref Value1);
                                if (NotDuplicate(arrayOfArray, new int[] { Value1, Value2, Value3 }))
                                {
                                    arrayOfArray[i][0] = Value1; arrayOfArray[i][1] = Value2; arrayOfArray[i][2] = Value3;
                                    Recursion(Value1, Value2, Value3, arrayOfArray, i, k);
                                }
                                //else
                                //{ Console.WriteLine($"Ветка  {arrayOfArray[i - 1][0]}  |  {arrayOfArray[i - 1][1]}  |  {arrayOfArray[i - 1][2]}   break "); }
                                break;
                            case 6:
                                ReturnValueMinusOne(ref Value1, ref Value2, ref Value3, arrayOfArray, i);
                                ThirdToSecond(ref Value3, ref Value2);
                                if (NotDuplicate(arrayOfArray, new int[] { Value1, Value2, Value3 }))
                                {
                                    arrayOfArray[i][0] = Value1; arrayOfArray[i][1] = Value2; arrayOfArray[i][2] = Value3;
                                    Recursion(Value1, Value2, Value3, arrayOfArray, i, k);
                                }
                                //else
                                //{ Console.WriteLine($"Ветка  {arrayOfArray[i - 1][0]}  |  {arrayOfArray[i - 1][1]}  |  {arrayOfArray[i - 1][2]}   break "); }
                                break;

                            default:
                                break;
                        }//Switch end
                    }//for end
                    ValueBack(ref arrayOfArray, i);
                    i--;
                }
            } 
        }



        static void Main(string[] args)
        {
            //int[][] intsResult = new int[11][]
            //{
            //    new int[]{10,0,0},  //0
            //    new int[]{3,7,0},   //1
            //    new int[]{3,4,3},   //2
            //    new int[]{6,4,0},   //3
            //    new int[]{6,1,3},   //4
            //    new int[]{9,1,0},   //5
            //    new int[]{9,0,1},   //6
            //    new int[]{2,7,1},   //7
            //    new int[]{0,0,0},   //8
            //    new int[]{0,0,0},   //9
            //    new int[]{0,0,0},     //10
            //};

            int[][] intsResult = new int[12][]
            {
                new int[]{10,0,0},  //0
                new int[]{0,0,0},   //1
                new int[]{0,0,0},   //2
                new int[]{0,0,0},   //3
                new int[]{0,0,0},   //4
                new int[]{0,0,0},   //5
                new int[]{0,0,0},   //6
                new int[]{0,0,0},   //7
                new int[]{0,0,0},   //8
                new int[]{0,0,0},   //9
                new int[]{0,0,0},   //10
                new int[]{0,0,0},   //11
            };

            int i = 0;
            int k = 10; //максимальное количество действий
            int Value1 = 0;
            int Value2 = 0;
            int Value3 = 0;
            Recursion(Value1, Value2, Value3, intsResult, i, k);

        }
    }
}
