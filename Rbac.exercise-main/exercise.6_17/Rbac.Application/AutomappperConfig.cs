using AutoMapper;
using Rbac.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Application
{
    public class AutomappperConfig:Profile
    {
        public AutomappperConfig()
        {
            CreateMap<MenuAddDto, Menu>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
