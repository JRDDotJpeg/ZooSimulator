using System.Collections.Generic;

namespace ZooSimulator.ServiceLayer
{
    public interface IDatabaseHandler
    {
        List<IAnimal> FetchAllAnimals();

        void UpdateDatabase(List<IAnimal> animals);
    }

    class DatabaseHandler : IDatabaseHandler
    {
        private DatabaseService _databaseService;
        public List<IAnimal> FetchAllAnimals()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateDatabase(List<IAnimal> animals)
        {
            throw new System.NotImplementedException();
        }
    }
}