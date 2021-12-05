namespace Doshboard.Backend.Exceptions
{
    public class WidgetException : Exception
    {
        public WidgetException() : base()
        {
        }

        public WidgetException(string message)
            : base(message)
        {
        }

        public WidgetException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
