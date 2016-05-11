using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.Practice.Console
{
    class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Experience { get; set; }
        public string Gender { get; set; }
    }
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
    }
}
