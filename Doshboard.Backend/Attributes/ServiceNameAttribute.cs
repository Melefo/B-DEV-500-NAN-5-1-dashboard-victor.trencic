namespace Doshboard.Backend.Attributes
{
    public class ServiceNameAttribute : Attribute
    {
        public string Name { get; set; }

        public ServiceNameAttribute(string name)
            => Name = name.ToLowerInvariant().Replace(' ', '_');
    }
}
