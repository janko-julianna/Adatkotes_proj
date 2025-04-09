using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace menhely
{
    public class Animal
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        public bool Adoptable { get; private set; }
        public int Age { get; private set; }
        public Animal(string Name, string Type, int Age, string adoptable)
        {
            this.Name = Name;
            this.Type = Type;
            this.Age = Age;
            if(adoptable == "Igen")
            {
                this.Adoptable = true;
            }
            else
            {
                this.Adoptable = false;
            }
        }

        public Animal()
        {
            this.Name = "";
            this.Type = "";
            this.Age = 1;
            this.Adoptable = false;
        }

    }
}