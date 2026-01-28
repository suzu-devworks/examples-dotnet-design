using System.Collections.Generic;
using Examples.Designs.Anderson.Entities;

namespace Examples.Designs.Anderson.Repositories
{
    public interface IMeasureRepository
    {
        MeasureEntity GetLatest();

        IReadOnlyList<MeasureEntity> GetData();

        void Save(MeasureEntity entity);

    }
}
