using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._Sorting
{
	internal class Sorting
	{
		// 컴퓨터는 정렬 작업단계를 설정해줘야 한다.


		// <선택정렬>
		// 데이터 중 가장 작은 값부터 하나씩 선택하여 정렬
		// 저장공간을 절약하기 위해 자료 위치를 바꿔주는 것으로 한다.
		// 훑어서 제일작은거 제일 앞자리로 옮기고 고정, 나머지 훑고 제일작은거 제일 앞자리로 옮기고 고정
		// 이걸 반복하는식
		// 시간복잡도 -  O(n²) //반분할을 쓰면 연산 횟수를 줄일 수 있지 않을까?->병합정렬
		// 공간복잡도 -  O(1)
		// 안정정렬   -  O

		public static void SelectionSort(IList/*배열, 정렬 둘다 적용하고 싶을때씀*/<int> list, int start, int end)
		{
			for (int i = start; i <= end; i++/*처음부터 끝까지 훑어야하는 상황*/)
			{
				int minIndex = i;
				for (int j = i + 1; j <= end; j++/*제일 작은걸 찾아야하는상황*/)
				{
					if (list[j] < list[minIndex])
					{
						minIndex = j;
					}
				}
				Swap(list/*리스트에서*/, i/*i번째 꺼랑*/, minIndex/*minIndex에 있는걸 교환*/);
			}
		}



		// <삽입정렬>
		// 데이터를 하나씩 꺼내어 정렬된 자료 중 적합한 위치에 삽입하여 정렬
		// 인간이 무의식적으로 정렬하면 하는 정렬이라는 말도 있음
		// 처음부터 쓰면서 끼워넣는식
		// 정렬된 자료중 적합한 위치에 삽입한다.
		// 맨앞을 일단 지정하고 정렬된 데이터들 중 내위치다 싶은 곳에 집어넣는다.
		// 삽입시 데이터는 뒤로 한칸씩 밀림
		// 시간복잡도 -  O(n²)
		// 공간복잡도 -  O(1)
		// 안정정렬   -  O
		public static void InsertionSort(IList<int> list, int start, int end)
		{
			for (int i = start + 1; i <= end; i++)
			{
				for (int j = i; j >= 1; j--)
				{	
					if (list[j - 1] < list[j]/*내가 작아지는 타이밍찾아서*/)
					{
						break;/*작지 않으면 브레이크*/
					}
					// 작으면 교체
					Swap(list, j - 1, j);
				}
			}
		}



		// <버블정렬> 버블인 이유? 제일 큰값이 제일 뒤로 간다.뒤쪽부터 차곡차곡 떠오르듯이 정렬된다해서 버블
		// 서로 인접한 데이터를 비교하여 정렬
		// 코테 같은데 가면 버블정렬 정도는 구현해주세요 하는 경우 많음
		// 시간복잡도 -  O(n²)
		// 공간복잡도 -  O(1)
		// 안정정렬   -  O
		public static void BubbleSort(IList<int> list, int start, int end)
		{
			for (int i = start; i < end; i++)
			{
				for (int j = 0; j < end - start; j++) // end = list.Count, start = 0에서 시작해 점증.
				{
					if (list[j] > list[j + 1])/*인접한거 두개 배교했을때 앞게 전보다 클때*/
					{
						Swap(list, j, j + 1);/*교체해줌*/
					}
				}
			}
		}



		// <병합정렬>
		// 데이터를 2분할하여 정렬 후 합병 // 위의 연산횟수를 줄여볼수 있는가 하는 시도의 결과, 메인컨셉
		// 단점 데이터 갯수만큼의 추가적인 메모리가 필요
		// 단점 공간복잡도
		// 시간복잡도 -  O(nlogn)
		// 공간복잡도 -  O(n)
		// 안정정렬   -  O
		public static void MergeSort(IList<int> list, int start, int end)
		{
			if (start == end)//하나면
			{
				return;//정렬 안함
			}

			int mid = (start + end) / 2; // 중간위치를 구해서
			MergeSort(list, start, mid); // 반절 병합정렬
			MergeSort(list, mid + 1, end); // 반절 병합정렬
			Merge(list, start, mid, end); // 병합
		}

		private static void Merge(IList<int> list, int start, int mid, int end) // 병합함수
			// 맨앞자료끼리 비교해서 작은걸 앞에 붙이고
			// 그다음 제일 작은것끼리 비교해서 앞에 붙이고 이런식
		{
			List<int> sortedList = new List<int>();
			int leftIndex = start;
			int rightIndex = mid + 1; // 왜 미드 +1이더라

			// 분할 정렬된 List를 병합
			while (leftIndex <= mid/*왼쪽배열이 모두 비고*/ && rightIndex <= end/*오른쪽 배열이 모두 비고*/)
			{
				if (list[leftIndex] < list[rightIndex])
				{
					sortedList.Add(list[leftIndex++]);
				}
				else
				{
					sortedList.Add(list[rightIndex++]);
				}
			}

			if (leftIndex > mid/*왼쪽이 다 비워진 경우*/)
			{
				for (int i = rightIndex; i <= end; i++)
				{
					sortedList.Add(list[i]);
				}
			}
			else
			{
				for (int i = leftIndex; i <= mid; i++)
				{
					sortedList.Add(list[i]);
				}
			}

			for (int i = 0; i < sortedList.Count; i++)// 정렬된 리스트를 원래 리스트로 이동
			{
				list[start + i] = sortedList[i];
			}
		}



		// <퀵정렬>
		// 하나의 피벗을 기준으로 작은값과 큰값을 2분할하여 정렬
		// 병합정렬보다 공간복잡도를 줄이고 속도를 올릴수 없을까 하는 고민에서 나온것
		// 맨 앞 값을 피벗으로 선정.제외한 나머지 자료좌표중 왼쪽은 left 오른쪽은 right 로지정
		// left(좌표값, 데이터아님) 피벗보다 큰값을 만날때까지 오른쪽행
		// right 는 피벗보다 작은값만날때까지 좌행
		// 둘다 멈추면 두 좌표의 데이터 교환
		// 반복
		// left 랑 right 엇갈리면 그 순간 스톱, 반분할해서 반복
		// 하나의 데이터가 반절의 데이터만 봐도 된다는게 장점

		// 최악의 경우(피벗이 최소값 또는 최대값)인 경우 시간복잡도가 O(n²)
		// 피벗이 최대값이나 최소값으로 선정되는경우가 최악.
		// 시간복잡도 -  평균 : O(nlogn)   최악 : O(n²)
		// 공간복잡도 -  O(1)- 추가적공간을 필요로하지 않는다
		// 안정정렬   -  X
		public static void QuickSort(IList<int> list, int start, int end)
		{
			if (start >= end) return;

			int pivot = start;
			int left = pivot + 1;
			int right = end;

			while (left <= right)
			{
				while (list[left] <= list[pivot] && left < right)
				{
					left++;
				}
				while (list[right] > list[pivot] && left <= right)
				{
					right--;
				}

				if (left < right) // 둘이 아직 엇갈리지 않았다면
				{
					Swap(list, left, right);
				}
				else 
				{
					Swap(list, pivot, right);//피벗을 중간으로 가져오기 위한 행동
					break;
				}
			}

			QuickSort(list, start, right - 1); // 피벗기준 왼쪽 데이터들끼리 퀵정렬
			QuickSort(list, right + 1, end); // 피벗기준 오른쪽 데이터들끼리 퀵정렬
		}



		// <힙정렬>
		// 힙을 이용하여 우선순위가 가장 높은 요소가 가장 마지막 요소와 교체된 후 제거되는 방법을 이용
		// 배열에서 연속적인 데이터를 사용하지 않기 때문에 캐시 메모리를 효율적으로 사용할 수 없어 상대적으로 느림
		// 이론적으론 이게 퀵보다 빨라야 하는데 현실은 퀵이 더 빠름
		// 이유 : 레지스트리 친화도가 낮음. 캐시적중률 낮음
		// 퀵은 연속적 메모리사용을 하게 되는데 연속적으로 메모리를 쓸수록 캐시적중률이 높다.
		// 힙은? 기본적으로 배열에 저장하기때문에 한꺼번에 메모리에 저장하는게 안됨. 왔다갔다가 많음. 그래서 힙이 더 느림

		// 그럼 C#은 어떻게 정렬을 돌림?
		
		// 시간복잡도 -  O(nlogn) 
		// 공간복잡도 -  O(1) //안정적, 언제든 성능 괜찮
		// 안정정렬   -  X
		public static void HeapSort(IList<int> list)
		{
			for (int i = list.Count / 2 - 1; i >= 0; i--)
			{
				Heapify(list, i, list.Count);
			}

			for (int i = list.Count - 1; i > 0; i--)
			{
				Swap(list, 0, i);
				Heapify(list, 0, i);
			}
		}

		private static void Heapify(IList<int> list, int index, int size)
		{
			int left = index * 2 + 1;
			int right = index * 2 + 2;
			int max = index;
			if (left < size && list[left] > list[max])
			{
				max = left;
			}
			if (right < size && list[right] > list[max])
			{
				max = right;
			}

			if (max != index)
			{
				Swap(list, index, max);
				Heapify(list, max, size);
			}
		}


		private static void Swap(IList<int> list, int left, int right)
		{
			int temp = list[left];//임시저장소
			list[left] = list[right];//왼쪽위치에 있는값을 오른쪽 위치에 있는 값으로
			list[right] = temp;//오른쪽위치의 값은 임시저장소에넣어놨던걸로 복원
		}

	}
}
