﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _04.Opinion_Poll
{
	class Person
	{
		private string name;
		private int age;

		public Person(string name, int age)
		{
			this.name = name;
			this.age = age;
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public int Age
		{
			get { return age; }
			set { age = value; }
		}
	}
}
