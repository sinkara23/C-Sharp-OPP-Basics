﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _04.ShoppingSpree
{
	class Person
	{
		private string _name;
		private decimal _money;
		private List<Product> Products { get; set; }

		public Person()
		{
			this.Products = new List<Product>();
		}

		public Person(string _name, decimal _money)
			: this()
		{
			this.Name = _name;
			this.Money = _money;
		}

		public string Name
		{
			get { return _name; }
			set
			{
				Validator.ValidateName(value);
				_name = value;
			}
		}

		private decimal Money
		{
			get { return _money; }
			set
			{
				Validator.ValidateMoney(value);
				_money = value;
			}
		}

		public string TryBuyProduct(Product product)
		{
			if (this.Money < product.Price)
			{
				return $"{this._name} can't afford {product.Name}";
			}

			this.Money = Money - product.Price;
			this.Products.Add(product);

			return $"{this._name} bought {product.Name}";
		}

		public override string ToString()
		{
			int product = Products.Count;
			string productsJoin = string.Join(", ", this.Products);
			string report = "Nothing bought";
			string productsOutput = product > 0 ?
				 productsJoin : report;
			string name = this.Name;
			string productsOut = productsOutput;
			string result = $"{name} - {productsOut}";
			return result;
		}
	}
}
