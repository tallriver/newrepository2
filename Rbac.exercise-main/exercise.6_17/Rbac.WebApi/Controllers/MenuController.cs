using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rbac.Application;
using Rbac.Entity;
using Rbac.Repository;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace Rbac.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class MenuController : ControllerBase
    {
        public MenuController(IMenuService menu)
        {
            Menu = menu;
        }

        public IMenuService Menu { get; }

        /// <summary>
        /// 获取菜单信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<MenuDto> GetMenuAll()
        {
            return Menu.GetMenuAll();
        }

        /// <summary>
        /// 获取菜单下拉框数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<MenuListDto> GetList()
        {
            return Menu.GetList();
        }

        /// <summary>
        /// 添加菜单信息
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        [HttpPost]
        public bool AddMenu(Menu menu)
        {
            return Menu.Create(menu);
        }

        /// <summary>
        /// 删除菜单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public bool DelMenu(int id)
        {
            return Menu.Delete(id);
        }

        /// <summary>
        /// 查询是否存在子节点
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public Menu GetMenuById(int id)
        {
            return Menu.GetDtoByWhere(m=>m.ParentId==id);
        }


        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        [HttpPost]
        public bool UpdMenu(Menu menu)
        {
            return Menu.UpdMenu(menu);
        }
    }
}
