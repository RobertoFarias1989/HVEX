using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEX.Infrastructure.Persistence;

public class MongoDbOptions
{
    public string ConnectionString { get; set; }
    public string Database { get; set; }
}
