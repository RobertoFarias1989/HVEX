using HVEX.Core.Entities;
using HVEX.Core.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEX.Infrastructure.Persistence.Repositories;

public class TransformerRepository : ITransformerRepository
{
    private readonly IMongoCollection<Transformer> _collection;
    public TransformerRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<Transformer>("transformers");
    }
    public async Task<List<Transformer>> GetAllAsync()
    {
        return await _collection.Find(c => true).ToListAsync();
    }

    public async Task<Transformer> GetByIdAsync(Guid id)
    {
        return await _collection.Find(c => c.TransformerId == id).SingleOrDefaultAsync();
    }
    public async Task AddAsync(Transformer transformer)
    {
        await _collection.InsertOneAsync(transformer);
    }

    public async Task UpdateAsync(Transformer transformer)
    {
        await _collection
            .ReplaceOneAsync(c => c.TransformerId == transformer.TransformerId, transformer);
    }
}
