namespace ZooSimulator.ServiceLayer
{
    /// <summary>
    /// Object for passing information in and out of the service layer.
    /// Should remove this class and use a JSON object down the line.
    /// </summary>
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