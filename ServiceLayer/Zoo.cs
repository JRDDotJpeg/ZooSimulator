using System;
using System.Collections.Generic;
using System.Timers;

namespace ZooSimulator.ServiceLayer
{
    public class Zoo : IZoo
    {
        private IDatabaseHandler _databaseHandler;
        private List<IAnimal> _animals;
        private readonly Timer _timer = new Timer();
        private DateTime _timeAtTheZoo = DateTime.Now;

        public Zoo(IDatabaseHandler databaseHandler)
        {
            _databaseHandler = databaseHandler;
            _animals = _databaseHandler.FetchAllAnimals();
            _timer.Start();
            _timer.Elapsed += _timer_Elapsed;
        }

        public void FeedAllAnimals()
        {
            var random = new Random();
            var percentToHealTypesBy = new Dictionary<AnimalType, int>();
            foreach (AnimalType type in Enum.GetValues(typeof(AnimalType)))
            {
                percentToHealTypesBy.Add(type, random.Next(10, 25));
            }
            foreach (var animal in _animals)
            {
                animal.Health *= 1 + percentToHealTypesBy[animal.Type];

            }
        }

        public List<AnimalData> GetAnimalData()
        {
            throw new System.NotImplementedException();
        }

        public DateTime GetTimeAtTheZoo()
        {
            return _timeAtTheZoo;
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _timeAtTheZoo.AddMinutes(3);
            if (_timeAtTheZoo.Minute == 0)
            {
                OnHourEvent();
            }
        }

        private void OnHourEvent()
        {
            var random = new Random();
            foreach (var animal in _animals)
            {
                animal.OnHourEvent();
                var modifer = random.Next(0,20);
                animal.Health *= (1 - modifer);
            }
        }
    }
}