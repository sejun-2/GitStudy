namespace _22._3Nullable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Item item = null;

            if (item != null)
            {
                item.Use();
            }

            item = new Item();

            if (item != null)
            {
                item.Use();
            }
            // <Null 조건연산자>
            // ? 앞의 객체가 null 인 경우 null 반환
            // ? 앞의 객체가 null 이 아닌경우 접근
            item?.Use();   // null 이면 안하고 ?이면 한다
        }


        public class Item
        {
            public void Use() { }
        }

        public class Player
        {
            public event Action OnDied;

            public void Use()
            {
                if (OnDied != null) 
                { 
                    OnDied(); 
                }
                OnDied?.Invoke();   // null 이면 안하고 ?이면 한다
            }


        }
    }
}
