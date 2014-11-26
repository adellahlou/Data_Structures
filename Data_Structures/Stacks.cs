using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading;

namespace Data_Structures
{
	public interface AStack<T>
	{
		T Pop ();
		void Push(T newValue);
		bool Contains(T searchValue);
	}

	public class ListStack<T> : AStack<T>, IEnumerable<T>
		where T: IComparer, IEquatable
	{
		private DLLNode data;

		public T Pop()
		{

		}

		public int Length
		{
			get{ data.Length; }
		}
	}
}

