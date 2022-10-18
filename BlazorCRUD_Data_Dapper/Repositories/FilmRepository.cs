using BlazorCRUD_Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUD_Data_Dapper.Repositories {
    public class FilmRepository : IFilmRepository {
        private string ConnectionString;
        public FilmRepository(string ConnectionString) {
            this.ConnectionString = ConnectionString;
        }
        protected SqlConnection DBConnection() {
            return new SqlConnection(ConnectionString);
        }
        public async Task<bool> DeleteFilm(int id) {
            var DB = DBConnection();
            var SQL = "DELETE FROM dbo.Films WHERE Id = @id;";
            var result = await DB.ExecuteAsync(SQL.ToString(), new { Id = id });
            return result > 0;
        }

        public async Task<IEnumerable<Film>> GetAllFilms() {
            var DB = DBConnection();
            var SQL = "SELECT Id, Title, Director, ReleaseDate FROM dbo.Films;";
            return await DB.QueryAsync<Film>(SQL.ToString(), new { });
        }

        public async Task<Film> GetFilmDetails(int id) {
            var DB = DBConnection();
            var SQL = "SELECT Id, Title, Director, ReleaseDate FROM dbo.Films WHERE Id = @Id;";
            return await DB.QueryFirstOrDefaultAsync<Film>(SQL.ToString(), new { id });
        }

        public async Task<bool> InsertFilm(Film film) {
            var DB = DBConnection();
            var SQL = @"INSERT INTO Films(Title, Director, ReleaseDate)
                        VALUES(@Title, @Director, @ReleaseDate);";
            var result = await DB.ExecuteAsync(SQL.ToString(), new { film.Title, film.Director, film.ReleaseDate });
            return result > 0;
        }

        public async Task<bool> UpdateFilm(Film film) {
            var DB = DBConnection();
            var SQL = @"UPDATE Films
                        SET Title = @Title,
                            Director = @Director,
                            ReleaseDate = @ReleaseDate
                        WHERE Id = @Id;";
            var result = await DB.ExecuteAsync(SQL.ToString(), new { film.Title, film.Director, film.ReleaseDate, film.Id });
            return result > 0;
        }
    }
}
