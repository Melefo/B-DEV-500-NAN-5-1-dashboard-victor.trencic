namespace Doshboard.Backend.Models
{
    public class Client
    {
        public Client(string host) =>
            Host = host;

        public string Host { get; set; }
    }
    public enum ParamType
    {
        String = 0,
        Interger = 1
    }

    public class Param
    {
        public Param(string name, ParamType type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; set; }
        public ParamType Type { get; set; }
    }

    public class Widget
    {
        public Widget(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public List<Param> Params { get; set; } = new();
    }

    public class Service
    {
        public Service(string name) =>
            Name = name;

        public string Name { get; set; }
        public List<Widget> Widgets { get; set; } = new();
    }

    public class Server
    {
        public Server() =>
            CurrentTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        public long CurrentTime { get; set; }
        public List<Service> Services { get; set; } = new();
    }
    public class About
    {
        public About(string host) =>
            Client = new(host);

        public Client Client { get; set; }
        public Server Server { get; set; } = new();
    }
}
