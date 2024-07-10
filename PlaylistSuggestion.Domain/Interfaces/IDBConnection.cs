using PlaylistSuggestion.Domain.DTO;
using PlaylistSuggestion.Domain.Enum;

namespace PlaylistSuggestion.Domain.Interfaces
{
    public interface IDBConnection
    {
        Task<List<MusicDTO>> GetPlaylistByMusicalGenre(MusicalGenreEnum musicalGenreEnum);
    }
}
