using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEX.Core.Entities;

public class User
{  
    public User(string name, string email)
    {
        UserId = Guid.NewGuid();
        Name = name;
        Email = email;

        Transformers = new List<Transformer>();
    }

    public User(Guid userId, string name, string email, List<Transformer> transformers)
    {
        UserId = userId;
        Name = name;
        Email = email;
        Transformers = transformers;
    }

    [BsonId]
    public Guid UserId { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public List<Transformer> Transformers { get; private set; }    

}
