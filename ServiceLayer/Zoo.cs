using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace ZooSimulator.ServiceLayer
{
    // This class does too much.
    // The datetime and timer should be moved out into their own class which is injected.
    // The handle feeding and injuring code should be moved into an injected animal handler class.
    public class Zoo : IZoo
    {
        private const int cZooMinutesPerSecond = 3; // These should be pulled from the DB, would allow more testing.
        private const int cMinimumHeal = 10;
        private const int cMaxHeal = 25;
        private const int cMinDamage = 0;
        private const int cMaxDamage = 20;

        private readonly IDatabaseHandler _databaseHandler; // Don't make a local as resharper suggests, needed as member for extension.
        private readonly List<IAnimal> _animals;
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
                var modifer = (float)(random.Next(cMinimumHeal, cMaxHeal) / 100.00);
                percentToHealTypesBy.Add(type, modifer);
            }
            foreach (var animal in _animals)
            {
                animal.Health *= 1 + percentToHealTypesBy[animal.Type];
            }
        }

        public List<AnimalData> GetAnimalData()
        {
            return _animals.Select(animal => animal.ToAnimalData()).ToList();
        }

        public DateTime GetTimeAtTheZoo()
        {
            return _timeAtTheZoo;
        }

        private void OnTimerTick(object sender, ElapsedEventArgs e)
        {
            _timeAtTheZoo = _timeAtTheZoo.AddMinutes(cZooMinutesPerSecond);
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
                var modifer = random.Next(cMinDamage, cMaxDamage);
                animal.Health *= (1 - (float)(modifer/100.00));
            }
        }
    }
}