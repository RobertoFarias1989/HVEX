using HVEX.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HVEX.Application.InputModels;

public class UpdateUserInputModel
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public List<TransformerInputModel> Transformers { get; set; }   

    public User ToEntity()
        => new User(UserId,Name, Email,
            new List<Transformer>
            {
                new Transformer(
                    Transformers[0].Name,
                    Transformers[0].InternalNumber,
                    Transformers[0].Potency,
                    Transformers[0].Current),
            });

}

public class TransformerInputModel {

    public string Name { get;  set; }
    public int InternalNumber { get;  set; }
    public int Potency { get;  set; }
    public int Current { get;  set; }

    public Transformer ToEntity()
        => new Transformer(Name,InternalNumber,Potency,Current);
}