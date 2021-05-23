using System.Collections.Generic;

namespace ZooSimulator.ServiceLayer
{
    public class DatabaseService : IDatabaseService
    {
        public List<AnimalData> FetchAnimals()
        {
            var id = 1;
            var animals = new List<AnimalData>();

            // Elephants
            for(var i = 0; i < 5; i++)
            {
                var elephant = new AnimalData();
                {
                    elephant.State = State.Healthy;
                    elephant.Category = AnimalCategory.DangerZoneAnimal;
                    elephant.PublicFacingDangerZoneName = "Cannot walk";
                    elephant.Health = 100;
                    elephant.Type = AnimalType.Elephant;
                    elephant.UniqueId = id++;
                    elephant.CategoryRelatedHealthValue = 70;
                }
            }

            // Monkeys
            for (var i = 0; i < 5; i++)
            {
                var monkey = new AnimalData();
                {
                    monkey.State = State.Healthy;
                    monkey.Category = AnimalCategory.InstantDeathAnimal;
                    monkey.Health = 100;
                    monkey.Type = AnimalType.Monkey;
                    monkey.UniqueId = id++;
                    monkey.CategoryRelatedHealthValue = 30;
                }
            }

            // Giraffe
            for (var i = 0; i < 5; i++)
            {
                var giraffe = new AnimalData();
                {
                    giraffe.State = State.Healthy;
                    giraffe.Category = AnimalCategory.InstantDeathAnimal;
                    giraffe.Health = 100;
                    giraffe.Type = AnimalType.Giraffe;
                    giraffe.UniqueId = id++;
                    giraffe.CategoryRelatedHealthValue = 50;
                }
            }

            return animals;
        }

        public void UpdateDatabase(List<AnimalData> animals)
        {
            // Do nothing because this is a demo application.
        }
    }
}