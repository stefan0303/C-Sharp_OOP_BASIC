using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using _01.DefineAnInterfaceIPerson.Interfaces;

namespace _01.DefineAnInterfaceIPerson
{
    class Citizen : IPerson, IBirthable, IIdentifiable
    {
        private string name;
        private int age;
        private string birhDate;
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Birthdate = birthdate;
            this.Id = id;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Birthdate { get; set; }
        public string Id { get; set; }
    }
}
