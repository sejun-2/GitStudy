namespace _20._2Chain
{
    internal class Program
    {
        /*
            델리게이트 체인
            델리게이트 변수에 여러게의 함수를 참조하는 방법
         */

        static void Main(string[] args)
        {
            Action action;
            action = Func1;      // 델리게이트에 Func1 로 초기화
            action += Func2;     // 델리게이트에 Func2 추가 참조
            action += Func3;     // 델리게이트에 Func3 추가 참조
            action += Func2;     // 같은 Func 중복 참조도 가능
            action();           // Func1 - Func2 - Func3 -Func2
            Console.WriteLine();

            action -= Func2;    // 저장한 Func2 참조 제거도 가능
            action();           // Func1 - Func2 - Func3
            Console.WriteLine();

            action = Func3;     // 델리게이트에 = 을 통해서 대입하는 경우, 이전의 참조된 상황이 사라짐
            action -= Func1;    // 델리게이트에 참조되지 않은 함수를 제거하는 경우, 해당 작업이 무시됨
            action();           // Func3


            action = Func2;     // 델리게이트에 참조된 상황이 없을경우 터진다.
            action -= Func2;
            //action();            // 꼭 있을때만 호출!!

            if (action != null)     // 델리게이트에서 참조를 제거할 경우 참조하고 있는 함수가 없는 경우를 조심!!
            {
                action();
            }

        }

        public static void Func1() { Console.WriteLine("Func1"); }
        public static void Func2() { Console.WriteLine("Func2"); }
        public static void Func3() { Console.WriteLine("Func3"); }




    }
}
