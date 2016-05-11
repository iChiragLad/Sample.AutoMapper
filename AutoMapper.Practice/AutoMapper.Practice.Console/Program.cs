using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace AutoMapper.Practice.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cnfg =>
            {
                cnfg.CreateMap<Person, Employee>().BeforeMap((p, e) => p.Age = 25).AfterMap((p, e) => { e.Experience = (p.Age - 24); }).ForMember(e => e.Gender, cexp => cexp.MapFrom(e => e.Sex));
            });
            var mapper = config.CreateMapper();

            Person person = new Person();
            person.Age = 30;
            person.FirstName = "Chirag";
            person.LastName = "Lad";

            Employee emp = mapper.Map<Employee>(person);


            System.Console.ReadKey();
        }
    }
}
