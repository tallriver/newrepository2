using AutoMapper;
using Rbac.Entity;
using Rbac.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rbac.Application
{
    public class MenuService : BaseService<Menu,MenuAddDto>,IMenuService
    {
        public IMenuRepository MenuRepository { get; }

        public MenuService(IMenuRepository menuRepository, IMapper mapper):base(menuRepository,mapper)
        {
            MenuRepository = menuRepository;
        }


        /// <summary>
        /// 给菜单进行赋值
        /// </summary>
        /// <returns></returns>
        public List<MenuDto> GetMenuAll()
        {
            var list=MenuRepository.GetInfoAll();
            List<MenuDto> result=new List<MenuDto>();

            var menudto = list.Where(m => m.ParentId == 0).Select(m => new MenuDto
            {
                MenuId = m.MenuId,
                MenuName = m.MenuName,
                LinkUrl = m.LinkUrl,
            }).ToList();

            GetNodes(menudto);

            return menudto;
        }


        /// <summary>
        /// 调用递归给菜单子节点进行赋值
        /// </summary>
        /// <param name="menus"></param>
        private void GetNodes(List<MenuDto> menus)
        {
            var list = MenuRepository.GetInfoAll();

            foreach (var item in menus)
            {
                var obj = list.Where(m => m.ParentId == item.MenuId).Select(m => new MenuDto
                {
                    MenuId = m.MenuId,
                    MenuName = m.MenuName,
                    LinkUrl = m.LinkUrl,
                }).ToList();

                item.Children.AddRange(obj);

                GetNodes(obj);
            }
        }

        /// <summary>
        /// 获取菜单内容
        /// </summary>
        /// <returns></returns>
        public List<MenuListDto> GetList()
        {
            var list = MenuRepository.GetInfoAll();
            List<MenuListDto> result = new List<MenuListDto>();

            var menudto = list.Where(m => m.ParentId == 0).Select(m => new MenuListDto
            {
                value = m.MenuId,
                label = m.MenuName,
            }).ToList();

            GetNodesList(menudto);

            return menudto;
        }


        /// <summary>
        /// 递归获取菜单内容
        /// </summary>
        /// <param name="menus"></param>
        private void GetNodesList(List<MenuListDto> menus)
        {
            var list = MenuRepository.GetInfoAll();

            foreach (var item in menus)
            {
                var obj = list.Where(m => m.ParentId == item.value).Select(m => new MenuListDto
                {
                    value = m.MenuId,
                    label = m.MenuName,
                }).ToList();

                item.children.AddRange(obj);

                GetNodesList(obj);
            }
        }


        /// <summary>
        /// 菜单添加新建
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public bool Create(Menu menu)
        {
            menu.CreateTime = DateTime.Now;
            return MenuRepository.Add(menu);
        }


        /// <summary>
        /// 菜单修改
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public bool UpdMenu(Menu menu)
        {
            if (menu.ParentId == 0)
            {
                var list = MenuRepository.GetByWhere(menu.MenuId);
                menu.CreateTime = list.CreateTime;
                menu.ParentId = list.ParentId;
                return MenuRepository.Upd(menu);
            }
            else
            {
                return MenuRepository.Upd(menu);
            }

        }

    }
}
