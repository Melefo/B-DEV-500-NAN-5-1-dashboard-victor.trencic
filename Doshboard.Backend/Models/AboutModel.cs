namespace Doshboard.Backend.Models
{
    public class Client
    {
        public string? Host { get;  set; }
    }
    public enum ParamType
    {
        String = 0,
        Interger = 1
    }

    public class Param
    {
        public string Name { get; set; }
        public ParamType Type { get; set; }
    }

    public class Widget
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<Param> Params { get; set; } = new();
    }

    public class Service
    {
        public string? Name { get; set; }
        public List<Widget> Widgets { get; set; }
    }

    public class ServerModel
    {
        public long CurrentTime { get; set; }
        public List<Service> Services { get; set; }
    }
    public class AboutModel
    {
        public Client Client { get; set; } = new();
        public ServerModel Server { get; set; } = new();
    }
}
