using System.Collections.Generic;

namespace _0328.Practice
{
    internal class Program
    {

        public static int Yosepus(int n, int k)
        {
            Queue<int> queue = new Queue<int>(n);
            for (int i = 1; i <= n; i++)
            {
                queue.Enqueue(i);
            }

            int count = 0;
            while (queue.Count > 1)
            {
                count++;
                if (count % k == 0)
                {
                    queue.Dequeue();
                }
                else
                {
                    int value = queue.Dequeue();
                    queue.Enqueue(value);
                }
            }

            return queue.Dequeue();
        }

        public static bool IsCorrectBracket(string str)
        {
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];

                switch (c)
                {
                    case '(':
                    case '{':
                    case '[':
                        stack.Push(c);
                        break;

                    case ')':
                        if (stack.Count == 0)
                            return false;

                        if (stack.Peek() != '(')
                            return false;

                        stack.Pop();
                        break;

                    case '}':
                        if (stack.Count == 0)
                            return false;

                        if (stack.Peek() != '{')
                            return false;

                        stack.Pop();
                        break;

                    case ']':
                        if (stack.Count == 0)
                            return false;

                        if (stack.Peek() != '[')
                            return false;

                        stack.Pop();
                        break;
                }
            }

            if (stack.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Main(string[] args)
        {
            int n = 8;
            int k = 5;
            int result = Yosepus(n, k);
            Console.WriteLine("요세푸스({0}, {1}) 의 결과는 : {2}", n, k, result);

            string str = "[]]";
            Console.WriteLine("괄호 검사기의 결과는: {0}", IsCorrectBracket(str));
        }
    }
}
