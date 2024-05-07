using BlazorApp1.Models;
using System.Text.Json;
using System.Text;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlazorApp1.Service
{
    public class Acollection : IAcollection
    {
        const string URL = "http://localhost:11434/api/generate";

        public async Task<ModeloParaRespuesta> consultaPost(ModeloConsulta ObjetoJson)
        {
            try
            {

                ModeloParaRespuesta answer = new ModeloParaRespuesta();
                ModeloParaRespuesta answerr = new ModeloParaRespuesta();
                var httpClient = new HttpClient();
                string jsonData = JsonSerializer.Serialize(ObjetoJson);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(URL, content);
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();
                answer = JsonSerializer.Deserialize<ModeloParaRespuesta>(responseContent) ?? new ModeloParaRespuesta();
                return answer;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error al realizar la solicitud HTTP: " + ex.Message, ex);
            }
        }
    }