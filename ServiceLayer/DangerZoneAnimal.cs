namespace ZooSimulator.ServiceLayer
{
    internal class DangerZoneAnimal : Animal
    {
        public string DangerZoneCustomerFacingName { get;}
        private readonly float _dangerZoneThreshold;

        public DangerZoneAnimal(AnimalData data) : base(data)
        {
            _dangerZoneThreshold = data.CategoryRelatedHealthValue;
            DangerZoneCustomerFacingName = data.PublicFacingDangerZoneName;
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
                UniqueId = this.UniqueId, // Duplicated code here, move into the base class.
                Health = this.Health,
                Type = this.Type,
                State = this.State,
                Category = AnimalCategory.DangerZoneAnimal,
                PublicFacingDangerZoneName = this.DangerZoneCustomerFacingName,
                CategoryRelatedHealthValue = this._dangerZoneThreshold
            };
        }
    }
}