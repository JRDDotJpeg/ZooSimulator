namespace ZooSimulator.ServiceLayer
{
    internal class DangerZoneAnimal : Animal
    {
        public string DangerZoneCustomerFacingName { get;}
        private readonly float _dangerZoneThreshold;

        public DangerZoneAnimal(AnimalData data)
        {
            _dangerZoneThreshold = data.CategoryRelatedHealthValue;
            DangerZoneCustomerFacingName = data.PublicFacingDangerZoneName;
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
                if (State == State.Dead) return;

                SetHealth(value);
                if (_health < _dangerZoneThreshold)
                {
                    State = State.DangerZone;
                }

                if (_health >= _dangerZoneThreshold) // Could use else here, this feels clearer.
                {
                    State = State.Healthy;
                }
            }
        }

        public override void OnHourEvent()
        {
            if (State == State.DangerZone) State = State.Dead;
        }

        public override AnimalData ToAnimalData()
        {
            return new AnimalData()
            {
                UniqueId = this.UniqueId,
                Health = this.Health,
                Type = this.Type,
                Category = AnimalCategory.DangerZoneAnimal,
                State = this.State,
                PublicFacingDangerZoneName = this.DangerZoneCustomerFacingName,
                CategoryRelatedHealthValue = this._dangerZoneThreshold
            };
        }
    }
}