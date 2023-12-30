using Examples.DDD.Anderson.Entities;

namespace Examples.DDD.Anderson.Repositories
{
    public interface IMeasureRepository
    {
        MeasureEntity GetLatest();

        IReadOnlyList<MeasureEntity> GetData();

        void Save(MeasureEntity entity);

    }
}
