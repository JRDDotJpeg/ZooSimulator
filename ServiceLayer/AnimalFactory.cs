using System;

namespace ZooSimulator.ServiceLayer
{
    class AnimalFactory : IAnimalFactory
    {
        public IAnimal MakeAnimal(AnimalData data)
        {
            switch (data.Category)
            {
                case AnimalCategory.InstantDeathAnimal:
                    return new InstantDeathAnimal(data.CategoryRelatedHealthValue)
                    {
                        UniqueId = data.UniqueId, //Todo sort out what's in the constructor and what's not
                        Health = data.Health,
                        State = data.State,
                        Type = data.Type
                    };
                
                case AnimalCategory.DangerZoneAnimal:
                    return new DangerZoneAnimal(data.CategoryRelatedHealthValue, data.PublicFacingDangerZoneName)
                    {
                        UniqueId = data.UniqueId,
                        Health = data.Health,
                        State = data.State,
                        Type = data.Type
                    };
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}