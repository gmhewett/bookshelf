namespace Bookshelf.Loggers
{
    using System.Diagnostics;

    public class BookshelfLogger : IBookshelfLogger
    {
        public void LogInfo(string message)
        {
            Trace.TraceInformation(message);
        }

        public void LogWarning(string message)
        {
            Trace.TraceWarning(message);
        }

        public void LogError(string message)
        {
            Trace.TraceError(message);
        }
    }
}