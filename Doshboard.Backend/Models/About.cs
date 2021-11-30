using Doshboard.Backend.Attributes;
using Doshboard.Backend.Interfaces;
using System.Reflection;

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
        Integer = 1
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
            Name = name.ToLowerInvariant();
            Type = type.ToString().ToLowerInvariant();
        }

        /// <summary>
        /// Name of parameter
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Type of parameter
        /// </summary>
        public string Type { get; set; }
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
        public Widget(Type type)
        {
            var infos = type.GetCustomAttribute<WidgetInfoAttribute>();

            Name = infos.Name;
            Description = infos.Description;

            var @params = type.GetProperties().Where(x => x.GetCustomAttribute<WidgetParamAttribute>() != null);
            foreach (var param in @params)
            {
                var prop = Type.GetTypeCode(param.PropertyType) switch
                {
                    TypeCode.String => ParamType.String,
                    TypeCode.Int32 => ParamType.Integer,
                    _ => throw new NotImplementedException()
                };

                Params.Add(new(param.Name, prop));
            }
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
        public Service(Type type)
        {
            Name = type.GetCustomAttribute<ServiceNameAttribute>()!.Name;

            var widgets = (Type[])type.GetProperty("Widgets")!.GetGetMethod()!.Invoke(null, null)!;
            foreach (var widget in widgets!)
            {
                var infos = widget.GetCustomAttribute<WidgetInfoAttribute>();
                Widgets.Add(new(widget));
            }
        }

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
        public Server()
        {
            CurrentTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            var @interface = typeof(IService).GetTypeInfo();
            var services = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.GetInterfaces().Contains(@interface) && !x.IsAbstract && !x.IsInterface);

            foreach (var service in services)
                Services.Add(new(service));
        }

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
