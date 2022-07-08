using Desafio.AMcom.Entity;
using Xunit;

namespace Desafio.AMcom.Testes
{
    public class TemperaturaTeste
    {
        [Theory]
        [InlineData(0, -17.7778, 255.372)]
        [InlineData(46.9, 8.277778, 281.427778)]
        [InlineData(85.7, 29.8333, 302.9833)]
        public void DeveValidarTemperaturaIniciadaComValorFahrenheit(decimal valorFahrenheit, decimal valorCelsius, decimal valorKelvin)
        {
            // Arranjar & Agir
            Temperatura temperatura = valorFahrenheit;

            // Afirmar
            Assert.Equal(valorFahrenheit, temperatura.ValorFahrenheit);
            Assert.Equal(valorCelsius, temperatura.ValorCelsius, 4);
            Assert.Equal(valorKelvin, temperatura.ValorKelvin, 3);
        }
        
        [Theory]
        [InlineData(0)]
        [InlineData(34.5)]
        [InlineData(54.3)]
        public void DeveValidarTemperaturasIguais(decimal temperatura)
        {
            // Arranjar 
            object objectTemperatura = new Temperatura(temperatura);
            // Agir & Afirmar
            Assert.Equal(new Temperatura(temperatura), new Temperatura(temperatura));
            Assert.True(new Temperatura(temperatura).Equals(new Temperatura(temperatura)));
            Assert.True(new Temperatura(temperatura).Equals(objectTemperatura));
        }

        [Theory]
        [InlineData(0, 0.1)]
        [InlineData(34.5, 34.4)]
        [InlineData(54.3, 54.7)]
        public void DeveValidarTemperaturasDiferentes(decimal tempA, decimal tempB)
        {
            // Arranjar 
            Temperatura temperaturaA = tempA;
            Temperatura temperaturaB = tempB;

            // Agir & Afirmar
            Assert.NotEqual(temperaturaA, temperaturaB);
            Assert.False(temperaturaA.Equals(temperaturaB));
            Assert.False(temperaturaA == temperaturaB);
            Assert.True(temperaturaA != temperaturaB);
        }
    }
}
