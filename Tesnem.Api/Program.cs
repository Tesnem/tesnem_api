using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;
using Tesnem.Api.Data;
using Tesnem.Api.Data.Repository;
using Tesnem.Api.Domain.Auth;
using Tesnem.Api.Domain.Repository;
using Tesnem.Api.Domain.Services;
using Tesnem.Api.Middleware;
using Tesnem.Api.Middleware.Handlers;
using Tesnem.Api.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
var configuration = builder.Configuration;

services.AddCors();

services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
// Normal DB context + Identity context
services.AddDbContext<AppDbContext>(opt => opt.UseMySql(builder.Configuration.GetConnectionString("TesnemContext"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("TesnemContext"))));
services.AddDbContext<IdentityDbContext>(opt => opt.UseMySql(builder.Configuration.GetConnectionString("IdentityContext"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("TesnemContext"))));

// Identity
services.AddIdentity<User, IdentityRole>(opt =>
{
    opt.Password.RequiredLength = 8;
    opt.Password.RequireDigit = false;
    opt.Password.RequireUppercase = false;

}).AddEntityFrameworkStores<IdentityDbContext>();

services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = configuration["IdentityServer"];

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false
        };
    });

services.AddAuthorization(options =>
{
    options.AddPolicy("User", policy => policy.Requirements.Add(new HasScopeRequirement("ApiUser")));
    options.AddPolicy("Admin", policy => policy.Requirements.Add(new HasScopeRequirement("ApiAdmin")));
});

// Services & Repository DI
services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
services.AddScoped<IClassRepository, ClassRepository>();
services.AddScoped<ICourseRepository, CourseRepository>();
services.AddScoped<IProfessorRepository, ProfessorRepository>();
services.AddScoped<IStudentRepository, StudentRepository>();
services.AddScoped<IMajorRepository, MajorRepository>();
services.AddScoped<IUnitOfWork, UnitOfWork>();
services.AddScoped<IStudentService, StudentService>();
services.AddScoped<IEnrollmentService, EnrollmentService>();
services.AddScoped<IClassService, ClassService>();
services.AddScoped<ICourseService, CourseService>();
services.AddScoped<IProfessorService, ProfessorService>();
services.AddScoped<IMajorService, MajorService>();
services.AddScoped<IPersonalDataRepository, PersonalDataRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers().RequireAuthorization();

app.Run();
