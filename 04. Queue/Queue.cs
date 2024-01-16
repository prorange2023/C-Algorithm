using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04._Queue
{
	// 순환큐 뭐냐, 왜 쓰느냐 묻는 경우 있음.
	public class Queue<T>
	{
		private const int DefaultCapacity = 4;


		private T[] array;
		private int head;
		private int tail;
		private int count;

		public Queue()
		{
			array = new T[DefaultCapacity];
			head = 0;
			tail = 0;
			count = 0;
		}

		public void Enqueue(T item)
		{
			if (IsFull())
			{
				Grow();
			}
			array[tail] = item;
			tail = (tail + 1) % array.Length; // 아래꺼 압축표현, 마지막칸에 있으면 맨처음으로 보내야한다는 뜻
			//if (tail ==array.Length)
			//{
			//	tail = 0;
			//}

			count++;

		}

		public T Dequeue()
		{
			//if (count > 0)
			//{
			//	Console.WriteLine("꺼낼수 없습니다.");
			//	return;
			//}
			if (count == 0)
				throw new InvalidOperationException();
			
			T item = array[head];
			head++;

			if (head == array.Length)
			{
				head = 0;
			}

			count--;
			return item;
		}

		public bool IsFull()
		{
			if (head>tail)

			{
				return head == tail + 1;
			}
			else
			{
				return head == 0 && tail == array.Length - 1;
			}
			
		}

		private bool IsEmpty()
		{
			return head == tail;
		}

		private void MoveNext(ref int index)
		{
			index = (index + 1) % array.Length;
		}
		private void Grow()

			// 길이 빼기 head 하면 
		{
			T[] newArray = new T[array.Length * 2];
			if (head< tail)
			{
				Array.Copy(array, head, newArray, 0, tail);
			}
			else
			{
				Array.Copy(array, head, newArray, 0, array.Length - head);
				Array.Copy(array, 0, newArray, array.Length - head, tail);
			}
			array = newArray;
			head = 0;
			tail = count;
		}

		public T Peek()
		{
			if (IsEmpty())
				throw new InvalidOperationException();

			return array[head];
		}
		public int Count
		{
			get
			{
				if (head <= tail)
					return tail - head;
				else
					return tail + (array.Length - head);
			}
		}

		public void Clear()
		{
			array = new T[DefaultCapacity];
			head = 0;
			tail = 0;
		}
	}
}
