using HVEX.Core.Entities;
using HVEX.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEX.Application.InputModels;

public class UpdateTransformerInputModel
{
    public Guid TransformerId { get;  set; }
    public string Name { get;  set; }
    public int InternalNumber { get;  set; }
    public string Tension { get;  set; }
    public int Potency { get;  set; }
    public int Current { get;  set; }
    public List<AddTestInputModel> Tests { get;  set; }
    public List<TransformerTestInputModel> TransformerTests { get;  set; }
    public List<TransformerReportInputModel> TransformerReports { get;  set; }

    public Transformer ToEntity()
        => new Transformer(TransformerId, Name, InternalNumber,
            (TransformerTensionEnum)Enum.Parse(typeof(TransformerTensionEnum), Tension)
            , Potency,Current,
            new List<Test>
            {
                new Test(Tests[0].Name,Tests[0].Duration)
            },            
            new List<TransformerTest>
            {
                new TransformerTest(TransformerTests[1].TestId,
                    new Test(TransformerTests[2].Test.Name,TransformerTests[2].Test.Duration),
                    new List<Report>
                    {
                        new Report(TransformerTests[1].Report[1].Name)
                    })
            },  
            new List<TransformerReport>
            {
                new TransformerReport(TransformerReports[0].ReportId,
                    TransformerReports[0].TestId,
                    TransformerReports[0].Report.ToEntity(),
                    TransformerReports[0].Test.ToEntity())
            });
}

public class TransformerTestInputModel
{
    public Guid TestId { get;  set; }
    public AddTestInputModel Test { get;  set; }
    public List<AddReportInputModel> Report { get; set; }

    public TransformerTest ToEntity()
        => new TransformerTest(TestId,Test.ToEntity(), 
            new List<Report>
            {
                new Report(Report[0].Name)
            });

}

public class TransformerReportInputModel
{
    public Guid ReportId { get; private set; }
    public Guid TestId { get; private set; }
    public AddReportInputModel Report { get; private set; }
    public AddTestInputModel Test { get; private set; }

    public TransformerReport ToEntity()
        => new TransformerReport(ReportId, TestId, Report.ToEntity(), Test.ToEntity());
}