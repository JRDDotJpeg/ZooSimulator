using System;

namespace ZooSimulator.ServiceLayer
{
    internal class AnimalFactory : IAnimalFactory
    {
        public IAnimal MakeAnimal(AnimalData data)
        {
            switch (data.Category)
            {
                case AnimalCategory.InstantDeathAnimal:
                    return new InstantDeathAnimal(data);
                case AnimalCategory.DangerZoneAnimal:
                    return new DangerZoneAnimal(data);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}