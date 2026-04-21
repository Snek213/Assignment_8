using Assignment_8.Models;

namespace Assignment_8.Data
{
    public interface IMovieRepo
    {
        Task DeleteByIdAsync(int id);
        IEnumerable<Movie> GetAll();
        Movie? GetById(int id);
        void SaveChanges();
        void Add(Movie movie);
        void Update(Movie movie);
        object Attach(Movie movie);
        Task<Movie> GetByIdAsync(int value);
        Task SaveChangesAsync();
        Task<IEnumerable<Movie>> GetAllAsync();

    }
}