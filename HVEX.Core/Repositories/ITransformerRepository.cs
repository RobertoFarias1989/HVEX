using HVEX.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEX.Core.Repositories;

public interface ITransformerRepository
{
    Task<List<Transformer>> GetAllAsync();
    Task<Transformer> GetByIdAsync(Guid id);
    Task AddAsync(Transformer transformer);    
    Task UpdateAsync(Transformer transformer);
}
