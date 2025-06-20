using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Mappings;
using SchoolManagement.Repository.ClassRepository;
using SchoolManagement.Repository.StudentRepository;
using SchoolManagement.Repository.StudentRepository.StudentRepository;
using SchoolManagement.Repository.SubjectRepository;
using SchoolManagement.Repository.TeacherRepository;
using SchoolManagement.Repository.UserRepository;
using SchoolManagement.Service.ClassService;
using SchoolManagement.Service.StudentService;
using SchoolManagement.Service.SubjectService;
using SchoolManagement.Service.UserService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddDbContext<SchoolDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// DependencyInjectionsofrepository
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<IClassRepository, ClassRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
// DependencyInjectionsofService
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IClassService, ClassService>();
builder.Services.AddScoped<IUserService, UserService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
