using HVEX.Core.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace HVEX.Core.Entities;

public class Transformer
{
    public Transformer(string name,int internalNumber,int potency, int current)
    {
        TransformerId = Guid.NewGuid();
        Name = name;
        InternalNumber = internalNumber;        
        Potency = potency;
        Current = current;

        Tension = TransformerTensionEnum.Regular;
        Tests = new List<Test>();
        TransformerTests = new List<TransformerTest>();
        TransformerReports = new List<TransformerReport>();
    }

    public Transformer(Guid transformerId, string name, int internalNumber, 
        TransformerTensionEnum tension, int potency, int current, List<Test> tests, 
        List<TransformerTest> transformerTests, List<TransformerReport> transformerReports)
    {
        TransformerId = transformerId;
        Name = name;
        InternalNumber = internalNumber;
        Tension = tension;
        Potency = potency;
        Current = current;
        Tests = tests;
        TransformerTests = transformerTests;
        TransformerReports = transformerReports;
    }

    [BsonId]
    public Guid TransformerId { get; private set; }
    public string Name { get; private set; }
    public int InternalNumber { get; private set; }
    public TransformerTensionEnum Tension { get; private set; }
    public int Potency { get; private set; }
    public int Current { get; private set; }    
    public List<Test> Tests { get; private set; }
    public List<TransformerTest> TransformerTests { get; private set; }
    public List<TransformerReport> TransformerReports { get; private set; }
}
