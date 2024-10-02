using Xunit;

namespace ConsoleScripTest
{
    public class UniTest
    {
        public void RunTest()
        {
            Console.WriteLine("Test");
        }

        public static float Somar(float value1, float value2)
        {
            float result = value1 + value2;
            return result;
        }

        public static float subtracao(float value1, float value2)
        {
            float result = value1 - value2;
            return result;
        }

        public static float divisao (float value1, float value2)
        {
            float result = value1 / value2;
            return result;
        }

        public static float multiplicacao (float value1, float value2)
        {
            float result = value1 * value2;
            return result;
        }

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

    class Program
    {
        static void Main(string[] args)
        {
            UniTest test = new UniTest();
            test.RunTest();
        }
    }

}

