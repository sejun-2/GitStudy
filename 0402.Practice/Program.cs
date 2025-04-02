namespace _0402.Practice
{
    internal class Program
    {

        // 선택정렬
        // 데이터중 가장 작은 값부터 하나씩 선택하여 정렬
        public static void SelectSort(int[] array)
        {
            for (int i=0; i<array.Length - 1; i++)  //처음부터 끝까지 쭉 찾기. 마지막 요소는 자동으로 정렬이므로 -1
            {
                int minIndex = i;
                //가장 낮은수 찾기
                for (int j=i+1; j<array.Length; j++)    //j 가 i+1인 이유 : i 다음 수와 비교해야 하기 떄문
                {
                    if (array[minIndex] > array[j])
                    {
                        minIndex = j;
                    }
                   
                }
                //앞에 교체해주기
                 Swap(array, i, minIndex);
            }
        }

        static void Main(string[] args)
        {
            int count = 10;
            Random random = new Random();   // 랜덤 클래스를 쓰겠다 선언.

            int[] selectArray = new int[count]; //배열 선언

            Console.WriteLine("랜덤 데이터: ");
            for (int i = 0; i < count; i++)
            {
                int rand = random.Next(0, 100); // 0부터 100만의 랜덤한 수

                selectArray[i] = rand;  // 랜덤한 수를 selectArray에 차례로 담음.

                Console.Write($"{selectArray[i],3}");
            }
            Console.WriteLine();
            Console.WriteLine();

            SelectSort(selectArray);
            Console.WriteLine("선택 정렬 결과: ");
            foreach (int value in selectArray)
            {
                Console.Write($"{ value,3}");
            }
            Console.WriteLine();



        }
        public static void Swap(int[] array, int left, int rigth)
        {
            int temp = array[left];
            array[left] = array[rigth];
            array[rigth] = temp;
        }
    }
}
