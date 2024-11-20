using Microsoft.EntityFrameworkCore;
using QuizzApp.Persistance;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();  
builder.Services.AddDbContext<QuizzAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();  
app.MapControllers(); 
app.Run();  


 