using Google.Cloud.Datastore.V1;
using PlaylistSuggestion.Domain.DTO;
using PlaylistSuggestion.Domain.Enum;
using PlaylistSuggestion.Domain.Interfaces;

namespace PlaylistSuggestion.Infra
{
    public class DBConnection : IDBConnection
    {
        const string PROJECT_ID = "p3sites";
        public async Task<List<MusicDTO>> GetPlaylistByMusicalGenre(MusicalGenreEnum musicalGenreEnum)
        {
            try
            {
                //  Google Cloud Connection.
                DatastoreClient client = DatastoreClient.Create();

                // Google DatastoreDb with DatastoreClient.
                var db = DatastoreDb.Create(PROJECT_ID, "", client);
                
                //Database
                Query query = new Query("Playlist")
                {
                    Filter = Filter.GreaterThanOrEqual("playlistGenreId", (int)musicalGenreEnum)
                };

                DatastoreQueryResults queryResult = await db.RunQueryAsync(query);

                return _musicMapper(queryResult.Entities[0]);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private List<MusicDTO> _musicMapper(Entity entity)
        {
            List<MusicDTO> lstMusics = new();
            foreach (Value value in entity.Properties["lstMusics"].ArrayValue.Values)
            {
                lstMusics.Add(new MusicDTO { Music = value.StringValue });
            }

            return lstMusics;
        }
    }
}
