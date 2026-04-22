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

            app.MapPost("/movies", AddMovieAsync).WithName("AddMovie");

            app.MapDelete("/movie/{id}", DeleteMovieAsync).WithName("DeleteMovie");

            app.MapPut("/movie", UpdateMovieAsync).WithName("UpdateMovie");


        }

        public static async Task<IEnumerable<Movie>> GetAllMoviesAsync(IMovieRepo repo)
        {
            return await repo.GetAllAsync();
        }

        public static async Task<IResult> GetMovieByIdAsync(IMovieRepo repo, int id)
        {
            try
            {
                var movie = repo.GetById(id);
                if (movie == null) return Results.NotFound();
                return Results.Ok(movie);
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

        public static async Task<IResult> UpdateMovieAsync(IMovieRepo repo, Movie movie)
        {
            try
            {
                // Just try to update directly
                await repo.Update(movie);
                return Results.Ok(movie);
            }
            catch (Exception e)
            {
                // This means the movie doesn't exist
                return Results.NotFound();
            }
            
        }
    }
}
