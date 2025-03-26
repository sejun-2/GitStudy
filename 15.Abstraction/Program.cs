namespace _15.Abstraction
{
    internal class Program
    {
        /*
        추상화(Abstraction)
         클래스를 정의할 당시 구체화 시킬 수 없는 기능을 추상적 표현으로 정의

         추상 클래스(Abstract Class)
         하나 이상의 추상 메서드를 포함하는 클래스
         클래스가 추상적인 표현을 정의하는 경우, 자식에서 구체화시켜 구현할 것을 염두하고 추상화 시킴.
         추상클래스에서 내용을 구체화 할 수 없는 추상함수는 내용을 정의하지 않음.
         추상클래스를 상속하는 자식클래스가 추상함수를 재정의 하여 구체화한 경우 사용가능.


         <추상화 사용의미1>
         추상클래스를 사용하는 이유는, 추상클래스를 상속받는 클래스가 반드시 구현해야 하는 메서드가 있을 때 사용한다.

         <추상화 사용의미2>
         상위 클래스의 인터페이스를 구현하기 위한 수단으로 사용
         추상적인 기능을 구체화시키지 않은 경우 인스턴스 생성이 불가
         이를 통해 자식클래스에게 추상함수를 구현하도록 강제함.
        */

        public abstract class Item
        {
            public abstract void Use();       // 추상 메서드 -> 자식 클래스에서 반드시 재정의 해야함. (미완성 메서드)
        }

        //public class Item
        //{
        //    public virtual void Use()       // virtual : 자식 클래스에서 재정의 가능 (가상 메서드 -> 재정의 안해도 됨)
        //    {
        //        // 이거 override 해서 아이템맘다 다양한 사용 효과 만들어줘
        //    }
        //}

        public class  Potion : Item
        {
            public override void Use()          // 부모클래스의 abstract 추상메서드를 반드시 재정의 해야함.
            {
                // 포션 사용 효과
                Console.WriteLine("포션을 사용하여 채력을 회복합니다.");
            }
        }

        public class Herb : Item
        {
            public override void Use()
            {
                // 약초 사용 효과
                Console.WriteLine("해독초를 사용하여 독을 회복합니다.");
            }
        }



        static void Main(string[] args)
        {
            Item potion = new Potion();
            potion.Use();

            Item herb = new Herb();
            herb.Use();
        }
    }
}
