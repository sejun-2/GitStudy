using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartRider
{
    class Cart
    {
        public string name;             // 카트 이름
        public string rank;             // 카트 등급
        public int speed;               // 기본 속도


        public int boost;               // 부스트 속도
        public int drift;               // 드리프트 속도
        public int boostTime;           // 부스트 지속 시간
        public int boostCharge;         // 부스트 충전량
        public int driftHold;           // 드리프트 유지 시간
        public int boostProtection;     // 부스터 게이지 보호
        public int startBooster;        // 스타트 부스터 강화
        public int draftSpeed;          // 드래프트 속도

        public Cart(string name)
        {
            this.name = name;
            switch (name)
            {
                case "저스티스":
                    rank = "고급";
                    speed = 5;
                    boost = 5;
                    drift = 5;
                    boostTime = 6;
                    boostCharge = 6;
                    driftHold = 0;
                    boostProtection = 5;
                    startBooster = 0;
                    draftSpeed = 0;
                    break;
                case "피닉스":
                    rank = "고급";
                    speed = 4;
                    boost = 6;
                    drift = 4;
                    boostTime = 7;
                    boostCharge = 6;
                    driftHold = 0;
                    boostProtection = 5;
                    startBooster = 0;
                    draftSpeed = 0;
                    break;

            }

        }

    }
}
