﻿namespace GItStudy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Console.Write("이름을 입력해 주세요 : ");
            string input = Console.ReadLine();

            Console.WriteLine("입력하신 이름은 {0} 입니다.", input);
        }
    }
}
