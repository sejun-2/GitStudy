namespace _26.Stack
{
    internal class Program
    {
        /*
            스택 (Stack)  : 배열 구조를 사용하나 index 기능은 막아놈
          
           선입후출(FILO), 후입선출(LIFO) 방식의 자료구조
           가장 최신 입력된 순서대로 처리해야 하는 상황에 이용
         */

        // <스택 구현>
        // 스택은 리스트를 사용법만 달리하여 구현 가능
        //
        // - 삽입 -
        //         top                      top
        //          ↓                        ↓
        // ┌─┬─┬─┬─┬─┬─┬─┬─┐      ┌─┬─┬─┬─┬─┬─┬─┬─┐
        // │1│2│3│4│5│ │ │ │  =>  │1│2│3│4│5│6│ │ │
        // └─┴─┴─┴─┴─┴─┴─┴─┘      └─┴─┴─┴─┴─┴─┴─┴─┘
        //
        // - 삭제 -
        //           top                  top
        //            ↓                    ↓
        // ┌─┬─┬─┬─┬─┬─┬─┬─┐      ┌─┬─┬─┬─┬─┬─┬─┬─┐
        // │1│2│3│4│5│6│ │ │  =>  │1│2│3│4│5│ │ │ │
        // └─┴─┴─┴─┴─┴─┴─┴─┘      └─┴─┴─┴─┴─┴─┴─┴─┘


        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(20);

            // srack 추가 : 0(1), 최악 (용량이 가득 찼었을 때) : 0(n)
            stack.Push(1);      
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            // RJsorl : 0(1)
            Console.WriteLine(stack.Pop());     // 후입선출  5
            Console.WriteLine(stack.Pop());     // 4
            Console.WriteLine(stack.Pop());     // 3

            // 다음차례에 꺼내질 요소 확인, 넘어가진 않음. : 0(1)
            Console.WriteLine(stack.Peek());    // 2 
            Console.WriteLine(stack.Peek());    // 2
            Console.WriteLine(stack.Peek());    // 2


            stack.Push(6);
            stack.Push(7);
            stack.Push(8);
            stack.Push(9);

            if (stack.Count > 0)                    // 있으면 꺼냄.
            {
                Console.WriteLine(stack.Pop());     // 9
            }

            stack.TryPop(out int pop);


        }
    }
}
