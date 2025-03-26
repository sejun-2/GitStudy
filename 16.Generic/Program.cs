namespace _16.Generic
{
    internal class Program
    {
        // 일반화 (Generic) : 클래스나 메서드를 정의할 때 타입을 매개변수로 받아서 처리하는 방식
        // 클래스 또는 함수가 코드에 의해 엄선되고 인스턴스화될 때까지 형식의 사양을 연기하는 방법
        // 기능을 구현한 뒤 자료형을 사용 당시에 지정해서 사용.

        static void Main(string[] args)
        {
            int value = 1;

            // 업캐스팅 : 암시적으로 가능
            // 박싱 : 값형식 -> 참조형식
            object obj = value;

            // 다운캐스팅 : 명시적으로 해야함
            // 언박싱 : 참조형식 -> 값형식
            int result = (int)obj;

            Console.WriteLine("{0}, {1}, {2}", value, obj, result);

            if (obj is int)     // obj가 int형이면 true
            {
                int result2 = (int)obj;
                Console.WriteLine(result2);
            }

            /******************************************************************/

            int a = 10;
            int b = 20;

            Util.Swap(ref a, ref b);

            Console.WriteLine("{0}, {1}", a, b);

            float fLeft = 10.5f;
            float fRight = 20.5f;

            Util.Swap(ref a, ref b);    // <bool> : 자료형의 형식을 직접 지정도 가능

            bool bLeft = true;
            bool bRight = false;

            Util.Swap<bool>(ref bLeft, ref bRight);     // <bool> : 자료형의 형식을 직접 지정도 가능

            /******************************************************************/

            Item item1 = new Item();
            item1.name = "포션";

            Item item2 = new Item();
            item2.name = "포션";

            Console.WriteLine("두 아이템이 같은 아이템이다 결과 : {0}", EquaalItem(item1, item2));


            int intBigger = Bigger(10,20);
            double doubleBigger = Bigger(10.5, 20.5);

            Item itemBigger = Bigger(new Item(), new Item());   // 아이템 정렬?

        }

        //<일반화 자료형의 제약>
        // 일반화 자료형을 선언할 때 제약조건을 선언하여, 사용 당시 쓸 수 있는 자료형을 제한.


        /// <summary>
        /// 제약사항을 걸어서 Item 클래스를 상속받은 클래스만 사용가능
        /// </summary>
        /// <typeparam name="T">일반화 - 자료의 형식을 지정하지 않음</typeparam>
        /// <param name="item">where T : Item -> Item 클래스를 상속받은 클래스만 사용가능</param>
        public static bool EquaalItem<T>(T item1, T item2) where T : Item
        {
            return item1.name == item2.name;
        }

        public static T Bigger<T>(T left, T right) where T : IComparable<T> // 예시 - 이렇게도 쓸 수 있음
        {         // T -> 결과도 T로 반환 -> 결과도 자료형에 맞는 걸로 받고 싶다.
            if (left.CompareTo(right) > 0)
            {
                return left;
            }
            else
            {
                return right;
            }
        }


    }

    public class Item : IComparable<Item>
    {
        public string name;
        public bool isUseble;

        public int CompareTo(Item other)
        {
            return name.CompareTo(other.name);
        }
    }

    public class Weapon : Item{ }

    public class CusumableItem : Item { }

    public class QuestItem : Item { }

    public class Util
    {
        //<일반화 함수>
        //일반화는 자료형의 형식을 지정하지 않고 함수를 정의
        // 기능을 구현한 뒤 사용 당시에 자료형의 형식을 지정해서 사용
        public static void Swap<T>(ref T left, ref T right)     // 함수명<T> : 자료형의 형식을 지정하지 않음
        {
            T temp = left;
            left = right;
            right = temp;
        }

        //public static T Add<T>(T left, T right) // X
        //{                           // bool 등 연산이 불가능한 자료형이 들어올수 있기때문에 쓸 수 없음
        //    return left + right;    // 산술연산, 논리연산은 사용불가!
        //}

    }





}
