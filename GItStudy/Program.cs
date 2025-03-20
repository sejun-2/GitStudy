using System.Diagnostics.Metrics;

namespace GItStudy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string my_string = "abcde";
            string letter = "b";

            string answer = "";
            answer = my_string.Replace(letter, "");     // Replace -> letter를 "" 로  교체. 

            Console.WriteLine(answer);      // 글자 하나하나 따로 인식하지는 않음. 통으로 같은지 비교








        }
    }
}
