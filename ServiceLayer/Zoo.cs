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
        private DateTime _timeAtTheZoo;
        private DateTime _lastAppliedDamage;

        public Zoo(IDatabaseHandler databaseHandler)
        {
            _databaseHandler = databaseHandler;
            _animals = _databaseHandler.FetchAllAnimals();
            _timeAtTheZoo = DateTime.Now;
            _lastAppliedDamage = _timeAtTheZoo;
            _timer.Interval = 1000;
            _timer.Start();
            _timer.Elapsed += OnTimerTick;
        }

        public void FeedAllAnimals()
        {
            var random = new Random();
            var percentToHealTypesBy = new Dictionary<AnimalType, float>();
            foreach (AnimalType type in Enum.GetValues(typeof(AnimalType)))
            {
                var modifer = (float)(random.Next(10, 25) / 100.00);
                percentToHealTypesBy.Add(type, modifer);
            }
            foreach (var animal in _animals)
            {
                animal.Health *= 1 + percentToHealTypesBy[animal.Type];

            }
        }

        public List<AnimalData> GetAnimalData()
        {
            return null;
        }

        public DateTime GetTimeAtTheZoo()
        {
            return _timeAtTheZoo;
        }

        private void OnTimerTick(object sender, ElapsedEventArgs e)
        {
            _timeAtTheZoo = _timeAtTheZoo.AddMinutes(3);
            if (_timeAtTheZoo - _lastAppliedDamage > TimeSpan.FromHours(1))
            {
                OnHourEvent();
                _lastAppliedDamage = _timeAtTheZoo;
            }
        }

        private void OnHourEvent()
        {
            var random = new Random();
            foreach (var animal in _animals)
            {
                animal.OnHourEvent();
                var modifer = random.Next(0,20);
                animal.Health *= (1 - (float)(modifer/100.00));
            }
        }
    }
}