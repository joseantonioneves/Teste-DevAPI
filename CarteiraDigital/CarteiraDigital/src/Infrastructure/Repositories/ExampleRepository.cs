using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CarteiraDigital.Domain.Entities;
using CarteiraDigital.Domain.Interfaces;

namespace CarteiraDigital.Infrastructure.Repositories
{
    public class ExampleRepository : IExampleRepository
    {
        private readonly ExampleDbContext _context;

        public ExampleRepository(ExampleDbContext context)
        {
            _context = context;
        }

        public ExampleEntity GetById(int id)
        {
            return _context.ExampleEntities.Find(id);
        }

        public IEnumerable<ExampleEntity> GetAll()
        {
            return _context.ExampleEntities.ToList();
        }

        public void Add(ExampleEntity entity)
        {
            _context.ExampleEntities.Add(entity);
            _context.SaveChanges();
        }

        public void Remove(ExampleEntity entity)
        {
            _context.ExampleEntities.Remove(entity);
            _context.SaveChanges();
        }
    }
}