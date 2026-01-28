using System.Collections.Generic;
using Examples.Designs.Anderson.Entities;
using Examples.Designs.Anderson.Helpers;
using Examples.Designs.Anderson.Repositories;

namespace Examples.Designs.Anderson.Infrastructures
{
    internal sealed class MeasureFake : IMeasureRepository
    {
        public MeasureEntity GetLatest()
        {
            return new MeasureEntity("guidA", "2017/01/01 13:00:00".ToDate(), 1.23456f);
        }

        private static readonly List<MeasureEntity> Entities = new()
        {
            new MeasureEntity("guidA", "2017/01/01 13:00:00".ToDate(), 1.23456f),
            new MeasureEntity("guidB", "2017/01/01 14:00:00".ToDate(), 2.23456f),
        };

        public IReadOnlyList<MeasureEntity> GetData()
        {
            return Entities;
        }

        public void Save(MeasureEntity entity)
        {
            var index = Entities.FindIndex(x => x.MeasureId == entity.MeasureId);
            if (index > 0)
            {
                Entities[index] = entity;
                return;
            }

            Entities.Add(entity);
        }
    }
}
