﻿using System;

public class NameAndAge
{
	int age;
	string name;

	private NameAndAge(string name, int age)
	{
		Name = name;
		Age = age;
	}

	public string Name { get => name; set => name = value; }

	public int Age { get => age; set => age = value; }

	string fullNameAndAge;

	public NameAndAge()
	{
		fullNameAndAge = age + name;
	}

	public string PrintNameAndAge()
	{
		return $"{this.name} {this.age}";
	}

	public string ChangeFirstNameAndAge()
	{
		name = "No name";
		age = 1;
		return $"{this.name} {this.age}";
	}

	public string ChangeSecondNameAndAge(int age)
	{
		name = "No name";
		return $"{this.name} {this.age}";
	}

	public string ChangeThirdNameAndAge(string name, int age)
	{
		return $"{this.name} {this.age}";
	}
}

