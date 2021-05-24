namespace ZooSimulator.ServiceLayer
{
    internal abstract class Animal : IAnimal
    {
        protected Animal(AnimalData data)
        {
            UniqueId = data.UniqueId;
            Health = data.Health;
            State = data.State;
            Type = data.Type;
        }

        public int UniqueId { get; set; }
        public AnimalType Type { get; set; }
        protected float _health;

        public virtual float Health
        {
            get => _health;
            set => SetHealth(value);
        }

        protected void SetHealth(float value)
        {
            if (State == State.Dead) return;
            _health = value;
            if (_health > 100) Health = 100;
            if (_health < 0) Health = 0;
        }

        public State State { get; set; }

        public abstract void OnHourEvent();

        // I have made this abstract to force each derived class to overload it so that this can't be missed
        // while adding a new category of animal.
        public abstract AnimalData ToAnimalData();
    }
}