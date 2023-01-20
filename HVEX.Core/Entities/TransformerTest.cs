using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEX.Core.Entities
{
    public class TransformerTest
    {
        public TransformerTest(Guid testId, Test test, List<Report> report)
        {
            TestId = testId;
            Test = test;
            Report = report;
        }

        public Guid TestId { get; private set; }
        public Test Test { get; private set; }
        public List<Report> Report { get; private set; }
    }
}
