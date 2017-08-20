namespace Bookshelf.Loggers
{
    public interface IBookshelfLogger
    {
        void LogInfo(string message);

        void LogWarning(string message);

        void LogError(string message);
    }
}