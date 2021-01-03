using Backend.Model.PatientDoctor;
using DocumentsMicroservice.Repository;
using DocumentsMicroservice.Repository.MySQL.Stream;
using DocumentsMicroservice.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Model.AllActors;
using Model.PatientDoctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentsMicroservice
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

            services.AddSingleton<IAllergiesService, AllergiesService>(service => new AllergiesService(new AllergiesRepository(new MySQLStream<Allergies>())));
            services.AddSingleton<IEmailVerificationService, EmailVerificationService>(service => new EmailVerificationService());
            services.AddSingleton<IMedicalExaminationReportService, MedicalExaminationReportService>(service => new MedicalExaminationReportService(new MedicalExaminationReportRepository(new MySQLStream<MedicalExaminationReport>())));
            services.AddSingleton<IPrescriptionService, PrescriptionService>(service => new PrescriptionService(new PrescriptionRepository(new MySQLStream<Prescription>())));
            services.AddSingleton<IMedicalRecordService, MedicalRecordService>(service => new MedicalRecordService(new MedicalRecordRepository(new MySQLStream<MedicalRecord>())));
            services.AddSingleton<IPatientService, PatientService>(service => new PatientService(new PatientRepository(new MySQLStream<Patient>())));

            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // global cors policy
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials
        }
    }
}
