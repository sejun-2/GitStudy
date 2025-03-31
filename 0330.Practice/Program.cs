namespace _0330.Practice
{
    internal class Program
    {

        public class MyStack<T>
        {
            //다음의 조건을 충족하는 MyStack<T> 클래스를 구현하시오
            //Stack<T> 클래스의 사용을 금지하며, 배열을 사용해 구현한다.
            public T[] array;
            public int size;
            private int capacity;


            //클래스의 인스턴스 생성 시 최초 10의 크기를 가진다.
            public MyStack()
            {
                capacity = 10;
                array = new T[capacity];
                size = 0;
            }

            //배열의 크기를 넘어서 데이터를 추가할 경우, 현재 배열의 크기의 2배만큼 재할당해야 한다.
            //아래 필수 구현 메서드 외 내부 동작을 위한 필드 및 메서드 추가는 허용한다.
            //구현 메서드
            //Push(T element) : 배열의 맨 뒤에 데이터를 추가한다.
            public void Push(T element)
            {
                if (size == capacity)
                {
                    capacity *= 2;
                    T[] newArray = new T[capacity];
                    for (int i = 0; i < size; i++)
                    {
                        newArray[i] = array[i];
                    }
                    array = newArray;
                }
                array[size++] = element;
            }
            //Pop() : 가장 마지막에 추가한 데이터를 반환하고, 내부 배열에서 삭제한다.
            public T Pop()
            {
                if (size == 0)
                    return default(T); // 기본값 반환
                return array[--size];
            }
            //Peek() : 가장 마지막에 추가한 데이터를 반환한다.
            public T Peek()
            {
                if (size == 0)
                    return default(T); // 기본값 반환
                return array[size - 1];
            }
            //Clear() : 배열 내의 모든 데이터를 삭제한다.
            public void Clear()
            {
                size = 0;
            }


        }


        static void Main(string[] args)
        {
            MyStack<int> stack = new MyStack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            Console.WriteLine(stack.Pop()); // 30
            Console.WriteLine(stack.Peek()); // 20
            stack.Clear();
        }
    }
}
