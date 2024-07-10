using PlaylistSuggestion.Domain.DTO;
using PlaylistSuggestion.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistSuggestion.Domain.Interfaces
{
    public interface IDBConnection
    {
        Task<List<MusicDTO>> GetPlaylistByMusicalGenre(MusicalGenreEnum musicalGenreEnum);
    }
}
