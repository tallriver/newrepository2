using Rbac.Entity;
using Rbac.Repository;
using System.Collections.Generic;

namespace Rbac.Application
{
    public interface IMenuService: IBaseService<Menu, MenuAddDto>
    {
        List<MenuDto> GetMenuAll();
        List<MenuListDto> GetList();
        bool Create(Menu menu);
        bool UpdMenu(Menu menu);
    }
}