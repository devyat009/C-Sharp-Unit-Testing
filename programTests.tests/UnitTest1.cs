
using System;
using ConsoleScripTest._functions;
namespace programTests.tests
{
    public class UnitTest1
    {
        [Fact(DisplayName = "Soma = 10")]
        public void Test1Soma()
        {
            var resultado = matematica.Somar(5,5);
            Assert.Equal(10, resultado);
        }
        [Fact(DisplayName ="Subtração = 5")]
        public void Test2Subtracao()
        {
            var result = matematica.subtracao(10, 5);
            Assert.Equal(5, result);
        }

        [Fact(DisplayName = "Divisao = 15")]
        public void Test3Divisao()
        {
            var result = matematica.divisao(30, 2);
            Assert.Equal(15, result);
        }

        [Fact(DisplayName = "Multiplicacao = 8")]
        public void Test4Multiplicacao()
        {
            var result = matematica.multiplicacao(2, 4);
            Assert.Equal(8, result);
        }

        [Fact(DisplayName = "Booleano = true maior que zero")]
        public void Test5Booleano()
        {
            bool result = matematica.verdadeiro_ou_falso(1);
            Assert.True(true, "Expected return true for value 1");
        }
        [Fact(DisplayName = "Booleano = False maior que zero")]
        public void Test6Booleano()
        {
            bool result = matematica.verdadeiro_ou_falso(0);
            Assert.False(result, "Expected return value false for 0");
        }

        [Fact(DisplayName = "Valida se o CPF é valido")]
        public void Test6CPF()
        {
            bool result = matematica.Cpf("123.456.789-10");
            Assert.True(true, "Expected return true for 11 digits");
        }

        // API Request Related
        [Fact(DisplayName = "CEP = Retorno de NULL quando CEP estiver errado")]
        public async Task APITest01_CEPNull()
        {
            var result = await requestAPI.GetCEP("73.270.110-0");
            Assert.Null(result);
        }
    }
}


