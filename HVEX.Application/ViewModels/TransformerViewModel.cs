using HVEX.Core.Entities;
using HVEX.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEX.Application.ViewModels;

public class TransformerViewModel
{
    public TransformerViewModel(Guid id, string name, int internalNumber, string tension, int potency, int current)
    {
        Id = id;
        Name = name;
        InternalNumber = internalNumber;
        Tension = tension;
        Potency = potency;
        Current = current;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public int InternalNumber { get; private set; }
    public string Tension { get; private set; }
    public int Potency { get;  private set; }
    public int Current { get;  private set; }

    public static TransformerViewModel FromEntity(Transformer transformer)
    {
        return new TransformerViewModel(transformer.TransformerId,transformer.Name,
            transformer.InternalNumber, transformer.Tension.ToString(),transformer.Potency, transformer.Current);
    }

}
