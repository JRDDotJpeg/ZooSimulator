namespace ZooSimulator.ServiceLayer
{
    public interface IAnimal
    {
        int UniqueId { get; set; }

        AnimalType Type { get; set; }

        float Health { get; set; }

        State State { get; set; }
        
        void OnHourEvent();

        AnimalData ToAnimalData();

    }
}