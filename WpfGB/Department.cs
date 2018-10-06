using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGB
{
    class Department
    {
        public static int __Id = 1;
        public string NameDepartament { get; set; }
        public int ID { get; set; }

        public Department(string _name)
        {
            ID = __Id;
            __Id++;
            NameDepartament = _name;
        }

        public override string ToString()
        {

            return ($"{NameDepartament}");
        }
    }
}
