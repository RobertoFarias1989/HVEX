using HVEX.Core.Entities;
using HVEX.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEX.Application.ViewModels
{
    public class ReportViewModel
    {
        public ReportViewModel(Guid reportId, string name, string status)
        {
            ReportId = reportId;
            Name = name;
            Status = status;
        }

        public Guid ReportId { get; private set; }
        public string Name { get; private set; }
        public string Status { get; private set; }
        


        public static ReportViewModel FromEntity(Report report)
        {          

            return new ReportViewModel(report.ReportId,report.Name,
                report.Status.ToString());
        }
    }
}
