using Backend.Data;
using Backend.Interfaces;
using Backend.Mappers;
using Backend.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(CategoryMappingProfile));
builder.Services.AddAutoMapper(typeof(BrandMappingProfile));
builder.Services.AddAutoMapper(typeof(ColorMappingProfile));
builder.Services.AddAutoMapper(typeof(SizeMappingProfie));
builder.Services.AddAutoMapper(typeof(SubcategoryMappingProfile));
builder.Services.AddAutoMapper(typeof(ProductMappingProfile));
builder.Services.AddAutoMapper(typeof(ImageMappingProfile));
builder.Services.AddAutoMapper(typeof(ProductColorMappingProfile));
builder.Services.AddAutoMapper(typeof(ProductSizeMappingProfile));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy => policy.WithOrigins("http://localhost:5173")
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});


builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<IColorRepository, ColorRepository>();
builder.Services.AddScoped<ISizeRepository, SizeRepository>();
builder.Services.AddScoped<ISubcategoryRepository, SubcategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowReactApp");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseFileServer();

app.UseAuthorization();

app.MapControllers();

app.Run();
