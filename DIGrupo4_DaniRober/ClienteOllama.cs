using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DIGrupo4_DaniRober
{
    // Esta clase se encarga de comunicarse con Ollama por HTTP.
    public class ClienteOllama
    {

        private readonly HttpClient _httpClient;

        public ClienteOllama()
        {
            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromMinutes(10); // primera respuesta puede tardar
        }

        public async Task<string> EnviarPromptAsync(string prompt, CancellationToken ct)
        {
            if (string.IsNullOrWhiteSpace(prompt))
                return "⚠️ Escribe algo antes de enviar.";

            var cuerpo = new
            {
                model = "llama3.2", // EXACTO como aparece en ollama list (sin :latest también vale)
                prompt = prompt,
                stream = false
            };

            string json = JsonSerializer.Serialize(cuerpo);
            using var content = new StringContent(json, Encoding.UTF8, "application/json");

            using var resp = await _httpClient.PostAsync("http://localhost:11434/api/generate", content, ct);

            // Si no es OK, devolvemos el cuerpo de error para verlo en el panel
            if (!resp.IsSuccessStatusCode)
            {
                string err = await resp.Content.ReadAsStringAsync(ct);
                return $"ERROR {(int)resp.StatusCode}: {err}";
            }

            string jsonResp = await resp.Content.ReadAsStringAsync(ct);

            using var doc = JsonDocument.Parse(jsonResp);
            return (doc.RootElement.GetProperty("response").GetString() ?? "").Trim();
        }
    }
}