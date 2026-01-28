using Examples.Designs.Anderson.Infrastructures;
using Examples.Designs.Anderson.Repositories;

namespace Examples.Designs.Anderson.ViewModels
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
