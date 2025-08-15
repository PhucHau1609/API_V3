using DATN_API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();




// Tùy theo môi trường, chọn database provider
var isProduction = builder.Environment.IsProduction();
var connectionString = isProduction
    ? builder.Configuration.GetConnectionString("RailwayConnection")
    : builder.Configuration.GetConnectionString("DefaultConnection");

Console.WriteLine("Current connection string: " + connectionString);


// Nếu là production (Railway) dùng PostgreSQL
if (isProduction)
{
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); // optional
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(connectionString));
}
else
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));
}



builder.Services.AddControllers();

//App service Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Auto‑migrate DB khi app khởi động (đặc biệt hữu ích trên Railway)
using (var scope = app.Services.CreateScope())
{
    try
    {
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        Console.WriteLine("==> Applying migrations for DB: " + db.Database.GetDbConnection().ConnectionString);
        db.Database.Migrate();
        Console.WriteLine("==> Migrations applied.");
    }
    catch (Exception ex)
    {
        Console.WriteLine("==> Migration failed: " + ex);
        throw; // để Railway log thấy lỗi sớm
    }
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


//khai báo middleware
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
