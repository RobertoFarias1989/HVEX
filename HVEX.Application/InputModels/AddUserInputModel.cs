using HVEX.Core.Entities;
using HVEX.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEX.Application.InputModels;

public class AddUserInputModel
{
    public string Name { get;  set; }
    public string Email { get;  set; }

    public User ToEntity()
        => new User(
            Name,
            Email);
}


