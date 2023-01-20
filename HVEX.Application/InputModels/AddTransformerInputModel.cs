using HVEX.Core.Entities;
using HVEX.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEX.Application.InputModels;

public class AddTransformerInputModel
{
    public string Name { get;  set; }
    public int InternalNumber { get;  set; }        
    public int Potency { get;  set; }
    public int Current { get;  set; }

    public Transformer ToEntity()
        => new Transformer(
            Name,
            InternalNumber,
            Potency,
            Current);

}
