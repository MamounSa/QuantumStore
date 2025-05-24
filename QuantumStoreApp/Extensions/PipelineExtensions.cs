﻿using Microsoft.EntityFrameworkCore;
using QuantumStore;
using QuantumStore.QuantumStore;
using System.Reflection;
namespace QuantumStore
{
    public static class PipelineExtensions
    {
        public static IApplicationBuilder ConfigurePipeline(this IApplicationBuilder app)
        {
            app.UseMiddleware<DatabaseInitializerMiddleware>();

            if (app.ApplicationServices.GetRequiredService<IWebHostEnvironment>().IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting(); // إضافة التوجيه

            app.UseAuthorization();

            // تكوين نقاط النهاية
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // خريطة نقاط النهاية للمتحكمات
            });

            return app;
        }
    }


}
