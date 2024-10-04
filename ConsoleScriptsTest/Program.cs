using System.Runtime.ConstrainedExecution;
using System.Net.Http;
using System.Text.Json;
using Xunit;
using System.Net;

namespace ConsoleScripTest._functions
{
    public static class Matematica
    {
        public static void RunTest()
        {
            Console.WriteLine("Test");
            
        }

        // Soma básica
        public static float Somar(float value1, float value2)
        {
            float result = value1 + value2;
            return result;
        }
        // Subtração básica

        public static float Subtrair(float value1, float value2)
        {
            float result = value1 - value2;
            return result;
        }
        // Divisão básica

        public static float Dividir (float value1, float value2)
        {
            float result = value1 / value2;
            return result;
        }
        // Multiplicação básica
        public static float Multiplicar (float value1, float value2)
        {
            float result = value1 * value2;
            return result;
        }
        // True ou False
        public static bool VerdadeiroOuFalso(float value1)
        {
            if (value1 > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // Validador de CPF (WIP)
        public static bool ValidarCpf(string cpf)
        {
            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            int cpflenght = cpf.Length;
            if (cpflenght != 11)
            {
                return false;
            }
            else
            {
                return true;
            }    
        }
    }

    public class RequestApi
    {
        // Função para obter as inormações do CEP
        public static async Task<string?> GetCep(string cep)
        {
            cep = cep.Trim().Replace(".", "").Replace("-", "");
            int ceplenght = cep.Length;
            if (ceplenght != 8)
            {
                return null;
            }

            using (var httpClient = new HttpClient())
            {
                try
                {
                    var response = await httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
                    var data = await response.Content.ReadAsStringAsync();

                    var CepResponse = JsonSerializer.Deserialize<CepResponse>(data);
                    if (CepResponse?.erro == "true")
                    {
                        return null; // Retorna null se houver erro no CEP
                    }
                    else
                    {
                        return data;
                    }
                    
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro a buscar dados de CEP na API", ex);
                }
            }

        }
        private class CepResponse()
        {
            public string? erro { get; set; }
        }
    }
}


