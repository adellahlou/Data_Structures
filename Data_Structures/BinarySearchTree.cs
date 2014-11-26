using System;
using System.Collections.Generic;
using System.Collections;

namespace Data_Structures
{
	public class BinaryTreeNode<T> : IEquatable<T>, IComparable<T>
		where T : IEquatable<T>, IComparable<T>

	{

		BinaryTreeNode<T> parent, left, right;
		private T data;

		public BinaryTreeNode( T _data = default(T), BinaryTreeNode<T> _parent = null, BinaryTreeNode<T> _left = null,BinaryTreeNode<T> _right = null)
		{
			data = _data;
			parent = _parent;
			left = _left;
			right = _right;
		}


		public override string ToString ()
		{
			return string.Format ("Data: {0}", data);
		}
	}

	public class BinarySearchTree<T>
	{
		private BinaryTreeNode<T> root;
		private int size, height;

		public BinarySearchTree(T rootData = default(T))
		{
			root = new BinaryTreeNode<T> (rootData);
			size = 1;
		}

	}
}

