using System.Drawing;

namespace _0331.Practice2
{
    internal class Program
    {
       

        static void Main(string[] args)
        {
            int size = 10;
            const int INF = int.MaxValue;
            // 예시 - 단방향 가중치 그래프 (단절은 최대값으로 표현) INF
            int[,] matrixGraph = new int[5, 5]
            {
            {   0, 132, INF, INF,  16 },
            {  12,   0, INF, INF, INF },
            { INF,  38,   0, INF, INF },
            { INF,  12, INF,   0,  54 },
            { INF, INF, INF, INF,   0 },
            };

            // [0,2] => 출발정점(0) -> 도착정점(2)
            int distance = matrixGraph[0, 2];   // 0에서 2까지 가중치
            matrixGraph[0, 2] = 10;           // 가중치 변경. 


            for (int i = 0; i < size; i++)
            {
                Console.Write($"{matrixGraph} 노드 : ");
                for (int j = 0; j < size; j++)
                {
                    if (matrixGraph[i, j] != INF && i != j)
                    {
                        Console.Write($"- {j} 노드, 가중치 {matrixGraph[i, j]} ");
                    }
                }
                Console.WriteLine();
            }

        }
    }
}
