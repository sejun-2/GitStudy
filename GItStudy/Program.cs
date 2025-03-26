using System.Diagnostics.Metrics;
using static System.Net.Mime.MediaTypeNames;

namespace GItStudy
{
    internal class Program
    {

        public static int FindKeyIndex(string text, char key)
        {
            char[] array = text.ToCharArray();
            int num = 0;
            for (int i=0; i< array.Length; i++)
            {
                if (array[i]==key)
                {
                    return num = i;
                }
            }

            return -1;
        }

        public static bool IsPrime(int number)
        {
            if (number%2!=0)
            {
                return true;
            }
            return false;
        }

        public static int SumOfDigits(int number)
        {
            int answer = 0;
            string num = number.ToString();
            char[] array = num.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                answer+=array[i]-'0';           //char는 문자타입으로 해당문자의 아스키 숫자값이 더해져 오류가남. -'0' 하면 해결
                Console.WriteLine(array[i]);
            }
            return answer;
        }

        //public static int[] FindCommonItems(int[] array1, int[] array2)
        //{
        //    int[] answer = {2};

        //    for (int i =0; i<array1.Length; i++)
        //    {
        //        for (int j = 0; j < array2.Length; j++)
        //        {
        //            if (array1[i]== array2[j])
        //            {
        //                answer[j] = array1[i];
        //            }
        //            else
        //            {

        //            }
        //        }
        //    }


        //    return answer;
        //}

        static void Main(string[] args)
        {
            //string my_string = "abcdef";
            //string letter = "b";

            //string answer = "";
            //answer = my_string.Replace(letter, "");     // Replace -> letter를 "" 로  교체. 

            //Console.WriteLine(answer);      // 글자 하나하나 따로 인식하지는 않음. 통으로 같은지 비교

            /***************************************************************************************/

            string text = "abcdef";
            char key = 'd';

            Console.WriteLine(FindKeyIndex(text, key));

            /***************************************************************************************/
            
            Console.WriteLine(IsPrime(7));

            /***************************************************************************************/

            Console.WriteLine(SumOfDigits(3849));

            /***************************************************************************************/

            //int[] array1 = { 1, 5, 5, 10 };
            //int[] array2 = { 3, 5, 5, 10 };

            //Console.WriteLine(FindCommonItems(array1, array2));

            /***************************************************************************************/

            int value = 0;
            while (value < 20)
            {
                value++; ;
                if (value > 10)
                    break;
            }
            Console.WriteLine(value);


        }
    }
}
