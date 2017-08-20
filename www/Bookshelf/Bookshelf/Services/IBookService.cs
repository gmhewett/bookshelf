namespace Bookshelf.Services
{
    using System.Threading.Tasks;
    using Bookshelf.Models;

    public interface IBookService : IServiceBase<Book>
    {
        Task<Book> LookUp(string isbn);

        Task<Book> CheckOutBook(int id);

        Task<Book> ReturnBook(int id);
    }
}