using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rbac.Application;

namespace Rbac.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController(IUserService userService)
        {
            UserService = userService;
        }

        public IUserService UserService { get; }

        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ResaultDto AddUserInfo(UserDto user)
        {
            return UserService.AddUserInfo(user);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public TokenDto Login(LoginDto user)
        {
            return UserService.Login(user);
        }
    }
}
