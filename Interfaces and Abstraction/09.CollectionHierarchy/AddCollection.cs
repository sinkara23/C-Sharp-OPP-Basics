﻿using System;
using System.Collections.Generic;

namespace _09.CollectionHierarchy
{
	class AddCollection : IAddCollection
	{
		private List<string> _data;
		private readonly List<int> _indexes;

		public AddCollection()
		{
			_data = new List<string>();
			_indexes = new List<int>();
		}

		public void Add(string element)
		{
			if (element == null)
			{
				throw new ArgumentNullException(nameof(element));
			}

			int index = _data.Count;
			_indexes.Add(index);
			_data.Add(element);
		}

		public override string ToString()
		{
			return $"{string.Join(" ", _indexes)}";
		}
	}
}
