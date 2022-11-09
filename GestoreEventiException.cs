using System.Runtime.Serialization;

[Serializable]
public class GestoreEventiException : Exception
{
    public GestoreEventiException()
    {
    }

    public GestoreEventiException(string? message) : base(message)
    {
    }

    public GestoreEventiException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected GestoreEventiException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}