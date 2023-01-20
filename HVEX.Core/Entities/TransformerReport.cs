using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEX.Core.Entities
{
    public class TransformerReport
    {
        public TransformerReport(Guid reportId, Guid testId, Report report, Test test)
        {
            ReportId = reportId;
            TestId = testId;
            Report = report;
            Test = test;
        }

        public Guid ReportId { get; private set; }
        public Guid TestId { get; private set; }
        public Report Report { get; private set; }
        public Test  Test { get; private set; }
    }
}
