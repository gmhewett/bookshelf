namespace Bookshelf.Config
{
    public interface IBookshelfConfig
    {
        T Get<T>(string key);
    }
}