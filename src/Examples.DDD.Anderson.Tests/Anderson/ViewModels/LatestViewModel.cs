using Examples.DDD.Anderson.Infrastructures;
using Examples.DDD.Anderson.Repositories;

namespace Examples.DDD.Anderson.ViewModels
{
    public class LatestViewModel : ViewModelBase
    {
        public LatestViewModel()
            : this(Factories.CreateMeasureRepository())
        {
        }

        public LatestViewModel(IMeasureRepository measureRepository)
        {
            _measureRepository = measureRepository;
            var entity = _measureRepository.GetLatest();
            MeasureDate = entity.MeasureDate.Value.ToString("yyyy/MM/dd HH:mm:ss");
            MeasureValue = entity.MeasureValue.DisplayValue;
        }
        private readonly IMeasureRepository _measureRepository;

        private string? _measureDate = "";
        public string? MeasureDate
        {
            get { return _measureDate; }
            set { SetProperty(ref _measureDate, value); }
        }

        private string? _measureValue = "";
        public string? MeasureValue
        {
            get { return _measureValue; }
            set { SetProperty(ref _measureValue, value); }
        }

    }

}
