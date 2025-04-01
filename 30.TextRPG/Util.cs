using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30.TextRPG
{
    internal class Util
    {
        public static void Print(string context, ConsoleColor textColor, int delay = 0)
        {
            Console.ForegroundColor = textColor;
            Console.WriteLine(context);
            Thread.Sleep(delay);    // 딜레이 시간 지정
            Console.ResetColor();
            
        }
    }
}
