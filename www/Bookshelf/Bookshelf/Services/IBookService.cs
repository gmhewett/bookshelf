namespace Bookshelf.Services
{
    using System.Threading.Tasks;
    using Bookshelf.Models;

    public interface IBookService : IServiceBase<Book>
    {
        Task<Book> LookUpAsync(string isbn);
    }
}