namespace EmailApi2.Models
{
    public class Person
    {
        public virtual int ID { get; set; }
        public virtual string First { get; set; }
        public virtual string Last { get; set; }
        public virtual string Email { get; set; }
    }
}
