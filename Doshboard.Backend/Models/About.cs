namespace Doshboard.Backend.Models
{
    /// <summary>
    /// Client informations
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Client class constructor
        /// </summary>
        /// <param name="host">Client address</param>
        public Client(string host) =>
            Host = host;

        /// <summary>
        /// Client address
        /// </summary>
        public string Host { get; set; }
    }

    /// <summary>
    /// Widget parameter type
    /// </summary>
    public enum ParamType
    {
        String = 0,
        Interger = 1
    }

    /// <summary>
    /// Widget parameter informations
    /// </summary>
    public class Param
    {
        /// <summary>
        /// Param constructor
        /// </summary>
        /// <param name="name">Name of parameter</param>
        /// <param name="type">Type of parameter</param>
        public Param(string name, ParamType type)
        {
            Name = name;
            Type = type;
        }

        /// <summary>
        /// Name of parameter
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Type of parameter
        /// </summary>
        public ParamType Type { get; set; }
    }

    /// <summary>
    /// Widget informations
    /// </summary>
    public class Widget
    {
        /// <summary>
        /// Widget constructor
        /// </summary>
        /// <param name="name">Widget name</param>
        /// <param name="description">Widget parameter</param>
        public Widget(string name, string description)
        {
            Name = name;
            Description = description;
        }

        /// <summary>
        /// Widget name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Widget description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Widget parameters
        /// </summary>
        public List<Param> Params { get; set; } = new();
    }

    /// <summary>
    /// Service informations
    /// </summary>
    public class Service
    {
        /// <summary>
        /// Service constructor
        /// </summary>
        /// <param name="name">Service name</param>
        public Service(string name) =>
            Name = name;

        /// <summary>
        /// Service name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Widgets using the service
        /// </summary>
        public List<Widget> Widgets { get; set; } = new();
    }

    /// <summary>
    /// Server informations
    /// </summary>
    public class Server
    {
        /// <summary>
        /// Server constructor
        /// </summary>
        public Server() =>
            CurrentTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        /// <summary>
        /// Posix Epoch when class created
        /// </summary>
        public long CurrentTime { get; set; }
        /// <summary>
        /// List of available services
        /// </summary>
        public List<Service> Services { get; set; } = new();
    }

    /// <summary>
    /// Model for /about.json route
    /// </summary>
    public class About
    {
        /// <summary>
        /// About model constructor
        /// </summary>
        /// <param name="host">Client address</param>
        public About(string host) =>
            Client = new(host);

        /// <summary>
        /// Client informations
        /// </summary>
        public Client Client { get; set; }
        /// <summary>
        /// Server informations
        /// </summary>
        public Server Server { get; set; } = new();
    }
}
