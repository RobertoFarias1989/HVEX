using HVEX.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEX.Application.ViewModels;

public class UserViewModel
{
    public UserViewModel(Guid id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }

    public static UserViewModel FromEntity(User user)
    {
        return new UserViewModel( user.UserId,user.Name, user.Email);
    }
}
