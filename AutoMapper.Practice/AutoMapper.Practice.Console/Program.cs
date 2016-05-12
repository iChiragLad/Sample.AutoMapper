using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace AutoMapper.Practice.Console
{
    class MappingProfile : Profile
    {
        protected override void Configure()
        {
            //creating a map from Person to Employee
            CreateMap<Person, Employee>()
                //Before map action
                .BeforeMap((p, e) => p.Age = 25)
                //After map action
                .AfterMap((p, e) => { e.Experience = (p.Age - 24); })
                //projection
                .ForMember(e => e.Gender, cexp => cexp.MapFrom(e => e.Sex))
                //Conditional Mapping
                .ForMember(x => x.FirstName, c => c.Condition(p => (p.FirstName.Length > 1)))
                //projection
                .ForMember(x => x.Experience, c => c.MapFrom(p => p.Age))
                //ignoring map
                .ForMember(x => x.Id, c => c.Ignore())
                //constructor parameter mapping
                .ForCtorParam("value", c => c.MapFrom(p => p.Address))
                //custom type resolver
                .ForMember(x => x.Salary, c => c.ResolveUsing(new SalaryResolver()))
                //projection
                .ForMember(x => x.Manager, c => c.MapFrom(p => p.Parent))
                //Null substitution
                .ForMember(x => x.Manager, c => c.NullSubstitute("Fill Later"));
            //custom value resolver
            CreateMap<bool, string>().ConvertUsing(new MaritalStatusConverter());
        }

        class ConfigurationProfile : Profile
        {
            protected override void Configure()
            {
                ShouldMapProperty = (pi => pi.GetMethod.IsPublic);
                //RecognizeDestinationPrefixes("emp");
                //ReplaceMemberName("Addresi", "Address");
            }
        }

        class MaritalStatusConverter : ITypeConverter<bool, string>
        {
            public string Convert(ResolutionContext context)
            {
                if ((bool)context.SourceValue)
                {
                    return "Single";
                }
                else
                {
                    return "Married";
                }
            }
        }

        class SalaryResolver : ValueResolver<Person, int>
        {
            protected override int ResolveCore(Person source)
            {
                if(source.Educated)
                {
                    return 300000;
                }
                else
                {
                    return 100000;
                }
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var config = new MapperConfiguration(cnfg =>
                {
                    cnfg.AddProfile(new MappingProfile());
                    cnfg.AddProfile(new ConfigurationProfile());
                });

                config.AssertConfigurationIsValid();
                var mapper = config.CreateMapper();

                Person person = new Person();
                person.Age = 30;
                person.FirstName = "Chirag";
                person.LastName = "Lad";
                person.Sex = "Male";
                person.Address = "Bhagwati Ashiyana";
                person.Marital = true;
                person.Educated = true;
                person.Parent = null;

                Employee emp = mapper.Map<Employee>(person);

                System.Console.ReadKey();
            }
        }
    }
}
