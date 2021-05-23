using System;
using System.Collections.Generic;

namespace ZooSimulator.ServiceLayer
{
    public interface IZoo
    {
        void FeedAllAnimals();

        List<AnimalData> GetAnimalData();

        DateTime GetTimeAtTheZoo();
    }
}
