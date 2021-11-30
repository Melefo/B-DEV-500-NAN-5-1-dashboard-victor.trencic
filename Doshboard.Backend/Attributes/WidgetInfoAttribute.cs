namespace Doshboard.Backend.Attributes
{
    public class WidgetInfoAttribute : Attribute
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public WidgetInfoAttribute(string name, string description)
        {
            Name = name.ToLowerInvariant().Replace(' ', '_');
            Description = description;
        }
    }
}
