using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGB
{
    class Employee
    {
        public static int __Id = 1;
        public int Age { get; set; }
        public string Name { get; set; }
        public int ID { get; set; }

        public Employee(int _age, string _name)
        {
            ID = __Id;
            __Id++;
            Age = _age;
            Name = _name;
        }

        public override string ToString()
        {

            return ($"{Name}");
        }
    }
}
