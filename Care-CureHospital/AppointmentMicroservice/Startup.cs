using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentMicroservice.Repository;
using AppointmentMicroservice.Repository.MySQL.Stream;
using AppointmentMicroservice.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Model.AllActors;
using Model.Term;

namespace AppointmentMicroservice
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
            services.AddCors();

            services.AddSingleton<IAppointmentService, AppointmentService>(service => 
                    new AppointmentService(new AppointmentRepository(new MySQLStream<Appointment>()), new PatientService(new PatientRepository(new MySQLStream<Patient>()))));
            services.AddSingleton<IDoctorWorkDayService, DoctorWorkDayService>(service => 
                    new DoctorWorkDayService(new DoctorWorkDayRepository(new MySQLStream<DoctorWorkDay>()), new DoctorService(new DoctorRepository(new MySQLStream<Doctor>()))));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // global cors policy
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
