using System.Security.Cryptography.X509Certificates;

namespace _20.Delegate
{
    /*
    대리자 (Delegate)
    특정 매개 변수 목록 및 반환 형식이 있는 함수에 대한 참조
    대리자 인스턴스를 통해 함수를 호출 할 수 있음
    */

    // <델리게이트 정의>
    // delegate 반환형(void,float 등) 델리게이트이름(매개변수들);

    public delegate float DelegateMethod1(float left, float right);     // 함수를 대신 실행시킬 뿐이라서 { } 내용은 필요 없음
    public delegate void DelegateMethod2(string str);

    public enum Type { }
    public struct GameData { }
    public class Player { }
    


    internal class Program
    {
        public static float Plus(float left, float right) { return left + right; }
        public static float Minus(float left, float right) { return left - right; }
        public static float Multi(float left, float right) { return left * right; }
        public static float Divide(float left, float right) { return left / right; }
        public static void Message(string message) { Console.WriteLine("메세지로 {0}을 전송합니다.", message); }

        static void Main(string[] args)
        {
            DelegateMethod1 delegate1 = Plus;
            //DelegateMethod1 delegate1 = Message;  // 불가능 delegate의 반환형이 float라서 string은 저장 불가능!!
            DelegateMethod2 delegate2 = Message;    // DelegateMethod2 는 void와 매개변수가 string을 받는거라서 가능.
            
            // 원래는 이렇게 사용. Invoke 부르다
            delegate1.Invoke(20f, 10f);         // 보관한 함수를 부르는 기능
            delegate1(20f, 10f);                // Invoke를 간략하고 직관적으로 사용하기 위한 문법 허용

            float result;
            result = delegate1(20f,10f);
            Console.WriteLine(result);      // 30

            // <델리게이트 사용>
            // 반환형과 매개변수가 일치하는 함수를 델리게이트 변수에 할당
            // 델리게이트 변수에 참조한 함수를 대리자를 통해 호출 가능

            delegate1 = Plus;
            Console.WriteLine(delegate1(20f, 10f));     // Plus(20f, 10f) = 30
            delegate1 = Minus;
            Console.WriteLine(delegate1(20f, 10f));     // Minus(20f, 10f) = 10
            delegate1 = Multi;
            Console.WriteLine(delegate1(20f, 10f));     // Multi(20f, 10f) = 200
            delegate1 = Divide;
            Console.WriteLine(delegate1(20f, 10f));     // Divide(20f, 10f) = 2









        }
    }
}
