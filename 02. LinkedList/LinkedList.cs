using System.Collections.Generic;
using System.ComponentModel.Design;

namespace Code_test
{
	public class LinkedListNode<T>
	{
		internal LinkedList<T> list;
		internal LinkedListNode<T> prev;
		internal LinkedListNode<T> next;
		private T value;

		public LinkedListNode(T value)
		{
			this.list = null;
			this.prev = null;
			this.next = null;
			this.value = value;
		}

		public LinkedListNode(LinkedList<T> list, T value)
		{
			this.list = list;
			this.prev = null;
			this.next = null;
			this.value = value;
		}

		public LinkedListNode(LinkedList<T> list, LinkedListNode<T> prev, LinkedListNode<T> next, T value)
		{
			this.list = list;
			this.prev = prev;
			this.next = next;
			this.value = value;
		}

		public LinkedList<T> List { get { return list; } }
		public LinkedListNode<T> Prev { get { return prev; } }
		public LinkedListNode<T> Next { get { return next; } }

		public T Value { get { return value; } set { this.value = value; } }
	}

	public class LinkedList<T>
	{
		private LinkedListNode<T> head;
		private LinkedListNode<T> tail;
		private int count;

		public LinkedList()
		{
			this.head = null;
			this.tail = null;
			count = 0;
		}

		public LinkedListNode<T> First { get { return head; } }
		public LinkedListNode<T> Last { get { return tail; } }
		public int Count { get { return count; } }

		public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
		{
			LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);
			InsertNodeBefore(node, newNode);
			return newNode;
		}

		public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value)
		{
			LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);
			InsertNodeAfter(node, newNode);
			return newNode;
		}

		public LinkedListNode<T> AddFirst(T value)
		{
			LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);
			if (head != null)
			{
				InsertNodeBefore(head, newNode);
			}
			else
			{
				InsertNodeToEmptyList(newNode);
			}
			return newNode;
		}

		public LinkedListNode<T> AddLast(T value)
		{
			LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);
			if (tail != null)
			{
				InsertNodeAfter(tail, newNode);
			}
			else
			{
				InsertNodeToEmptyList(newNode);
			}
			return newNode;
		}

		public void Clear()
		{
			head = null;
			tail = null;
			count = 0;
		}

		public bool Remove(T value)
		{
			LinkedListNode<T> node = Find(value);
			if (node != null)
			{
				RemoveNode(node);
				return true;
			}
			else
			{
				return false;
			}
		}

		public void Remove(LinkedListNode<T> node)
		{
			RemoveNode(node);
		}

		public void RemoveFirst()
		{
			RemoveNode(head);
		}

		public void RemoveLast()
		{
			RemoveNode(tail);
		}

		public LinkedListNode<T> Find(T value)
		{
			LinkedListNode<T> node = head;
			if (value == null)
			{
				while (node != null)
				{
					if (null == node.Value)
						return node;
					else
						node = node.next;
				}
			}
			else
			{
				while (node != null)
				{
					if (value.Equals(node.Value))
						return node;
					else
						node = node.next;
				}
			}

			return null;
		}

		private void InsertNodeBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
		{
			LinkedListNode<T> prevNode = node.prev;
			// 1. newNode 의 prev를 node 의 prev로
			newNode.prev = prevNode;

			// 2. newNode 의 next는 node로
			newNode.next = node;

			// 3. node 의 prev유무에 따른
			if (node == head) // 3-1 head를 newNode로
			{
				head = newNode;
			}
			else // 3-2 node 의 prev의 next를 newNode로
			{
				prevNode.next = newNode;
			}


			// 4. node 의 prev 를 newNode로
			node.prev = newNode;

			count++;
		}

		private void InsertNodeAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
		{
			LinkedListNode<T> nextNode = node.next;

			//2. newNode 의 prev를 node로
			newNode.prev = node;
			//3. newNode의 next 를 nextNode로
			newNode.next = nextNode;

			//1. nextNode 의 prev 유무에 따라
			if (node == tail) // newnode 를 tail로
			{
				tail = newNode;
			}
			else // nextnode의 prev를 newNode로
			{
				nextNode.prev = newNode;
			}
			//4. node 의 next 를 newNode로
			node.next = newNode;

			count++;
		}

		private void InsertNodeToEmptyList(LinkedListNode<T> newNode)
		{
			if (count != 0)
				throw new InvalidOperationException();

			head = newNode;
			tail = newNode;
			count++;
		}

		private void RemoveNode(LinkedListNode<T> node)
		{
			if (node == null)
				throw new ArgumentNullException();
			if (node.list != this)
				throw new InvalidOperationException();

			if (head == node)
				head = node.next;
			if (tail == node)
				tail = node.prev;

			if (node.prev != null)
				node.prev.next = node.next;
			if (node.next != null)
				node.next.prev = node.prev;

			count--;
		}
	}
}
