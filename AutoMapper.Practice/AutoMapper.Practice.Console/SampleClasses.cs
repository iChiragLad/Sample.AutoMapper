using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.Practice.Console
{
    class Employee
    {
        private string _address;
        public Employee(string value)
        {
            _address = value;
        }
        public string Address
        {
            get
            {
                return _address;
            }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Experience { get; set; }
        public string Gender { get; set; }
        public string Id { get; set; }
        public string Marital { get; set; }
        public int Salary { get; set; }
        public string Manager { get; set; }
    }
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public bool Marital { get; set; }
        public bool Educated { get; set; }
        public string Parent { get; set; }

    }
}
