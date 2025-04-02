using System.Diagnostics;

namespace _32.Sorting
{
    internal class Program
    {
        //<선택정렬>    -> 느릴수 있으나 16개 이하에서는 오히려 더 빠름
        // 데이터 중 가장 작은 값부터 하나씩 선택하여 정렬
        // 시간복잡도 -  O(n²)
        // 공간복잡도 -  O(1)
        // 불안정정렬
        public static void SelectionSort(int[] array)
        {
            for (int i=0; i<array.Length; i++)// 배열의 첫 번째 요소부터 마지막까지 반복
            {
                int minIndex = i; // 현재 위치를 최소값의 인덱스로 설정
                for (int j=0; j<array.Length; j++)
                {
                    if (array[j] < array[minIndex]) // 더 작은 값이 발견되면 최소값 인덱스를 갱신
                    {
                        minIndex = j;
                    }
                }
                Swep(array, i, minIndex);// 현재 위치와 최소값 위치를 교환
            }
        }


        // <삽입정렬>
        // 데이터를 하나씩 꺼내어 정렬된 자료 중 적합한 위치에 삽입하여 정렬
        // 시간복잡도 -  O(n²)
        // 공간복잡도 -  O(1)
        // 안정정렬   -  O
        public static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)    // 두 번째 요소부터 시작 -> 맨 처음칸은 정렬될 장소이기 때문 필요없음
            {
                for (int j = i; j > 0; j--)     // 현재 요소를 정렬된 부분과 비교하며 적합한 위치로 이동
                {
                    if (array[j - 1] > array[j])  // 다음숫자를 하나씩 꺼내서 앞의 요소가 더 큰지 비교
                    {
                        Swep(array, j - 1, j);   // 앞 숫자와 비교해서 더 작으면 한칸 뒤로 밀고
                    }
                    else
                    {
                        break;                  // 적합한 위치를 찾으면 종료
                    }
                }
            }
        }


        // <버블정렬>   -> 인덱스 사용이 불가능 할때 사용가능
        // 서로 인접한 데이터를 비교하여 정렬
        // 시간복잡도 -  O(n²)
        // 공간복잡도 -  O(1)
        // 안정정렬   -  O
        public static void BubbleSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)  // 처음부터 끝까지 여러 번 스캔
            {
                for (int j = 0; j < array.Length - i; j++)  // 인접한 두 요소를 비교
                {
                    if (array[j] > array[j + 1])    // 서로 인접한 두 데이터의 앞의 요소가 더 크면
                    {
                        Swep(array, j, j + 1);  // 교환
                    }
                }
            }
        }


        // <병합정렬>
        // 데이터를 2분할하여 정렬 후 합병
        // 데이터 갯수만큼의 추가적인 메모리가 필요
        // 시간복잡도 -  O(nlogn)
        // 공간복잡도 -  O(n)
        // 안정정렬   -  O
        public static void MergeSort(int[] array) => MergeSort(array, 0, array.Length - 1);
        public static void MergeSort(int[] array, int start, int end)
        {
            if (start == end)   // 배열이 하나의 요소만 남으면 반환
                return;

            int mid = (start + end) / 2;
            MergeSort(array, start, mid);   // 왼쪽 부분 정렬
            MergeSort(array, mid + 1, end);  // 오른쪽 부분 정렬
            Merge(array, start, mid, end);  // 두 부분 병합
        }

        public static void Merge(int[] array, int start, int mid, int end)
        {
            List<int> sortedList = new List<int>();
            int leftIndex = start;
            int rightIndex = mid + 1;

            while (leftIndex <= mid && rightIndex <= end)
            {
                if (array[leftIndex] < array[rightIndex])
                {
                    sortedList.Add(array[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    sortedList.Add(array[rightIndex]);
                    rightIndex++;
                }
            }

            if (leftIndex <= mid)
            {
                while (leftIndex <= mid)
                {
                    sortedList.Add(array[leftIndex]);
                    leftIndex++;
                }
            }
            else // if (rightIndex <= end)
            {
                while (rightIndex <= end)
                {
                    sortedList.Add(array[rightIndex]);
                    rightIndex++;
                }
            }

            for (int i = 0; i < sortedList.Count; i++)
            {
                array[start + i] = sortedList[i];
            }
        }


        // <퀵정렬>
        // 하나의 기준(피벗)을 기준으로 작은값과 큰값을 2분할하여 정렬
        // 최악의 경우(피벗이 최소값 또는 최대값)인 경우 시간복잡도가 O(n²)
        // 시간복잡도 -  평균 : O(nlogn)   최악 : O(n²)
        // 공간복잡도 -  O(1)
        // 불안정정렬
        public static void QuickSort(int[] array) => QuickSort(array, 0, array.Length - 1);

        public static void QuickSort(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int pivot = start;
            int left = pivot + 1;
            int right = end;

            while (left <= right)   //left와 right가 교차할때까지 반복
            {
                while (array[pivot] >= array[left] && left < right)   // left는 pivot 보다 더 큰값을 볼 떄까지 오른쪽으로 이동;
                {
                    left++;
                }
                while (array[pivot] < array[right] && left <= right)  // right는 pivot보다 더 작은 값을 볼때까지 왼쪽으로 이동;
                {
                    right--;
                }

                if (left < right)   //left와 right가 교차 안했다면
                {
                    Swep(array, left, right);    //left와 right 값을 교체
                }
                else
                {
                    Swep(array, pivot, right);   // 아니라면 pivot과 right를 교체
                    break;
                }
            }

            QuickSort(array, start, right - 1);
            QuickSort(array, right + 1, end);
        }


        // <힙정렬>
        // 힙을 이용하여 우선순위가 가장 높은 요소가 가장 마지막 요소와 교체된 후 제거되는 방법을 이용
        // 배열에서 연속적인 데이터를 사용하지 않기 때문에 캐시 메모리를 효율적으로 사용할 수 없어 상대적으로 느림
        // 시간복잡도 -  O(nlogn)
        // 공간복잡도 -  O(1)
        // 불안정정렬
        public static void HeapSort(int[] array)
        {
            MakeHeap(array);

            for (int i = array.Length - 1; i > 0; i--)
            {
                Swep(array, 0, i);
                Heapify(array, 0, i);
            }
        }

        private static void MakeHeap(int[] array)
        {
            for (int i = array.Length / 2 - 1; i >= 0; i--)
            {
                Heapify(array, i, array.Length);
            }
        }

        private static void Heapify(int[] array, int index, int size)
        {
            int left = index * 2 + 1;
            int right = index * 2 + 2;
            int max = index;
            if (left < size && array[left] > array[max])
            {
                max = left;
            }
            if (right < size && array[right] > array[max])
            {
                max = right;
            }

            if (max != index)
            {
                Swep(array, index, max);
                Heapify(array, max, size);
            }
        }



        static void Main(string[] args)
        {
            int num = 200;
            Console.WriteLine($"{num, 5}");  // 문자 간격 조결. 5 -> 5칸을 가지겠다. 200 이3칸 띄어쓰기2칸 = 5
            Console.WriteLine(num);

            Random random = new Random();
            int count = 100;

            int[] selectArray = new int[count];
            int[] insertArray = new int[count];
            int[] bubbleArray = new int[count];
            int[] mergeArray = new int[count];
            int[] quickArray = new int[count];


            Array.Sort(selectArray);    // c#은 인트로 Sort(정렬)로 되어있다. 하이브리드 정렬. (퀵, 힙, 삽입 정렬로 이루어짐)


            Console.WriteLine("랜덤 데이터: ");
            for (int i = 0; i < count; i++)
            {
                int rand = random.Next(0, 100);     // 0부터 100미만 랜덤한 숫자 생성
                Console.Write($"{rand, 3}");

                selectArray[i] = rand;
                insertArray[i] = rand;
                bubbleArray[i] = rand;
                mergeArray[i] = rand;
                quickArray[i] = rand;
            }
            Console.WriteLine();
            Console.WriteLine();

            SelectionSort(selectArray);
            Console.WriteLine("선택 정렬 결과 : ");
            foreach (int value in selectArray)
            {
                Console.Write($"{value,3}");
            }
            Console.WriteLine();
            
            InsertionSort(insertArray);
            Console.WriteLine("삽입 정렬 결과 : ");
            foreach (int value in insertArray)
            {
                Console.Write($"{value,3}");
            }
            Console.WriteLine();

            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            BubbleSort(bubbleArray);
            sw1.Stop();

            Console.WriteLine("버블 정렬 결과: { 0}", sw1.ElapsedTicks);
            foreach (int value in bubbleArray)
            {
                Console.Write($"{value,3}");
            }
            Console.WriteLine();

            Stopwatch sw2 = new Stopwatch();
            sw2.Start();
            MergeSort(mergeArray);
            sw2.Stop();

            Console.WriteLine("병합 정렬 결과: { 0}", sw2.ElapsedTicks);
            foreach (int value in mergeArray)
            {
                Console.Write($"{value,3}");
            }
            Console.WriteLine();


            QuickSort(quickArray);
            Console.WriteLine("퀵 정렬 결과: ");
            foreach (int value in quickArray)
            {
                Console.Write($"{ value,3}");
            }
            Console.WriteLine();



        }


        public static void Swep(int[] array, int left, int right) 
        { 
            int temp = array[left];
            array[left] = array[right];
            array[right] = temp;
        }

    }
}
