using System.Drawing;

namespace _0331.Practice2
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            // 다음의 조건에 부합하는 가중치 그래프를 구현하시오.
            int[,] graph0 = new int[8, 8];

            // 노드와 노드를 잇는 간선 생성 시, 간선은 반드시 가중치를 지녀야 한다
            // 가중치는 음수를 제외한 실수여야 한다.
            graph0[0, 1] = 10;
            graph0[0, 2] = 11;
            graph0[0, 4] = 12;
            graph0[1, 5] = 13;
            graph0[1, 6] = 14;
            graph0[2, 4] = 15;
            graph0[3, 1] = 16;
            graph0[3, 5] = 17;
            graph0[4, 2] = 18;
            graph0[5, 3] = 19;
            graph0[5, 6] = 20;
            graph0[6, 2] = 21;
            graph0[6, 5] = 22;
            graph0[6, 7] = 23;

            for (int i=0; i< graph0.GetLength(0); i++)
            {
                for (int j=0; j< graph0.GetLength(1); j++)
                {
                    if (graph0[i,j] != 0)
                    {
                        //그래프의 내용 출력 시 각 노드는 다음와 같은 내용으로 인접한 노드들을 출력해야 한다
                        Console.WriteLine("graph{0}노드 : - graph{1}노드, 가중치 {2}", i,j,graph0[i, j]);
                    }
                    
                }
                
            }

        }
    }
}
