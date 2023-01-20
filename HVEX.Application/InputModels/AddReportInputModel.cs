using HVEX.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEX.Application.InputModels;

public class AddReportInputModel
{    
    public string Name { get;  set; }

    public Report ToEntity()
       => new Report(Name);
}
