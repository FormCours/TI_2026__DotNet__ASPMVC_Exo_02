namespace Exo_ASPMVC_02.Exceptions
{
    public class StudentFailDeletedException : Exception
    {
        public StudentFailDeletedException()
        {
        }

        public StudentFailDeletedException(string? message) : base(message)
        {
        }
    }
}
