﻿namespace _08.MilitaryElite.Contracts
{
	public abstract class Soldier : ISolider
	{
		public Soldier(int id, string firstName, string lastName)
		{
			Id = id;
			FirstName = firstName;
			LastName = lastName;
		}

		public int Id
		{
			get;
			private set;
		}

		public string FirstName
		{
			get;
			private set;
		}

		public string LastName
		{
			get;
			private set;
		}

		public override string ToString()
		{
			return $"Name: {FirstName} {LastName} Id: {Id}";
		}
	}
}
