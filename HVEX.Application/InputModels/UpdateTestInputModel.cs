using HVEX.Core.Entities;
using HVEX.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEX.Application.InputModels;

public class UpdateTestInputModel
{
    public Guid TestId { get;  set; }
    public string Name { get;  set; }
    public string Status { get;  set; }
    public DateTime Duration { get;  set; }

    public Test ToEntity()
        => new Test(TestId, Name, (TestStatusEnum)Enum.Parse(typeof(TestStatusEnum),Status), Duration);
}
