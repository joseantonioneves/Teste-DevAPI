using Xunit;
using Moq;
using CarteiraDigital.Domain.Entities;
using CarteiraDigital.Domain.Interfaces;
using CarteiraDigital.Infrastructure.Repositories;
using CarteiraDigital.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CarteiraDigital.Tests.Infrastructure.Tests
{
    public class ExampleRepositoryTests
    {
        private readonly ExampleDbContext _context;
        private readonly IExampleRepository _repository;

        public ExampleRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ExampleDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ExampleDbContext(options);
            _repository = new ExampleRepository(_context);
        }

        [Fact]
        public void Add_ShouldAddEntity()
        {
            var exampleEntity = new ExampleEntity { Id = 1, Name = "Test" };
            _repository.Add(exampleEntity);
            _context.SaveChanges();

            var result = _context.ExampleEntities.Find(1);
            Assert.NotNull(result);
            Assert.Equal("Test", result.Name);
        }

        [Fact]
        public void GetById_ShouldReturnEntity()
        {
            var exampleEntity = new ExampleEntity { Id = 1, Name = "Test" };
            _context.ExampleEntities.Add(exampleEntity);
            _context.SaveChanges();

            var result = _repository.GetById(1);
            Assert.NotNull(result);
            Assert.Equal("Test", result.Name);
        }

        [Fact]
        public void GetAll_ShouldReturnAllEntities()
        {
            _context.ExampleEntities.AddRange(new List<ExampleEntity>
            {
                new ExampleEntity { Id = 1, Name = "Test1" },
                new ExampleEntity { Id = 2, Name = "Test2" }
            });
            _context.SaveChanges();

            var result = _repository.GetAll().ToList();
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void Remove_ShouldDeleteEntity()
        {
            var exampleEntity = new ExampleEntity { Id = 1, Name = "Test" };
            _context.ExampleEntities.Add(exampleEntity);
            _context.SaveChanges();

            _repository.Remove(exampleEntity);
            _context.SaveChanges();

            var result = _context.ExampleEntities.Find(1);
            Assert.Null(result);
        }
    }
}