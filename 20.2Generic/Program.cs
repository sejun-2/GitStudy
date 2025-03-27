using static _20._2Generic.Program;

namespace _20._2Generic
{
    internal class Program
    {
        /*
            일반화 델리게이트
            개발과정에서 많이 사용되는 델리게이트의 경우 일반화된 델리게이트를 사용
         */

        // <Func 델리게이트>
        // 반환형 매개변수를 지정한 델리게이트
        // Func<매개변수1, 매개변수2, ..., 반환형>

        public delegate void StringDelegate(string str);
        public delegate void LogDelegate(string str);

        public static void Message(string message) { Console.WriteLine("메시지 발송! : {0}", message); }

        public static float Test(int value1, string value2) { return 0; }
        public static string Test2(float value) { return "안녕하세요"; }

        // <Action 델리게이트>
        // 반환형이 void 이며 매개변수를 지정한 델리게이트
        // Action<매개변수1, 매개변수2, ...>
        void Message2(string message) { Console.WriteLine(message); }


        public 
        static void Main(string[] args)
        {
            //StringDelegate stringDelegate = Message;
            //LogDelegate logDelegate = Message;

            Action<string> stringDelegate = Message;    // 일반화 델리게이트 -> 프로그램상 미리 만들어진 델리게이트 가져다 쓰자
            Action<string> logDelegate = Message;

            stringDelegate = logDelegate;


            Func<int, int, int> func;           // int매개변수, int매개변수 를 int반환형으로 받는다

            Func<int, string, float> func1 = Test;
            Func<float, string> func2 = Test2;

            /*************************************************************************************/

            Action<string> action = Message;


        }
    }
}
