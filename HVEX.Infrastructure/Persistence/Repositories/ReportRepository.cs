using HVEX.Core.Entities;
using HVEX.Core.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEX.Infrastructure.Persistence.Repositories;

public class ReportRepository : IReportRepository
{
    private readonly IMongoCollection<Report> _collection;
    public ReportRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<Report>("reports");
    }
    public async Task<List<Report>> GetAllAsync()
    {
        return await _collection.Find(c => true).ToListAsync();
    }

    public async Task<Report> GetByIdAsync(Guid id)
    {
        return await _collection.Find(c => c.ReportId == id).SingleOrDefaultAsync();
    }

    public async Task AddAsync(Report report)
    {
        await _collection.InsertOneAsync(report);
    }   
    
    public async Task UpdateAsync(Report report)
    {
        await _collection
            .ReplaceOneAsync(c => c.ReportId == report.ReportId , report);
    }
}
