using ConsoleScripTest._functions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

// WIP
namespace ConsoleScriptsTest
{
    internal static class Menu
    {
        public static async Task MenuAPP(string[] args)
        {
            bool stop_input = true;
            while (true)
            {
                while (stop_input)
                {
                    Console.Clear();
                    Console.WriteLine("Bem vindo");
                    Console.WriteLine("1 - Calculadora Básica");
                    Console.WriteLine("2 - Buscar CEP (API)");
                    Console.WriteLine("0 - Sair");
                    Console.Write("Escolha : ");
                    string? user_input = Console.ReadLine();
                    if (ChecarNumero(user_input))
                    {
                        switch (user_input)
                        {
                            case "1":
                                stop_input = false;
                                while (true)
                                {
                                    Console.Clear();
                                    Console.WriteLine("1 - Soma");
                                    Console.WriteLine("2 - Subtração");
                                    Console.WriteLine("3 - Divisão");
                                    Console.WriteLine("4 - Multiplicação");
                                    Console.WriteLine("0 - Voltar");
                                    Console.Write("Escolha : ");
                                    string? choice_input = Console.ReadLine();
                                    if (ChecarNumero(choice_input))
                                    {
                                        switch (choice_input)
                                        {
                                            case "1":
                                                while (true)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Insira o primeiro número para somar");
                                                    Console.Write("Escolha: ");
                                                    string? num1 = Console.ReadLine();

                                                    // Checa se só tem número com a função checarNumero
                                                    if (ChecarNumero(num1))
                                                    {
                                                        // Transforma a string num1 em float
                                                        float fnum1;
                                                        float.TryParse(num1, NumberStyles.Float, new CultureInfo("pt-BR"), out fnum1);
                                                        while (true)
                                                        {
                                                            // Recebimento do segundo input
                                                            Console.WriteLine("Insira o segundo número para somar");
                                                            Console.Write("Escolha: ");
                                                            string? num2 = Console.ReadLine();

                                                            // Checa se só tem número com a função checarNumero
                                                            if (ChecarNumero(num2))
                                                            {
                                                                Console.Clear();
                                                                // Transforma a string num2 em float
                                                                float fnum2;
                                                                float.TryParse(num2, NumberStyles.Float, new CultureInfo("pt-BR"), out fnum2);
                                                                float restultado = Matematica.Somar(fnum1, fnum2);
                                                                Console.WriteLine($"O resultado é {restultado}");
                                                                Console.WriteLine("Pressione qualquer tecla para continuar...");
                                                                Console.ReadKey();
                                                                await Menu.MenuAPP(args);
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Entrada INVÁLIDA tente novamente...");
                                                                continue;
                                                            }
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Entrada INVÁLIDA, pressione qualquer tecla para tentar novamente...");
                                                        Console.ReadKey();
                                                        continue;
                                                    }
                                                }

                                                break;
                                            case "0":
                                                await Menu.MenuAPP(args);
                                                break;
                                            default:

                                                Console.WriteLine("Entrada INVÁLIDA. Pressione qualquer tecla para tentar novamente...");
                                                Console.ReadKey();
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Entrada INVÁLIDA, pressione qualquer tecla para tentar novamente...");
                                        Console.ReadKey();
                                        continue;
                                    }
                                } 
                            case "2":
                                stop_input = false;
                                while (true)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Digite o CEP para realizar uma busca:");
                                    Console.Write("CEP: ");
                                    string? cepInput = Console.ReadLine();
                                    if (ChecarNumero(cepInput))
                                    {
                                        string? cep_data = await RequestApi.GetCep(cepInput);
                                        if (string.IsNullOrEmpty(cep_data))
                                        {
                                            Console.WriteLine("Verifique o CEP e pressione qualquer tecla para continuar...");
                                            stop_input = true;
                                            Console.ReadKey();
                                            continue;
                                        }
                                        Console.WriteLine(cep_data);
                                        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                                        Console.ReadKey();
                                        await Menu.MenuAPP(args);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Entrada INVÁLIDA, pressione qualquer tecla para tentar novamente...");
                                        Console.ReadKey();
                                        continue;
                                    }
                                }
                            case "0":
                                return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Entrada INVÁLIDA, pressione qualquer tecla para tentar novamente...");
                        Console.ReadKey();
                    }
                }
            }
        }

        // Checagem se a string tem apenas números
        public static bool ChecarNumero(string? checarInput)
        {
            if (string.IsNullOrWhiteSpace(checarInput))
            {
                return false;
            }
            bool containsOnlyDigits = Regex.IsMatch(checarInput, @"^\d+$");
            if (containsOnlyDigits)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    internal static class Program
    {
        static async Task Main(string[] args)
        {
            await Menu.MenuAPP(args);
        }
    }
}
