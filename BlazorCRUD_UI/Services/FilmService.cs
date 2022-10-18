using BlazorCRUD_Data_Dapper.Repositories;
using BlazorCRUD_Model;
using BlazorCRUD_UI.Data;
using BlazorCRUD_UI.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorCRUD_UI.Services {
	public class FilmService : IFilmService {
		private SqlConfiguration _sqlConfiguration;
		private FilmRepository _filmRepository;
		public FilmService(SqlConfiguration sqlConfiguration) {
			_sqlConfiguration = sqlConfiguration;
			_filmRepository = new FilmRepository(sqlConfiguration.ConnectionString);
		}
		public Task<bool> DeleteFilm(int id) {
			return _filmRepository.DeleteFilm(id);
		}

		public Task<IEnumerable<Film>> GetAllFilms() {
			return _filmRepository.GetAllFilms();
		}

		public Task<Film> GetDetails(int id) {
			return _filmRepository.GetFilmDetails(id);
		}

		public Task<bool> SaveFilm(Film film) {
			if (film.Id == 0) return _filmRepository.InsertFilm(film);
			else return _filmRepository.UpdateFilm(film);
		}
	}
}
