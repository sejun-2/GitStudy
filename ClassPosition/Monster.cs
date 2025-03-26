using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPosition
{
    public class Monster
    {
        public int hp = 20;
        public void TakeHit(int damage)
        {
            hp -= damage;
        }
    }
}
