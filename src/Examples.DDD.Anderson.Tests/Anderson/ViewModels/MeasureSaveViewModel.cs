using Examples.DDD.Anderson.Entities;
using Examples.DDD.Anderson.Helpers;
using Examples.DDD.Anderson.Infrastructures;
using Examples.DDD.Anderson.Repositories;

namespace Examples.DDD.Anderson.ViewModels
{
    public class MeasureSaveViewModel : ViewModelBase
    {
        public MeasureSaveViewModel()
            : this(Factories.CreateMeasureRepository())
        {
        }

        public MeasureSaveViewModel(IMeasureRepository measureRepository)
        {
            _measureRepository = measureRepository;
            _measureDate = GetDateTime();
        }

        private readonly IMeasureRepository _measureRepository;

        public DateTime MeasureDate
        {
            get { return _measureDate; }
            set
            {
                SetProperty(ref _measureDate, value);
            }
        }
        private DateTime _measureDate;

        public string? MeasureValue
        {
            get { return _measureValue; }
            set { SetProperty(ref _measureValue, value); }
        }

        private string? _measureValue = "";

        public string UnitLabel { get; }
            = ValueObjects.MeasureValue.UnitName;

        public virtual DateTime GetDateTime()
        {
            return DateTime.Now;
        }

        public void Save()
        {
            Guard.IsNullOrEmptyMessage(MeasureValue, "計測値を入力してください");

            var measureValue = Convert.ToSingle(MeasureValue);
            var entity = new MeasureEntity(
                Guid.NewGuid().ToString()
                , MeasureDate
                , measureValue);

            _measureRepository.Save(entity);
        }

    }
}
