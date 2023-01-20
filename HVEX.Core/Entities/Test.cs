using HVEX.Core.Enums;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEX.Core.Entities
{
    public class Test
    {
        public Test(string name,DateTime duration)
        {
            TestId = Guid.NewGuid();
            Name = name;            
            Duration = duration;

            Status = TestStatusEnum.WaitingAnalyse;
           
        }

        public Test(Guid testId, string name, TestStatusEnum status, DateTime duration)
        {
            TestId = testId;
            Name = name;
            Status = status;
            Duration = duration;
        }

        [BsonId]
        public Guid TestId { get; private set; }
        public string Name { get; private set; }
        public TestStatusEnum Status { get; private set; }
        public DateTime Duration { get; private set; }
       
    }
}
