using System.Collections.Generic;
using System.Threading.Tasks;

namespace  Fiver.Lib.MongoDB.Client.OtherLayers
{
    public interface IMovieService
    {
        Task<List<Movie>> GetMovies();
        Movie GetMovie(string id);
        Task AddMovie(Movie item);
        Task UpdateMovie(Movie item);
        Task DeleteMovie(string id);
        bool MovieExists(string id);
    }
}
