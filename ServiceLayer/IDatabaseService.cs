using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace ZooSimulator.ServiceLayer
{
    public interface IDatabaseService
    {
        List<AnimalData> FetchAnimals();

        void UpdateDatabase(List<AnimalData> animals);
    }
}