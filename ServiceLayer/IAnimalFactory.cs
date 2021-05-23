namespace ZooSimulator.ServiceLayer
{
    public interface IAnimalFactory
    {
        IAnimal MakeAnimal(AnimalData data);
    }
}