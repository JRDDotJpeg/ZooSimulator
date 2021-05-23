namespace ZooSimulator.ServiceLayer
{
    internal class InstantDeathAnimal : Animal
    {
        private readonly float _deathThreshold;

        public InstantDeathAnimal(AnimalData data)
        {
            _deathThreshold = data.CategoryRelatedHealthValue;
            UniqueId = data.UniqueId;
            Health = data.Health;
            State = data.State;
            Type = data.Type;
        }

        public override float Health
        {
            get => _health;
            set
            {
                if(State == State.Dead) return;
                
                SetHealth(value);
                if (_health < _deathThreshold)
                {
                    State = State.Dead;
                }
            }
        }

        public override void OnHourEvent()
        {
            // Nothing to do here.
        }

        public override AnimalData ToAnimalData()
        {
            return new AnimalData()
            {
                UniqueId = this.UniqueId,
                Health = this.Health,
                Type = this.Type,
                Category = AnimalCategory.InstantDeathAnimal,
                State = this.State,
                PublicFacingDangerZoneName = "",
                CategoryRelatedHealthValue = this._deathThreshold
            };
        }
    }
}