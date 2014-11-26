using System;
using System.Collections.Generic;
using System.Collections;

namespace DataStructures
{
	//Simple Linked List Implementation

	public class LLNode<T> :  IComparable<T>, IEquatable<T>
		where T : IComparable<T>, IEquatable<T>
	{
		private T data;
		private LLNode<T> next;

		public LLNode (T _data = default(T), LLNode<T> _next = null)
		{
			data = _data;
			next = _next;
		}

		public LLNode<T> Next {
			get { return next; }
			set { next = value; }
		}

		public T Data 
		{
			get{ return data; }
			set{ data = value; }
		}

		public int IComparable.CompareTo(object otherNode)
		{
			LLNode<T> other = (LLNode<T>)otherNode;

			if (this.Data > other.Data)
				return 1;
			else if (this.Data < other.Data)
				return -1;
			else
				return 0;
		}
	}



	public class LList<T> : IEnumerable<T>
		where T: IComparable<T>, IEquatable<T>
	{
		private int length;
		private LLNode<T> head, tail;


		public LList ( LLNode<T> _head = new LLNode<T>(), LLNode<T> _tail = null)
		{
			head = _head;
			LLNode<T> last = head;

			while (head.Next != null) { 
				last = head.Next; 
			}

			if (_tail == null) {
				tail = new LLNode<T> ();
				last.Next = tail;
			}
			else {
				last.Next = _tail;

				while (_tail.Next != null)
					_tail = _tail.Next;

				tail = _tail;
			}
		}


		public LLNode<T> Head 
		{
			get { return head; }

			set { 
				if (value != null) {
					value.Next = head.Next;
					head = value; 
				} 
				else
					throw new NullReferenceException();
			}
		}

		public LLNode<T> Tail 
		{
			get { return tail; }
		}

		public int Length 
		{
			get{ return length; }
		}
			
		public LLNode<T> this[int index]
		{
			get { return this.GetNode (index); }
			set { this.GetNode(index).Data = value; }
		}


		public bool Append( params T[] newValues)
		{
			foreach(T val in newValues)
			{
				tail.Next = new LLNode<T> (val);
				tail = tail.Next;
			}

			length += newValues.Length;

			return true;
		}

		public bool Prepend( params T[] newValues)
		{
			LLNode<T> first = new LLNode<T> (newValues [0]);
			LLNode<T> current = first;

			foreach(T val in newValues)
			{
				tail.Next = new LLNode<T> (val);
				tail = tail.Next;
			} 

			current.Next = head;
			head = first;
			length += newValues.Length;
			return true;
		}

		public bool Remove( params int[] indices)
		{
			var sortedIndices = from i in indices
					where ValidIndex (i)
				orderby i ascending
				select i;

			int currentIndex = 0;
			LLNode<T> currentNode = head;
			LLNode<T> predecessor = null;

			foreach (int index in indices) {
				while(currentIndex < index && currentNode != null) {
					currentNode = currentNode.Next;
					currentIndex++;
				}
			}
		}

		private bool ValidIndex(int index)
		{
			if( index >= 0 && index < length)
				return true;
			else 
				return false;
		}

		public LLNode<T> GetNode(int index)
		{
			if (!ValidIndex)
				throw new ArgumentOutOfRangeException ();

			int current = 0;
			LLNode<T> currentNode = head;

			while (current < index) {
				currentNode = currentNode.Next;
				current++;
			}

			return currentNode;
		}

		public int IndexOf(T searchValue)
		{

		}

		public bool Contains(T searchValue)
		{

		}
	}



	//Simple DLList implementation
	public class DLLNode<T> : IEquatable<T>, IComparable<T> 
		where T: IEquatable<T>, IComparable<T>
	{
		private T data;
		private DLLNode<T> next;
		private DLLNode<T> predecessor;

		public DLLNode (T _data = default(T), DLLNode<T> _next = null, DLLNode<T> _predecessor = null)
		{
			data = _data;
			next = _next;
			predecessor = _predecessor;
		}

		public DLLNode<T> Next {
			get { return next; }
			set { next = value; }
		}

		public DLLNode<T> Predecessor {
			get { return predecessor; }
			set { predecessor = value; }
		}

		public T Data 
		{
			get{ return data; }
			set{ data = value; }
		}

		public int IComparable.CompareTo(object otherNode)
		{
			DLLNode<T> other = (DLLNode<T>)otherNode;

			if (this.Data > other.Data)
				return 1;
			else if (this.Data < other.Data)
				return -1;
			else
				return 0;
		}
	}

	public class DLList : IEnumerable
	{


	}


	public class ASortedList<T>
	{}


}

