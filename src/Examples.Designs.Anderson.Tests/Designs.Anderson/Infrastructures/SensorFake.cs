using System;
using Examples.Designs.Anderson.Helpers;
using Examples.Designs.Anderson.Repositories;
using Examples.Designs.Anderson.ValueObjects;

namespace Examples.Designs.Anderson.Infrastructures
{
    internal sealed class SensorFake : ISensorRepository
    {
        private readonly Random _random = new();

        public MeasureValue GetData()
        {
            return new MeasureValue(_random.Next(0, 3) + _random.NextDouble().ToSingle());
        }
    }
}
