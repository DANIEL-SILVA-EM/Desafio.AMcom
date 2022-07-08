using Desafio.AMcom.Controllers;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Desafio.AMcom
{
    public static class UtilidadesArquivo
    {
        const string FILE_TEMPERATURA = $"temperatura.txt";
        public static void EscrevaTemperaturaTxt(Temperatura temperatura)
        {
            using var file = File.AppendText(FILE_TEMPERATURA);
            file.WriteLine(temperatura.ToString());
        }

        const string FILE_PAISES = $"paises.json";
        public static IEnumerable<Pais> LeiaTemperaturaTxt()
        {
            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            string jsonString = File.ReadAllText(FILE_PAISES, Encoding.GetEncoding("ISO-8859-1"));
            IEnumerable<Pais> pais = JsonSerializer.Deserialize<IEnumerable<Pais>>(jsonString, serializeOptions);
            return pais;
        }
    }
}
