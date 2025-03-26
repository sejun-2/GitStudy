using static _19.ExtensionMethod.Extension;

namespace _19.ExtensionMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "Winner Winner chicken dinner";

            //int count = Extension.WordCount(text);      // 4개의 단어가 있다는 걸 알 수 있음.
            int count = text.WordCount();                // 확장메서드를 사용하여 위와 같은 결과를 얻을 수 있음.
            Console.WriteLine(count);                   // 4

            int charCount = text.CharCount('i');           // 확장메서드를 사용하여 i 문자의 개수를 구할 수 있음.
            Console.WriteLine(charCount);                // 4


            int value = 10;

            bool result = value.IsOddNumber();           // 확장메서드를 사용하여 홀수인지 짝수인지 판별할 수 있음.
            if (result == true)
            {
                Console.WriteLine("정수 {0} 은 홀수입니다.", value);
            }
            else
            {
                Console.WriteLine("정수 {0} 은 짝수입니다.", value);
            }



            Item[] inventory = new Item[10];
            Item potion = inventory.FindByName("포션");        // 확장메서드를 사용하여 아이템을 찾을 수 있음.
        }
    }

     //확장메서드(ExtensionMethod)
     //클래스의 원래 형식을 수정하지 않고도 기존 형식에 함수를 추가할 수 있음.
     //상속을 통하여 만들지 않고도 추가적인 함수를 구현 가능.
     //정적함수에 첫번째 매개변수를 this 키워드 후 확장하고자 하는 자료형을 작성.

    public static class Extension       // 확장메서드를 사용하기 위해서는 static 클래스로 선언해야 함.!!!
    {
        // 확장메서드는 static으로 선언해야 함. 첫번째 매개변수는 this 키워드를 사용하여 확장하고자 하는 자료형을 선언.
        public static int WordCount(this string text)   
        {
            string[] words = text.Split(' ');
            return words.Length;
        }

        public static int CharCount(this string text, char ch)
        {
            int count = 0;
            foreach (char c in text)
            {
                if (c == ch)
                    count++;
            }
            return count;
        }



        public static bool IsOddNumber(this int number)
        {
            return number % 2 != 0;
        }


        public class Item
        {
            public string name;
        }

        public static Item FindByName(this Item[] inventory, string itemName)
        {
            for (int i=0; i<inventory.Length; i++)
            {
                if(inventory[i].name == itemName)
                    return inventory[i];
            }
            return null; // 아이템을 찾지 못했을 경우 null 반환
        }
    }
}
