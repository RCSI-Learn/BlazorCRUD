using BlazorCRUD_Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorCRUD_UI.Interfaces {
	public interface IFilmService {
		Task<IEnumerable<Film>> GetAllFilms();
		Task<Film> GetDetails(int id);
		Task<bool> DeleteFilm(int id);
		Task<bool> SaveFilm(Film film);
	}
}
