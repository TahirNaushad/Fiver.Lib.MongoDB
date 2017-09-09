using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  Fiver.Lib.MongoDB.Client.OtherLayers
{
    public class MovieService : IMovieService
    {
        private readonly IMongoRepository<Movie> repository;

        public MovieService(IMongoRepository<Movie> repository)
        {
            this.repository = repository;
        }

        public async Task<List<Movie>> GetMovies()
        {
            return await this.repository.GetListAsync();
        }

        public Movie GetMovie(string id)
        {
            return this.repository.GetItem(id);
        }

        public async Task AddMovie(Movie item)
        {
            await this.repository.InsertAsync(item); 
        }

        public async Task UpdateMovie(Movie item)
        {
            await this.repository.UpdateAsync(item.Id, item);
        }

        public async Task DeleteMovie(string id)
        {
            await this.repository.DeleteAsync(id);
        }

        public bool MovieExists(string id)
        {
            return this.repository.GetItem(id) != null;
        }
    }
}
