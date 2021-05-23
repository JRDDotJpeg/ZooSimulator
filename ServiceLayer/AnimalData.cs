namespace ZooSimulator.ServiceLayer
{
    public struct AnimalData
    {
        public int UniqueId { get; set; }
        public float Health { get; set; }
        public AnimalType Type { get; set; }
        public AnimalCategory Category { get; set; }
        public State State { get; set; }

        public string PublicFacingDangerZoneName { get; set; }

        public float CategoryRelatedHealthValue { get; set; }
    }
}