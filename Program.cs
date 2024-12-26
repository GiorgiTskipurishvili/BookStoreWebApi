using BookStoreWebApi.Packages;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<PKG_BOOKSTORE>();
builder.Services.AddScoped<PKG_ORDER>();


// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder => builder.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAngularApp"); 


app.UseAuthorization();

app.MapControllers();

app.Run();
