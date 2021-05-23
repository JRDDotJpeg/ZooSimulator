namespace ZooSimulator.ServiceLayer
{
    internal class DangerZoneAnimal : Animal
    {
        public string DangerZoneCustomerFacingName { get;}
        private readonly float _dangerZoneThreshold;

        public DangerZoneAnimal(float dangerZoneThreshold, string dangerZoneCustomerFacingName)
        {
            _dangerZoneThreshold = dangerZoneThreshold;
            DangerZoneCustomerFacingName = dangerZoneCustomerFacingName;
        }

        public override float Health
        {
            get => _health;
            set
            {
                SetHealth(value);
                if (_health < _dangerZoneThreshold)
                {
                    State = State.DangerZone;
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