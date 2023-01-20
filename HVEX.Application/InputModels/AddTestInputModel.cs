using HVEX.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEX.Application.InputModels;

public class AddTestInputModel
{
    public string Name { get;  set; }       
    public DateTime Duration { get;  set; }

    public Test ToEntity()
        => new Test(Name, Duration);
}
