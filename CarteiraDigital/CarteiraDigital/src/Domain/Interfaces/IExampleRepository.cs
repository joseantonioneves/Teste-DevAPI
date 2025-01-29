namespace CarteiraDigital.Domain.Interfaces
{
    public interface IExampleRepository
    {
        ExampleEntity GetById(int id);
        IEnumerable<ExampleEntity> GetAll();
        void Add(ExampleEntity exampleEntity);
        void Remove(int id);
    }
}