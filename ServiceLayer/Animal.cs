namespace ZooSimulator.ServiceLayer
{
    internal abstract class Animal : IAnimal
    {
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

        public abstract AnimalData ToAnimalData();
    }
}