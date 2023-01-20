using HVEX.Core.Entities;
using HVEX.Core.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEX.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IMongoCollection<User> _collection;

    public UserRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<User>("users");
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _collection.Find(c => true).ToListAsync();
    }
    public async Task<User> GetByIdAsync(Guid id)
    {
        return await _collection.Find(c => c.UserId == id).SingleOrDefaultAsync();
    }
    public async Task AddAsync(User user)
    {
        await _collection.InsertOneAsync(user);
    }

    public async Task UpdateAsync(User user)
    {
        await _collection
            .ReplaceOneAsync(s => s.UserId == user.UserId, user);
    }
}
