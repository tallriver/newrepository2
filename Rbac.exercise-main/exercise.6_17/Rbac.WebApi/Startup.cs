using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Rbac.Application;
using Rbac.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Rbac.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Swashbuckle.AspNetCore.Filters;

namespace Rbac.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.Load("Rbac.Application"));

            services.AddControllers();

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(
            option =>
            {
                //Token验证参数
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    //是否验证发行人
                    ValidateIssuer = true,
                    ValidIssuer = Configuration["JwtConfig:Issuer"],//发行人

                    //是否验证受众人
                    ValidateAudience = true,
                    ValidAudience = Configuration["JwtConfig:Audience"],//受众人

                    //是否验证密钥
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtConfig:key"])),

                    ValidateLifetime = true, //验证生命周期

                    RequireExpirationTime = true, //过期时间

                    ClockSkew = TimeSpan.Zero   //平滑过期偏移时间
                };
            }
);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Rbac.WebApi", Version = "v1" });

                //开启权限小锁
                options.OperationFilter<AddResponseHeadersFilter>();
                options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                options.OperationFilter<SecurityRequirementsOperationFilter>();

                //在header中添加token，传递到后台
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传递)直接在下面框中输入Bearer {token}(注意两者之间是一个空格) \"",
                    Name = "Authorization",//jwt默认的参数名称
                    In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                    Type = SecuritySchemeType.ApiKey
                });
            });

            //上下文
            services.AddDbContext<MyDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("sqlserver")));

            

            //跨域
            services.AddCors(opt =>
            {
                opt.AddDefaultPolicy(opt =>
                {
                    opt.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader();
                });
            });

            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rbac.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //使用跨域写在这里最佳
            app.UseCors();

            //认证中间件
            app.UseAuthentication();

            //授权中间件
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
