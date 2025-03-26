using System.Xml.Linq;

namespace CartRider
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Cart cart = new Cart("저스티스");
            Console.WriteLine("{0}가 달립니다.",cart.name);
            cart.boost += 1;
            Console.WriteLine("{0}의 부스트 속도가 {1} 으로 상승합니다.\n", cart.name, cart.boost);

            Cart cart2 = new Cart("피닉스");
            Console.WriteLine("{0}가 달립니다.", cart2.name);

        }
    }
}
