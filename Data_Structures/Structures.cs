using System;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Collections;
using System.CodeDom;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Dynamic;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;

namespace DataStructures
{
	#region
	public interface DynamicArray<T> 
	{
		void Add (T newVal);
		void Remove (int index);
		bool Contains (T val);
	}

	public class DynamicArraySimple<T> : IEnumerable<T>, DynamicArray<T>
		where T : IComparable<T>, IEquatable<T>
	{
		private T[] data;
		private int capacity;

		public DynamicArraySimple (int _capacity = 512)
		{
			data = new T[_capacity];
			capacity = _capacity;
		}

		public DynamicArraySimple (DynamicArraySimple<T> toCopy)
		{
			data = new T[toCopy.Capacity];
			capacity = toCopy.Capacity;

			for( int i =0; i < toCopy.Length; i++ )
			{
				data[i] = toCopy[i];
			}
		}
			
		public int Capacity
		{
			get{ return capacity;}
		}

		public int Length
		{
			get { return data.Length; }
		}

		public T this [int index] 
		{
			get { return data[index]; }
			set { data [index] = value; }
		}


		public void Add (params T[] newValues)
		{
			if (data.Length >= capacity) {
				T _data = new T[2 * capacity];

				for (int i = 0; i < capacity; i++) {
					_data [i] = data [i];
				}

				data = _data;
			} 
				
			foreach (T i in newValues) {
				data [data.Length] = i;
			}
		}

		//we shall improve upon this in DynamicArray Component so it's no longer O(n) time
		public void Remove (params int[] indices)
		{
			T[] _data = new T[capacity];

			for( int i = 0; i < data.Length; i++) 
			{
				if(i in indices)
			}
		}
			
		public static DynamicArraySimple<int> IntRange (int start = 1, int end = 512, int step = 1)
		{
			int element_count = (end - start) / step;

			DynamicArraySimple<int> ret = new DynamicArraySimple<int> (count);
			for (int i = start; i < end; i += step) {
			
			
			}

		}


		public override string ToString ()
		{
			return string.Format ("Capacity: {0} Length: {1}]", capacity, count);
		}
	}
	#endregion






	public class DynamicArrayComponent<T> : IEnumerable<T>
		where T : IComparable<T>, IEquatable<T>
	{
		private DynamicArraySimple<T> dataComponents;
		private int capacity;
		private int subCapacity;

		public DynamicArrayComponent(int _capacity = 512, int _subCapacity = 16)
		{
			capacity = _capacity;
			subCapacity = _subCapacity;

			int divCap = capacity / subCapacity;
			int numComponents =  (divCap > 0) ? divCap + 1 : divCap; 

			dataComponents = new DynamicArraySimple<T>[numComponents];

			foreach (DynamicArraySimple<T> das in dataComponents) 
			{
				das = new DynamicArraySimple<T>[subCapacity];
			}
		}
			

		public DynamicArrayComponent (DynamicArraySimple<T> toCopy)
		{
			throw new NotSupportedException();
		}

		public T this [int index] {
			get { return data [index]; }
			set { data [index] = value; }
		}

		public void Add (params T[] newValues)
		{
			if (data.Length >= capacity) {
				T _data = new T[2 * capacity];

				for (int i = 0; i < capacity; i++) {
					_data [i] = data [i];
				}

				data = _data;
			} 


			foreach (T i in newValues) {
				data [data.Length] = i;
			}
		}

		//we do not definite a remove because it is a costly method
		//instead we will create a new more faster Dynamic Array
		public void Remove (params int[] indices)
		{
			throw new NotImplementedException ();
		}

	

		public override string ToString ()
		{
			return string.Format ("Capacity: {0} Length: {1}]", capacity, count);
		}

		public static DynamicArraySimple<int> IntRange (int start = 1, int end = 512, int step = 1)
		{
			int element_count = (end - start) / step;

			DynamicArraySimple<int> ret = new DynamicArraySimple<int> (count);
			for (int i = start; i < end; i += step) {


			}

		}
	}


	//Simple Linked List Implementation

	public class LLNode<T> :  IComparable<T>, IEquatable<T>
			where T : IComparable<T>, IEquatable<T>
	{
		private T data;
		private LLNode<T> next;

		public LLNode (T _data = default(T), LLNode<T> _next = null)
		{
			data = _data;
			next = _data;
		}

		public LLNode<T> Next {
			get { return next; }
			set { next = value; }
		}

		public T Data {
			get{ return data; }
			set{ data = value; }
		}
	}

	public class LList<T> : IEnumerable
			where T: IComparable<T>, IEquatable<T>
	{

		private int length;
		private LLNode<T> head;

		public LList ( LLNode<T> _head = new LLNode<T>())
		{
			head = _head;
		}

		public LList ()

		public LLNode<T> Head 
		{
			get { return head; }

			set { 
				if (value != null) {
					head = value; 
				} 
				else
					throw new NullReferenceException();
			}
		}

		public int Length 
		{
			get{ return length; }
		}
	}






	//Simple DLList implementation
	public class DLLNode<T> : IEquatable<T>, IComparable<T> 
		where T: IEquatable<T>, IComparable<T>
	{

	}
	public class DLList : IEnumerable
	{

	}





	public class BinaryTree
	{

	}

	public class RedBlackTree
	{

	}


	public clas



}
