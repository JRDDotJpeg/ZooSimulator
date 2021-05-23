using System.Collections.Generic;
using System.Linq;

namespace ZooSimulator.ServiceLayer
{
    public interface IDatabaseHandler
    {
        List<IAnimal> FetchAllAnimals();

        void UpdateDatabase(List<IAnimal> animals);
    }

    class DatabaseHandler : IDatabaseHandler
    {
        private IDatabaseService _databaseService;
        private IAnimalFactory _animalFactory;

        public DatabaseHandler(IDatabaseService databaseService, IAnimalFactory animalFactory)
        {
            _databaseService = databaseService;
            _animalFactory = animalFactory;
        }

        public List<IAnimal> FetchAllAnimals()
        {
            return _databaseService.FetchAnimals()
                .Select(animalData => _animalFactory.MakeAnimal(animalData))
                .ToList();
        }

        public void UpdateDatabase(List<IAnimal> animals)
        {
            var animalData = animals.Select(animal => animal.ToAnimalData()).ToList();
            _databaseService.UpdateDatabase(animalData);
        }
    }
}