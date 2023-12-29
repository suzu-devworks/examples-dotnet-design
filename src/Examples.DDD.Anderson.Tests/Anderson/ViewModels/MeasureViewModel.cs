using Examples.DDD.Anderson.Infrastructures;
using Examples.DDD.Anderson.Repositories;

namespace Examples.DDD.Anderson.ViewModels
{
    public class MeasureViewModel : ViewModelBase
    {
        public MeasureViewModel()
            : this(Factories.CreateSensorRepository())
        {
        }

        public MeasureViewModel(ISensorRepository sensorRepository)
        {
            _sensorRepository = sensorRepository;
        }

        private readonly ISensorRepository _sensorRepository;

        public string? MeasureValue
        {
            get { return _measureValue; }
            set { SetProperty(ref _measureValue, value); }
        }
        private string? _measureValue = "--";

        public void Measure()
        {
            var measureValue = _sensorRepository.GetData();
            MeasureValue = measureValue.DisplayValue;
        }

    }
}
