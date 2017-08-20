namespace Bookshelf.Clients
{
    using System.Threading.Tasks;
    using Bookshelf.Clients.Models;

    public interface IGoogleBooksApiClient
    {
        Task<GoogleBookResponse> LookUpByIsbn(string isbn);
    }
}