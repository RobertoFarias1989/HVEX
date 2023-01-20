using HVEX.Core.Enums;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEX.Core.Entities
{
    public class Report
    {
        public Report(string name)
        {
            ReportId = Guid.NewGuid();
            Name = name;  
            
            Status = RepostStatusEnum.WaitingAnalyse;
            ReportTests = new List<ReportTest>();
        }

        public Report(Guid reportId, string name, RepostStatusEnum status, List<ReportTest> reportTests)
        {
            ReportId = reportId;
            Name = name;
            Status = status;
            ReportTests = reportTests;
        }

        [BsonId]
        public Guid ReportId { get; private set; }
        public string Name { get; private set; }
        public RepostStatusEnum Status { get; private set; }
        public List<ReportTest> ReportTests { get; private set; }
    }
}
