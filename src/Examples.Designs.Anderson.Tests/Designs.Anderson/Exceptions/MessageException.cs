namespace Examples.Designs.Anderson.Exceptions
{
    public sealed class MessageException : ExceptionBase
    {
        public MessageException(ExceptionType type, string message) : base(type, message)
        {
        }

    }

}
