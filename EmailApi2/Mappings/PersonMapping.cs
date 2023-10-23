using FluentNHibernate.Mapping;

namespace EmailApi2.Models
{
    public class PersonMapping: ClassMap<Person>
    {
        public PersonMapping()
        {
            Table("Person");
            Id(p => p.ID);
            Map(p => p.First);
            Map(p => p.Last);
            Map(p => p.Email);
        }
    }
}
