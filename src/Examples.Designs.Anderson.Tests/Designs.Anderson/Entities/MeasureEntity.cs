using System;
using Examples.Designs.Anderson.ValueObjects;

namespace Examples.Designs.Anderson.Entities
{
    public sealed class MeasureEntity
    {

        public MeasureEntity(string measureId, DateTime measureDate, float measureValue)
        {
            MeasureId = measureId;
            MeasureDate = new MeasureDate(measureDate);
            MeasureValue = new MeasureValue(measureValue);
        }

        public string MeasureId { get; }
        public MeasureDate MeasureDate { get; }
        public MeasureValue MeasureValue { get; }

    }
}
