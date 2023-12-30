using Examples.DDD.Anderson.ValueObjects;

namespace Examples.DDD.Anderson.Repositories
{
    public interface ISensorRepository
    {
        MeasureValue GetData();
    }

}
