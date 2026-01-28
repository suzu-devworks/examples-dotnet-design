using Examples.Designs.Anderson.Repositories;

namespace Examples.Designs.Anderson.Infrastructures
{
    public static class Factories
    {
        public static ISensorRepository CreateSensorRepository()
        {
            return new SensorFake();
        }

        public static IMeasureRepository CreateMeasureRepository()
        {
            return new MeasureFake();
        }
    }

}
