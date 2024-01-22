namespace _09._Sorting
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Random random = new Random();
			int count = 8;

			List<int> selectionlist = new List<int>();

			List<int> insertionList = new List<int>();

			List<int> bubblelist = new List<int>();

			List<int> mergeList = new List<int>();

			List<int> quickList = new List<int>();

			List<int> introList = new List<int>();

			// C#은 인트로정렬? 하이브리드 정렬 알고리즘임. 기본적으로 퀵정렬을 시도하는데 최악에 근접해지면 힙정렬로 전환한다.
			// 16개 이하일때 왜 섞어쓰냐? 데이터 크기가 16보다 적으면 삽입정렬이 더 빠름
			// 16개는 삽입정렬이면 함수호출 한번이면 되는데 퀵에선 31번해야됨
			// 오버헤드라는것도 있음. 어쩔수 없이 발생하는 컴퓨터의 연산


			Console.WriteLine("랜덤데이터 : ");

			for (int i = 0; i < count; i++)
			{
				int rand = random.Next(0, 100);
				Console.Write($"{rand,3} ");

				selectionlist.Add(rand);
				insertionList.Add(rand);
				bubblelist.Add(rand);
				mergeList.Add(rand);
				quickList.Add(rand);
				introList.Add(rand);


			}

			Console.WriteLine();

			Console.WriteLine("선택정렬 결과 : ");

			Sorting.SelectionSort(selectionlist, 0, selectionlist.Count - 1);

			foreach (int value in selectionlist)
			{
				Console.Write($"{value,3}");
			}





			Console.WriteLine();

			Console.WriteLine("삽입정렬 결과 : ");

			Sorting.InsertionSort(insertionList, 0, insertionList.Count - 1);

			foreach (int value in insertionList)
			{
				Console.Write($"{value,3}");
			}




			Console.WriteLine();

			Console.WriteLine("버블정렬 결과 : ");

			Sorting.BubbleSort(bubblelist, 0, bubblelist.Count - 1);

			foreach (int value in bubblelist)
			{
				Console.Write($"{value,3}");
			}


			

			

			Console.WriteLine();

			Console.WriteLine("병합정렬 결과 : ");

			Sorting.MergeSort(mergeList, 0, mergeList.Count - 1);

			foreach (int value in mergeList)
			{
				Console.Write($"{value,3}");
			}

			

			

			Console.WriteLine();

			Console.WriteLine("퀵정렬 결과 : ");

			Sorting.QuickSort(quickList, 0, quickList.Count - 1);

			foreach (int value in quickList)
			{
				Console.Write($"{value,3}");
			}



			Console.WriteLine();

			Console.WriteLine("인트로 정렬 결과 : ");

			introList.Sort();

			foreach (int value in introList)
			{
				Console.Write($"{value,3}");
			}

			//Random random = new Random();
			//int count = 20;

			//List<int> selectionList = new List<int>(count);
			//List<int> insertionList = new List<int>(count);
			//List<int> bubbleList = new List<int>(count);
			//List<int> mergeList = new List<int>(count);
			//List<int> quickList = new List<int>(count);
			//List<int> heapList = new List<int>(count);
			//List<int> introList = new List<int>(count);

			
			//Console.WriteLine("랜덤 데이터 : ");
			//for (int i = 0; i < count; i++)
			//{
			//	int rand = random.Next() % 100;
			//	Console.Write($"{rand,3}");

			//	selectionList.Add(rand);
			//	insertionList.Add(rand);
			//	bubbleList.Add(rand);
			//	heapList.Add(rand);
			//	mergeList.Add(rand);
			//	quickList.Add(rand);
			//	introList.Add(rand);
			//}
			//Console.WriteLine();


			//Console.WriteLine("선택 정렬 결과 : ");
			//Sorting.SelectionSort(selectionList, 0, mergeList.Count - 1);
			//foreach (int i in selectionList)
			//{
			//	Console.Write($"{i,3}");
			//}
			//Console.WriteLine();


			//Console.WriteLine("삽입 정렬 결과 : ");
			//Sorting.InsertionSort(insertionList, 0, mergeList.Count - 1);
			//foreach (int i in insertionList)
			//{
			//	Console.Write($"{i,3}");
			//}
			//Console.WriteLine();


			//Console.WriteLine("버블 정렬 결과 : ");
			//Sorting.BubbleSort(bubbleList, 0, mergeList.Count - 1);
			//foreach (int i in bubbleList)
			//{
			//	Console.Write($"{i,3}");
			//}
			//Console.WriteLine();


			//Console.WriteLine("합병 정렬 결과 : ");
			//Sorting.MergeSort(mergeList, 0, mergeList.Count - 1);
			//foreach (int i in mergeList)
			//{
			//	Console.Write($"{i,3}");
			//}
			//Console.WriteLine();


			////Console.WriteLine("퀵 정렬 결과 : ");
			//Sorting.QuickSort(quickList, 0, quickList.Count - 1);
			//foreach (int i in quickList)
			//{
			//	Console.Write($"{i,3}");
			//}
			//Console.WriteLine();


			//Console.WriteLine("힙 정렬 결과 : ");
			//Sorting.HeapSort(heapList);
			//foreach (int i in heapList)
			//{
			//	Console.Write($"{i,3}");
			//}
			//Console.WriteLine();


			//Console.WriteLine("C# 인트로 정렬 결과 : ");
			//introList.Sort();
			//foreach (int i in introList)
			//{
			//	Console.Write($"{i,3}");
			//}
			//Console.WriteLine();
		}
	}
}
