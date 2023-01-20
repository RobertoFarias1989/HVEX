using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEX.Core.Entities
{
    public class ReportTest
    {
        public ReportTest(Guid reportId, Test test, List<Transformer> transformers)
        {
            ReportId = reportId;
            Test = test;
            Transformers = transformers;
        }

        public Guid ReportId { get; private set; }
        public Test Test { get; private set; }
        public List<Transformer> Transformers { get; private set; }
    }
}
