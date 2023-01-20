using HVEX.Core.Entities;
using HVEX.Core.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEX.Infrastructure.Persistence.Repositories;

public class TestRepository : ITestRepository
{
    private readonly IMongoCollection<Test> _collection;
    public TestRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<Test>("tests");
    }
    public async Task<List<Test>> GetAllAsync()
    {
        return await _collection.Find(c => true).ToListAsync();
    }

    public async Task<Test> GetByIdAsync(Guid id)
    {
        return await _collection.Find(c => c.TestId == id).SingleOrDefaultAsync();
    }
    public async Task AddAsync(Test test)
    {
        await _collection.InsertOneAsync(test);
    } 
    public async Task UpdateAsync(Test test)
    {
        await _collection
            .ReplaceOneAsync(c => c.TestId == test.TestId,test);
    }
}
