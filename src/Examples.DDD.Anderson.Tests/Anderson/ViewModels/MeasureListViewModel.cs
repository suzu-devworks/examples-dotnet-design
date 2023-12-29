using System.ComponentModel;
using Examples.DDD.Anderson.Infrastructures;
using Examples.DDD.Anderson.Repositories;

namespace Examples.DDD.Anderson.ViewModels
{
    public class MeasureListViewModel : ViewModelBase
    {
        public MeasureListViewModel()
            : this(Factories.CreateMeasureRepository())
        {
        }

        public MeasureListViewModel(IMeasureRepository measureRepositor)
        {
            _measureRepositor = measureRepositor;
            foreach (var entity in _measureRepositor.GetData())
            {
                Measures.Add(new MeasureListViewModelMeasure(entity));
            }
        }

        private readonly IMeasureRepository _measureRepositor;

        public BindingList<MeasureListViewModelMeasure> Measures { get; } = new();

    }
}
