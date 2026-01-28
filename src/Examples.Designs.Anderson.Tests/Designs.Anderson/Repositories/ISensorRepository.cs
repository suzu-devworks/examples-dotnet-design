using Examples.Designs.Anderson.ValueObjects;

namespace Examples.Designs.Anderson.Repositories
{
    public interface ISensorRepository
    {
        MeasureValue GetData();
    }

}
