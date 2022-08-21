using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_prog1
{
    internal class Person
    {
		// in de opdracht staat niet specifiek ofdeze public of private moeten zijn dus propfull(typ dit en da genereerd)

		private int weight;

		public int Weight
		{
			get { return weight; }
			set { weight = value; }
		}

		private double lenght;

		public double Lenght
		{
			get { return lenght; }
			set { lenght = value; }
		}

		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}


        // constructor

        public Person()
        {
            this.name = "Jane Doe";
            this.weight = 55;
            this.lenght = 1.6;
        }

        public Person(string name)
		{
			this.name = name;
			this.weight = 55;
			this.lenght = 1.6;
		}


        public Person(string name , int weight , double lenght)
		{
			this.name = name;
			this.weight = weight;
			this.Lenght = lenght;
		}

		public double getBMI()
		{
			// weight / len * len , this. hoeft niet maar is cleaner
			return Math.Round(this.weight / Math.Pow(this.lenght,2), 2);
		}


		public override string ToString()
		{
			return $"{this.name}, {this.weight} kg {this.lenght} m BMI = {this.getBMI()}";
		}


	}
}
