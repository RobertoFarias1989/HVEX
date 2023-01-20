using HVEX.Core.Entities;
using HVEX.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HVEX.Application.InputModels;

public class UpdateReportInputModel
{
    public Guid ReportId { get;  set; }
    public string Name { get;  set; }
    public string Status { get;  set; }
    public List<ReportTestInputModel> ReportTests { get;  set; }

    public Report ToEntity()
      => new Report(ReportId, Name, 
          (RepostStatusEnum)Enum.Parse(typeof(RepostStatusEnum), Status),
          new List<ReportTest>
          {
              new ReportTest(ReportTests[0].ReportId,

                  new Test(
                      ReportTests[0].Test.Name,
                      ReportTests[0].Test.Duration),

                  new List<Transformer>
                  {
                      new Transformer( 
                      ReportTests[1].Transformers[1].Name,
                      ReportTests[1].Transformers[1].Current,
                      ReportTests[1].Transformers[1].InternalNumber,
                      ReportTests[1].Transformers[1].Potency)
                  }),
          }          
          );
}

public class ReportTestInputModel
{
    public Guid ReportId { get;  set; }
    public AddTestInputModel Test { get;  set; }
    public List<AddTransformerInputModel> Transformers { get; set; }

    public ReportTest ToEntity()
        => new ReportTest(ReportId,

            Test.ToEntity(), 

            new List<Transformer>
            {
                new Transformer(
                    Transformers[1].Name,
                    Transformers[1].InternalNumber,
                    Transformers[1].Potency,
                    Transformers[1].Current)
            });

}