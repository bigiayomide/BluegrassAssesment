using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Bluegrass.Menu.API.Extensions;
using Bluegrass.Menu.API.Helpers;
using Swashbuckle.AspNetCore.Swagger;
using System.Net;
using Bluegrass.Menu.EFRepository.Context;

namespace Bluegrass.Menu.API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
			var connectionString = Configuration.GetConnectionString("BluegrassDbContext");
			services.AddAutoMapper(typeof(DomainProfile));
			services.AddDbContext<BluegrassContext>(options =>
			{
				options.UseSqlServer(connectionString);
			});
			
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info { Title = "Bluegrass Menu Api ", Version = "v1" });
			});
			services.ConfigureAuthServices("to be completed");
			services.AddDIServices();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			app.UseHttpsRedirection();

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Menu API");
				c.RoutePrefix = string.Empty;
			});
			app.UseCors(builder => builder
				.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader()
				.AllowCredentials()
			);

			app.UseExceptionHandler(
				builder =>
				{
					builder.Run(
						async context =>
						{
							context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
							var error = context.Features.Get<IExceptionHandlerFeature>();
							if (error != null)
							{
								context.Response.AddApplicationError(error.Error.Message);
								await context.Response.WriteAsync(error.Error.StackTrace).ConfigureAwait(false);
							}
						});
				});
			app.UseMvc();
		}
	}
}
