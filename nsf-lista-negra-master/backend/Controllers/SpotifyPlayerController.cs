using System;
using System.Net;
using System.Net.Http;
using System.Collections;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http.Headers;
using backend.Models.External;
using backend.Models.Request;
using backend.Models.Response;

namespace backend.Business
{
    [ApiController]
    [Route("[controller]")]
    public class SpotifyPlayerController : ControllerBase
    {
        // Informações retiradas da plataforma Spotify-For-Developers
        const string REFRESH_TOKEN             = "AQAfkGpD70fiuK3bYfY6jF4dQlYQn5ow9kC77IeGriuxqgWLHEKcql__PUIhtPWu2iij4jwJuU1GD7Qp0aDUrcbmEHOPQRo1PWkX-VktKdYWLrxEs-nHaCXCS9hRkpxGQdw";
        const string CLIENT_AND_SECRET         = "Basic MTcwOGNmMjIzODY4NDYzZWFiYzMxNWY0NWVkZWYzMTY6MWRmMTgwNmFlZmQ4NDJlNTg5MTJmNmMxZjZmOTlmZjY=";
        const string URL_SPOTIFY_REFRESHTOKEN  = "https://accounts.spotify.com/api/token";
        const string URL_SPOTIFY_PLAY          = "https://api.spotify.com/v1/me/player/play";
        static string TOKEN                    = "";



        [HttpPut]
        public async Task<ActionResult<SpotifyPlayResponse>> Tocar(PlayRequest request)
        {
            try 
            {
                SpotifyPlayResponse response = await ChamarSpotifyApi(request);
                return response;
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(500, ex.Message)
                );
            }
        }


        public async Task<SpotifyPlayResponse> ChamarSpotifyApi(PlayRequest request)
        {
            // Gera token de acesso
            string token = await GerarTokenAcesso();
            
            // Cria objeto de conexao com spotify-api
            HttpClient api = new HttpClient();
            api.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Cria body-request para enviar para spotify-api
            SpotifyPlayRequest spotifyRequest = new SpotifyPlayRequest();
            spotifyRequest.uris.Add(request.MusicaURI);

            string json = JsonConvert.SerializeObject(spotifyRequest);
            StringContent body = new StringContent(json);

            // Chama spotify-api verbo PUT
            HttpResponseMessage spotifyResponse = await api.PutAsync(URL_SPOTIFY_PLAY, body);
            
            // Se api expirou, reseta token
            if (spotifyResponse.StatusCode == HttpStatusCode.Unauthorized)
                TOKEN = string.Empty;
            

            // Cria objeto response com responsta da spotify-api
            SpotifyPlayResponse response = new SpotifyPlayResponse();
            response.Status = (int) spotifyResponse.StatusCode;
            response.Mensagem = await spotifyResponse.Content.ReadAsStringAsync(); 

            return response;
        }




        public async Task<string> GerarTokenAcesso()
        {
            if (string.IsNullOrEmpty(TOKEN))
            {
                // Cria objeto de conexao com spotify-api
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", CLIENT_AND_SECRET);

                // Cria objeto form-url-request para enviar para spotify-api
                FormUrlEncodedContent body = new FormUrlEncodedContent(
                    new List<KeyValuePair<string, string>>{
                        new KeyValuePair<string, string>("grant_type", "refresh_token"),
                        new KeyValuePair<string, string>("refresh_token", REFRESH_TOKEN)
                    });

                // Chama spotify-api verbo POST
                HttpResponseMessage spotifyResp = await client.PostAsync(URL_SPOTIFY_REFRESHTOKEN, body);
                
                // Lê response da spotify-api e atualiza o token de acesso
                string jsonResponse = await spotifyResp.Content.ReadAsStringAsync();
                SpotifyRefreshTokenResponse tokenResponse = JsonConvert.DeserializeObject<SpotifyRefreshTokenResponse>(jsonResponse);
                
                TOKEN = tokenResponse.Access_Token;
            }
            return TOKEN;
        }


        
        
    }
}