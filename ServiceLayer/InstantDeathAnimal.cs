namespace ZooSimulator.ServiceLayer
{
    internal class InstantDeathAnimal : Animal
    {
        private readonly float _deathThreshold;

        public InstantDeathAnimal(AnimalData data) : base(data)
        {
            _deathThreshold = data.CategoryRelatedHealthValue;
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
            // Instant death animals don't currently react to time passing directly.
            // As such we don't need to do anything here.
        }

        public override AnimalData ToAnimalData()
        {
            return new AnimalData()
            {
                UniqueId = this.UniqueId,  // Duplicated code here, move into the base class.
                Health = this.Health,
                Type = this.Type,
                State = this.State,
                Category = AnimalCategory.InstantDeathAnimal,
                PublicFacingDangerZoneName = "", // Not ideal but not worth creating a new object to avoid.
                CategoryRelatedHealthValue = this._deathThreshold
            };
        }
    }
}