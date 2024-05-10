namespace Geometry.App.Exceptions
{
    public class InvalidRectangleException : Exception
    {
        public InvalidRectangleException() { }

        public InvalidRectangleException(string message) : base(message) { }

        public InvalidRectangleException(string message, Exception innerException) : base(message, innerException) { }
    }
}
