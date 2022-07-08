using System;
using System.Text.Json;

namespace Desafio.AMcom.Entity
{
    public struct Temperatura : IEquatable<Temperatura>
    {
        public static implicit operator Temperatura(decimal temperatura)
        {
            return new Temperatura(temperatura);
        }

        public Temperatura(decimal temperatura)
        {
            ValorFahrenheit = temperatura;
        }

        public decimal ValorFahrenheit { get; }
        public decimal ValorCelsius { get => (ValorFahrenheit - 32.0m) / 1.8m; }
        public decimal ValorKelvin { get => ValorCelsius + 273.15m; }

        public override bool Equals(object obj)
        {
            return obj is Temperatura temperatura && Equals(temperatura);
        }

        public bool Equals(Temperatura other)
        {
            return ValorFahrenheit == other.ValorFahrenheit &&
                   ValorCelsius == other.ValorCelsius &&
                   ValorKelvin == other.ValorKelvin;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ValorFahrenheit, ValorCelsius, ValorKelvin);
        }

        public static bool operator ==(Temperatura left, Temperatura right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Temperatura left, Temperatura right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}