using System;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Collections;
using System.CodeDom;

namespace DataStructures
{
	class DynamicArraySimple<T> : IEnumerable<T>
		where T : IComparable<T>, IEquatable<T>
	{
		T data;
		private int capacity;
		private int count = 0; 

		public DynamicArray() 
		{
			data = new T[512];
			capacity = 512;
		}

		public DynamicArray(int _capacity)
		{
			data = new T[_capacity];
			capacity = _capacity;
		}

		public T this[int index]
		{
			get { return data [index]; }
			set { data [index] = value; }
		}

		public void Add(params T[] newValues)
		{
			if (count >= capacity) {
				T _data = new T[2 * capacity];

				for (int i = 0; i < capacity; i++) 
				{
					_data [i] = data [i];
				}
			} 

			data = _data;

			foreach (T i in newValues) 
			{
				data [count] = i;
				count++;
			}
		}

		public void Remove( params int[] indices)
		{

		}

		public void Swap(int index1, int index2)
		{
			T temp = data [index1];
			data [index1] = data [index2];
			data [index2] = temp;
		}
	}



	class LList : IEnumerable
	{
		
	}
}
