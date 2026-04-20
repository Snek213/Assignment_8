using Assignment_8.Data;
using Assignment_8.Models;

namespace Assignment_8.Utils
{
    public static class EndpointHelper
    {
        public static void MapEndpoints(this WebApplication app)
        {
            app.MapGet("/", GetAllMoviesAsync).WithName("GetAllMoviesAsync");
            app.MapGet("/movies/{id}", GetMovieByIdAsync).WithName("GetMovieById");

            
        }

        public static async Task<IEnumerable<Movie>> GetAllMoviesAsync(IMovieRepo repo)
        {
            return await repo.GetAllAsync();
        }

        public static async Task<IResult> GetMovieByIdAsync(IMovieRepo repo, int id)
        {
            try
            {
                Movie? movie = repo.GetById(id);
                if (movie != null)
                {
                    return Results.Ok(movie);
                }
                else
                {
                    return Results.NotFound();
                }
            }
            catch (Exception e)
            {
                return Results.Problem(e.Message);
            }
        }

        public static async Task AddMovieAsync(IMovieRepo repo, Movie movie)
        {
            repo.Add(movie);
            await repo.SaveChangesAsync();
        }

        public static async Task DeleteMovieAsync(IMovieRepo repo, int id)
        {
            await repo.DeleteByIdAsync(id);
        }

        public static async Task UpdateMovieAsync(IMovieRepo repo, Movie movie)
        {
            repo.Attach(movie);
            await repo.SaveChangesAsync();
        }


    }
}
