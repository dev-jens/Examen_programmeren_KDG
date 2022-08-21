using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_prog1
{
    class Athlete
    {

		private Person person;

		public Person Person
		{
			get { return person; }
			set { person = value; }
		}

		private string sportDiscipline;

		public string SportDiscipline
        {
			get { return sportDiscipline; }
			set { sportDiscipline = value; }
		}
		public Athlete(string name, int weight , double lenght, string sportDiscipline)
		{
			this.person = new Person(name, weight, lenght);
			this.sportDiscipline = sportDiscipline;
		}

		public override string ToString()
		{
			return this.person.ToString() + $" {sportDiscipline}";
		}


	}
}
