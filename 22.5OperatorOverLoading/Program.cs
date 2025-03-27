namespace _22._5OperatorOverLoading
{
    internal class Program
    {
        /**********************************************************************
        * 연산자 재정의 (Operator Overloading)
        *
        * 사용자정의 자료형이나 클래스의 연산자를 재정의하여 여러 의미로 사용
        **********************************************************************/

        // <연산자 재정의>
        // 기본연산자의 연산을 함수로 재정의하여 기능을 구현
        // 기본연산자를 호환하지 않는 사용자정의 자료형에 기본연산자 사용을 구현함


        public struct Position
        {
            public int x;
            public int y;

            public static Position operator +(Position left, Position right)
            {
                int x = left.x + right.x;
                int y = left.y + right.y;
                return new Position() { x=x, y=y };
            }
        }


        static void Main(string[] args)
        {
            Position pos1 = new Position() {x=1,y=2 };
            Position pos2 = new Position() {x=3,y=4 };

            Position sumPos = pos1 + pos2;
            

        }
    }
}
