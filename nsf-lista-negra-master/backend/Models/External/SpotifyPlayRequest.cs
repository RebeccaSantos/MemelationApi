using System.Collections.Generic;

namespace backend.Models.External
{
    public class SpotifyPlayRequest
    {
        public List<string> uris {get;set;}

        public SpotifyPlayRequest()
        {
            uris = new List<string>();
        }
    }

}