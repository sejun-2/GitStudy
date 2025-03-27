namespace _22.Additional
{
    internal class Program
    {
        // <Named Parameter>
        // 함수의 매개변수 순서와 무관하게 이름을 통해 호출
        public static void Profile(int id, string name, string phone) { }

        static void Main1(string[] args)
        {
            Profile(10, "김전사", "010-1111-2222");

            //함수 호출시 이름을 명명하고 순서와 상관없이 호출 가능
            Profile(name:"김전사", phone:"010-1111-2222", id:10);
            Profile(phone: "010-1111-2222",name: "김전사", id: 10);
        }



        // <Optional Parameter>
        // 함수의 매개변수가 초기값을 갖고 있다면, 함수 호출시 생략하는 것을 허용하는 방법

        public static void AddStudent(string name, string home = "서울", int age = 8) { }

        //public static void AddStudent(string home = "서울", int age = 8, string name ) { }
        // error 초기값이 있는 매개변수는 뒤부터 배치해야 한다.
        static void Main2(string[] args)
        {
            AddStudent("철수");               // AddStudent("철수", "서울", 8)
            AddStudent("영희");               // AddStudent("영희", "서울", 8)
            AddStudent("민주", "인천");       // AddStudent("민주", "인천", 8)
            AddStudent("미영", age:10);       // AddStudent("미영", "서울", 10)
        }



        // <Params Parameter>
        // 매개변수의 갯수가 정해지지 않은 경우, 매개변수의 갯수를 유동적으로 사용하는 방법
        public static int Sum(params int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }

        public static void Main3()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };

            Sum(numbers);

            Sum(1, 2, 3);
            Sum(1, 2, 3, 4, 5, 6);
            Sum(1);
            Sum();
        }



        // <out Parameter>
        // 매개변수를 출력전용으로 설정
        // 함수의 반환값 외에 추가적인 출력이 필요한 경우 사용
        public static void Divide(int left, int right, out int quotient, out int remainder)
        {
            quotient = left / right;
            remainder = right / left;

            // 함수의 종료전까지 out 매개변수에 값이 할당 안되는 경우 오류
        }

        public static void Main()
        {
            Divide(5, 3, out int quotient, out int remainder);
            Console.WriteLine($"{quotient}, {remainder}");  // output : 1, 2
        }



        // <in Parameter>
        // 매개변수를 입력전용으로 설정
        // 함수의 처음부터 끝까지 동일한 값을 보장하게 됨
        int Plus(in int left, in int right)
        {
            // left = 20;      // error : 입력전용 매개변수는 변경 불가
            return left + right;
        }

        void Main4()
        {
            int result = Plus(1, 3);
            Console.WriteLine($"{result}");     // output : 4
        }




        // <ref Parameter>
        // 매개변수를 원본참조로 전달
        // 매개변수가 값형식인 경우에도 함수를 통해 원본값을 변경하고 싶을 경우 사용
        void Swap(ref int left, ref int right)
        {
            int temp = left;
            left = right;
            right = temp;
        }

        void Main6()
        {
            int left = 10;
            int right = 20;
            Swap(ref left, ref right);
            Console.WriteLine($"{left}, {right}");      // output : 20, 10
        }
    }
}
