using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Datastructure

{
	public class List<T> // <T>는 일반화란 뜻
	{
		private const int DefaultCapacity = 4;

		private T[] items; // 배열 생성
		private int count; // 

		public List()
		{
			count = 0;
			items = new T[4];  // 이런 안바뀌는 값을 상수로 하는겨
		}

		public List(int capacity)
		{
			items = new T[capacity];
			count = 0;
		}



		public int Capacity { get { return items.Length; } } //몇개 들고 있는지, Length 자체가 Capacity 임

		public int Count { get { return count; } }

		public bool IsFull {  get { return count == items.Length; } }

		public T this[int index] //접근
		{
			get 
			{
				return items[index];
			}
			set
			{
				items[index] = value;
			}
		}
		public void Add(T item)
		{
			if (count == items.Length) // 가득 차 있을때
				// if (Isfull)
				Grow();

			items[count++] = item;

		}

		public void Insert(int index, T item)
		{

			// 예외처리 필요 : 크기를 벗어나게 중간에 끼워넣는것은 불가능
			if (index < 0 || index > count)
				throw new ArgumentOutOfRangeException("index");// 뭔가 했더니 예외처리 용도

			if (IsFull)
				Grow();

			Array.Copy(items, index, items, index + 1, count - index);

			items[index] = item;
			count++;
		}


		public bool Remove(T item)
		{
			int index = IndexOf(item);
			if (index < 0)
			{
				RemoveAt(index);
				return true;
			}
			else
			{
				return false;
			}
		}
		// 코드 재사용의 좋은 예시

		public void RemoveAt(int index)
		{
			// 여기도 예외처리 필요 : 크기를 벗어나게 중간에 빼는것 불가
			if (index < 0 || index >= count)
				throw new ArgumentOutOfRangeException("index");// 뭔가 했더니 예외처리 용도, throw 한거 main 에서 예외처리 해줘야함 안그럼 예외처리 안됨 뜸
			count--;
			Array.Copy(items, index + 1, items, index, count - index);

		}
		public int IndexOf(T item)
		{
			for (int i = 0; i < count; i++)
			{
				if (item.Equals(items[i]))
				{
					return i;

				}
			}

			return -1;
		}



		private void Grow()
		{
			// 2. 더 큰 배열 형성
			T[] newItems = new T[items.Length * 2];
			// 3. 새로운 배열에 기존의 데이터 복사
			Array.Copy(items, newItems, items.Length);

			//for (int i = 0; i < items.Length; i++)
			//{
			//	newItems[i] = items[i];
			//}
			// 위 수식은 위의 한줄이랑 같은말


			// 4. 기본 배열 대신 새로운 배열을 사용

			items = newItems; // 얕은복사?


			// 5. 빈공간에 데이터 추가



		}
	}
}


