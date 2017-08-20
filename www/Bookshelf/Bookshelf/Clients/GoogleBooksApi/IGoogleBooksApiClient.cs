namespace Bookshelf.Clients.GoogleBooksApi
{
    using System.Threading.Tasks;
    using Bookshelf.Clients.GoogleBooksApi.ApiSchema;

    public interface IGoogleBooksApiClient
    {
        Task<GoogleVolume> LookUpByIsbnAsync(string isbn);
    }
}