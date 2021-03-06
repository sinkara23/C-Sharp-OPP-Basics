﻿using System.Collections.Generic;

namespace _01.RawData
{
	public class Car
	{
		public string _model;
		public int _engineSpeed;
		public int _enginePower;
		public int _cargoWeight;
		public string _cargoType;
		public KeyValuePair<double, int>[] _tires;

		public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, double tire1Pressure, int tire1Age, double tire2Pressure, int tire2Age, double tire3Pressure, int tire3age, double tire4Pressure, int tire4age)
		{
			_model = model;
			_engineSpeed = engineSpeed;
			_enginePower = enginePower;
			_cargoWeight = cargoWeight;
			_cargoType = cargoType;

			_tires = new KeyValuePair<double, int>[] { KeyValuePair.Create(tire1Pressure, tire1Age), KeyValuePair.Create(tire2Pressure, tire2Age), KeyValuePair.Create(tire3Pressure, tire3age), KeyValuePair.Create(tire4Pressure, tire4age) };
		}
	}
}
