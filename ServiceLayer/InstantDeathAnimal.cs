namespace ZooSimulator.ServiceLayer
{
    internal class InstantDeathAnimal : Animal
    {
        private readonly float _deathThreshold;

        public InstantDeathAnimal(float deathThreshold)
        {
            _deathThreshold = deathThreshold;
        }

        public override float Health
        {
            get => _health;
            set
            {
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