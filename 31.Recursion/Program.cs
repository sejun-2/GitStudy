namespace _31.Recursion
{
    internal class Program
    {
        /*
            재귀 (Recursion)
            어떠한 것을 정의할 때 자기 자신을 참조 하는것
            함수를 정의할 때 자기자신을 이용하여 표현하는 방법
         */

        // <재귀함수 조건>
        // 1. 함수내용 중 자기자신함수를 다시 호출해야함
        // 2. 종료조건이 있어야 함

        // <재귀함수 장점>
        // 1. 코드로 표현하기 어려운 경우도 직관적이고, 처리가 가능
        // 2. 분할정복을 통한 반절 계산이 가능해서 효율이 높아지게 구현이 가능


        // <재귀함수 사용>
        // Factorial : 정수를 1이 될 때까지 차감하며 곱한 값
        // x! = x * (x-1)!;
        // 1! = 1;
        // ex) 5! = 5 * 4!
        //        = 5 * 4 * 3!
        //        = 5 * 4 * 3 * 2!
        //        = 5 * 4 * 3 * 2 * 1!
        //        = 5 * 4 * 3 * 2 * 1

        // 재귀함수는 예외 처리가 안되면(종료 조건) -> 오버플로우에 빠짐 (터짐)


        int Factorial(int x)
        {
            if (x == 1)
                return 1;
            else
                return x * Factorial(x - 1);
        }



        public class Folder
        {
            //public List<string> files;
            public List<Folder> children;
        }

        public static void RemoveFolder(Folder folder)
        {
            // 파일들 삭제하고

            foreach (var child in folder.children)
            {
                RemoveFolder(child);
            }
        }

        int Fibonaachi(int n)       //  재귀를 써도 최악의 알고리즘. -> 소모되는 시간 2배
        {
            if(n==1) return 1;
            else if(n==2) return 1;
            return Fibonaachi(n - 1) + Fibonaachi(n - 2);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
