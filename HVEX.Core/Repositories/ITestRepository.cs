using HVEX.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEX.Core.Repositories;

public interface ITestRepository
{
    Task<List<Test>> GetAllAsync();
    Task<Test> GetByIdAsync(Guid id);
    Task AddAsync(Test test);  
    Task UpdateAsync(Test test);
}
