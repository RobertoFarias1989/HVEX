using HVEX.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEX.Core.Repositories;

public interface IReportRepository
{
    Task<List<Report>> GetAllAsync();
    Task<Report> GetByIdAsync(Guid id);
    Task AddAsync(Report report);   
    Task UpdateAsync(Report report);
}
