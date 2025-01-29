using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarteiraDigital.Domain.Entities;
using CarteiraDigital.Domain.Interfaces;

namespace CarteiraDigital.Application.Services
{
    public class ExampleService
    {
        private readonly IExampleRepository _exampleRepository;

        public ExampleService(IExampleRepository exampleRepository)
        {
            _exampleRepository = exampleRepository;
        }

        public async Task<ExampleEntity> CreateAsync(ExampleEntity exampleEntity)
        {
            // Logic to create an ExampleEntity
            await _exampleRepository.Add(exampleEntity);
            return exampleEntity;
        }

        public async Task<ExampleEntity> UpdateAsync(ExampleEntity exampleEntity)
        {
            // Logic to update an ExampleEntity
            await _exampleRepository.Update(exampleEntity);
            return exampleEntity;
        }

        public async Task DeleteAsync(Guid id)
        {
            // Logic to delete an ExampleEntity by id
            await _exampleRepository.Remove(id);
        }

        public async Task<ExampleEntity> GetByIdAsync(Guid id)
        {
            // Logic to get an ExampleEntity by id
            return await _exampleRepository.GetById(id);
        }

        public async Task<IEnumerable<ExampleEntity>> GetAllAsync()
        {
            // Logic to get all ExampleEntities
            return await _exampleRepository.GetAll();
        }
    }
}