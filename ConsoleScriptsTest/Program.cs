using System.Runtime.ConstrainedExecution;
using System.Net.Http;
using System.Text.Json;
using Xunit;
using System.Net;

namespace ConsoleScripTest._functions
{
    public class matematica
    {
        public void RunTest()
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

        public static float subtracao(float value1, float value2)
        {
            float result = value1 - value2;
            return result;
        }
        // Divisão básica

        public static float divisao (float value1, float value2)
        {
            float result = value1 / value2;
            return result;
        }
        // Multiplicação básica
        public static float multiplicacao (float value1, float value2)
        {
            float result = value1 * value2;
            return result;
        }
        // True ou False
        public static bool verdadeiro_ou_falso(float value1)
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
        public static bool Cpf(string cpf)
        {
            // int[] multiple = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            
            int cpflenght = cpf.Length;

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");

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

    public class requestAPI
    {
        //public static async Task Main()
        //{
        //    Console.WriteLine("Test api");
        //    int cep = 73270110;
        //    try
        //    {
        //        string jsonResponse = await Get(cep);
        //        Console.WriteLine(jsonResponse); // Exibe a resposta JSON no terminal
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Erro: {ex.Message}");
        //    }
        //}
        public static async Task<string?> GetCEP(string cep)
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

    //class Program
    //{
    //    static async Task Main(string[] args)
    //    {
    //        UniTest test = new UniTest();
    //        test.RunTest();

    //        int cep = 73270110;
    //        try
    //        {
    //            string jsonResponse = await requestAPI.GetCEP(cep);
    //            Console.WriteLine(jsonResponse); // Exibe a resposta JSON no terminal
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine($"Erro: {ex.Message}");
    //        }
    //    }
    //}
    
}


