using System;
using System.Collections.Generic;
using System.Collections;

namespace DataStructures
{
	#region
	public interface DynamicArray<T> 
	{
		void Add (T newVal);
		void Remove (int index);
		bool Contains (T val);
	}

	public class DynamicArraySimple<T> : IEnumerable<T>
		where T : IComparable<T>, IEquatable<T>
	{
		private T[] data;
		protected int capacity;

		public DynamicArraySimple (int _capacity = 512)
		{
			if (_capacity < 1)
				throw new ArgumentOutOfRangeException ();
			data = new T[_capacity];
			capacity = _capacity;
		}

		public DynamicArraySimple (DynamicArraySimple<T> toCopy)
		{
			data = new T[toCopy.Capacity];
			capacity = toCopy.Capacity;

			for( int i = 0; i < toCopy.Length; i++ )
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
			get 
			{ 
				if (index < data.Length && index >= 0)
					return data [index];
				else
					throw new IndexOutOfRangeException(); 
			}

			set 
			{ 
				if (index < data.Length && index >= 0)
					return data [index] = value;
				else
					throw new IndexOutOfRangeException(); 
			}
		}



		public void Add (params T[] newValues) 
		{
			int newLength = data.Length + newValues.Length;

			if ( newLength >= capacity) {
				int growthFactor = 2;

				while ( newLength >= growthFactor * capacity)
					growthFactor += 2;

				T _data = new T[growthFactor * capacity];

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
		//for rebuilding. Note that since we have to search, it will always have at least
		//O(n) time for search unless we sort our list.
		public void Remove (params int[] indices) 
		{
			var sortedIndices = from i in indices
					where i >= 0 && i <= data.Length
				orderby i ascending
				select i;
			//int[] sortedIndices = Algorithms.Sorter.QuickSort (indices);

			int relevantIndex = (sortedIndices.Length > 1) ?  1 : -1;
			int toReplace = sortedIndices [0];

			for (int i = sortedIndices [0]; i + 1 < data.Length; i++) {
				if (relevantIndex > 0 && i + 1 == sortedIndices [relevantIndex])
					relevantIndex++;
				else {
					data [toReplace] = data[i + 1];
					toReplace++;
				}
			}
		}

		public static DynamicArraySimple<int> IntRange (int start = 1, int end = 512, int step = 1)
		{
			int element_count = (end - start) / step;
			DynamicArraySimple<int> ret = new DynamicArraySimple<int> (element_count);

			for (int i = start, index = 0; i < end; i += step, index++) {
				ret [index] = i;
			}

			return ret;
		}



		public IEnumerable<T> GetEnumerator()
		{
			return data.GetEnumerator ();
		}

		IEnumerator GetEnumerator()
		{
			return IEnumerable<T>.GetEnumerator ();
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
		private DynamicArraySimple<T>[] dataComponents;
		protected int capacity, subCapacity;
		private int nextOpenIndex;
		private int currentComponent, currentSubIndex;


		public DynamicArrayComponent(int _capacity = 512, int _subCapacity = 16)
		{
			if (_capacity < 1 || _subCapacity < 1)
				throw new ArgumentOutOfRangeException ();

			capacity = _capacity;
			subCapacity = _subCapacity;
			nextOpenIndex = 0;

			int divCap = capacity / subCapacity;
			int numComponents =  (divCap % subCapacity > 0) ? divCap + 1 : divCap; 

			dataComponents = new DynamicArraySimple<T>[numComponents];

			foreach (DynamicArraySimple<T> das in dataComponents) {
				das = new DynamicArraySimple<T>[subCapacity];
			}
		}

		public DynamicArrayComponent (DynamicArrayComponent<T> toCopy) : this(toCopy.Capacity, toCopy.SubCapacity)
		{
			foreach(T i in toCopy) {
				this.Add (i);
			}
		}

		public int Capacity
		{
			get { return capacity;} 
		}

		public int SubCapacity
		{
			get { return subCapacity;}
		}

		public T this [int index] 
		{
			get 
			{
				int componentIndex;
				int subIndex;
				ConvertIndex (index, componentIndex, subIndex);
				return dataComponents[componentIndex][subIndex]; 
			}
			set 
			{
				int componentIndex;
				int subIndex;
				ConvertIndex (index, componentIndex, subIndex);
				dataComponents[componentIndex][subIndex] = value; 
			}
		}

		private void ConvertIndex(int listIndex, out int componentIndex, out int subIndex )
		{
			if (listIndex >= capacity || indexer < 0)
				throw new ArgumentOutOfRangeException ();

			componentIndex = listIndex / subCapacity;
			subIndex = listIndex % subCapacity;
		}


		public void Add (params T[] newValues)
		{
			throw new NotImplementedException ();
			/*if (data.Length >= capacity) {
				int growthFactor = 2;

				while (newValues.Length + capacity >= growthFactor * capacity)
					growthFactor + 2;

				T _data = new T[growthFactor * capacity];

				for (int i = 0; i < capacity; i++) {
					_data [i] = data [i];
				}

				data = _data;
			} 

			foreach (T i in newValues) {
				data [data.Length] = i;
			}*/
		}

		//we do not definite a remove because it is a costly method
		//instead we will create a new more faster Dynamic Array
		public void Remove (params int[] indices)
		{
			throw new NotImplementedException ();
		}

		public IEnumerable<T> GetEnumerator()
		{
			return data.GetEnumerator ();
		}

		IEnumerator GetEnumerator()
		{
			return GetEnumerator ();
		}

		public override string ToString ()
		{
			return string.Format ("Capacity: {0} Length: {1}]", capacity, count);
		}

		public static DynamicArrayComponent<int> IntRange (int start = 1, int end = 512, int step = 1)
		{
			throw new NotImplementedException ();

			int element_count = (end - start) / step;

			DynamicArrayComponent<int> ret = new DynamicArrayComponent<int> (count);
			for (int i = start; i < end; i += step) {


			}

		}
	}

}

