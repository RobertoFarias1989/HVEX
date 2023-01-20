using HVEX.Core.Entities;
using HVEX.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEX.Application.ViewModels;

public class TestViewModel
{
    public TestViewModel(Guid id, string name, string status, DateTime duration)
    {
        Id = id;
        Name = name;
        Status = status;
        Duration = duration;
    }
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Status { get; private set; }
    public DateTime Duration { get; private set; } 
    
    public static TestViewModel FromEntity(Test test)
    {
        return new TestViewModel(test.TestId,test.Name,test.Status.ToString(),test.Duration);
    }
}
