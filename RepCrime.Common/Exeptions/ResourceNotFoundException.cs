namespace RepCrime.Common.Exeptions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(string message)
            : base(message) { }
    }
}
