using Microsoft.EntityFrameworkCore;
using PostDraft.Application.Mapping;
using PostDraft.Application.Queries.Post;
using PostDraft.Infrastructure.Context;
using PostDraft.Infrastructure.Interface;
using PostDraft.Infrastructure.Repositories;
using PostDraftApi.Exceptions;

var builder = WebApplication.CreateBuilder(args);
var connection_string = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

// connecting to database server
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationDbContext>(options => {
    options.UseNpgsql(connection_string, b => { b.MigrationsAssembly("PostDraft.Infrastructure"); });
});

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

builder.Services.AddScoped<PostRepository>();


builder.Services.AddAutoMapper(cfg => cfg.LicenseKey = "", typeof(MappingProfile));

builder.Services.AddMediatR(m => m.RegisterServicesFromAssemblyContaining(typeof(GetAllPostsQuery)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
