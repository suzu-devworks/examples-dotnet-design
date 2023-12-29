using Examples.DDD.Anderson.Helpers;
using Examples.DDD.Anderson.Repositories;
using Examples.DDD.Anderson.ValueObjects;

namespace Examples.DDD.Anderson.Infrastructures
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
