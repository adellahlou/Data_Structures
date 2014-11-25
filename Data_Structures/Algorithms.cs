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

namespace Data_Structures.Algorithms
{

	public class Utility
	{

	}

	public class Sorter
	{
		public void Swap<T> ( T collection, int index1, int index2)
		{
			var temp = collection [index1];
			collection [index1] = collection [index2];
			collection [index2] = temp;
		}

		public static bool BubbleSort(T collection)
		{
			throw new NotImplementedException();
		}

		public static bool MergeSort(T collection)
		{
			throw new NotImplementedException();
		}

		public static bool SelectionSort(T collection)
		{
			throw new NotImplementedException();
		}

		public static bool InsertionSort(T collection)
		{
			throw new NotImplementedException();
		}

		public static bool HeapSort(T collection)
		{
			throw new NotImplementedException();
		}

		public static bool ShellSort(T collection)
		{
			throw new NotImplementedException();
		}

		public static bool QuickSort(T collection)
		{
			throw new NotImplementedException();
		}
	}



	public class Searcher
	{
		public static int LinearSearch(T collection)
		{
			throw new NotImplementedException();
		}

		public static int BinarySearch(T collection)
		{
			throw new NotImplementedException();
		}

	}
		

}
