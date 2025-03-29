namespace _22._4IfState
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int left = 10;
            int right = 20;


            // 삼항 연산자
            int bigger = left > right  ? left : right;  // left가 right 보다 크다면 left출력 아니면 right 출력
            Console.WriteLine(bigger);

            int abs = left >= 0 ? left : right;           // left가 0과 크거나 같다면 left출력 아니면 right 출력
            Console.WriteLine(abs);

           

        }
    }
}
