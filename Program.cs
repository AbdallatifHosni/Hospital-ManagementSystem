using Kidney.Data;
using Kidney.Helper;
using Kidney.Models;
using Kidney.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IAuthRepository,AuthRepository>();
//builder.services.AddScoped<ReportFiles>();
// Add services to the container.

string corss = "xxxxxxxxxxxxxxxxx";
// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);





builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();



//builder.Services.AddCors(options =>
//    {
//        options.AddPolicy("AllowAllOrigins",
//            builder =>
//            {
//                builder.AllowAnyOrigin();
//            });
//        });
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            //.AllowCredentials()
            .AllowAnyMethod();
    });
});

/////////////////////////////

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(corss,
//    builder =>
//    {
        
//        builder.AllowAnyOrigin();
//        builder.AllowAnyHeader();
//        builder.AllowAnyMethod();
//    }
//    );
//});

builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("Kidney"));


});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
///////////////////////////////////////////

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o=>
{
    o.RequireHttpsMetadata = false;
    o.SaveToken = false;
    o.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey=false,
        ValidateIssuer=true,
        ValidateAudience=true,
        ValidateLifetime=true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
       IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
        
    };


});




var app = builder.Build();
app.UseStaticFiles();

//app.Map("/files", files =>
//{
//    files.UseStaticFiles(new StaticFileOptions
//    {
//        FileProvider = new PhysicalFileProvider(
//            Path.Combine(env.ContentRootPath, "wwwroot")),
//        RequestPath = "/files"
//    });
//});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()||app.Environment.IsProduction()||app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseCors("AllowAllOrigins");
//app.UseCors(policy =>
//{
//  policy.AllowAnyHeader();
//  policy.AllowAnyMethod();
//  policy.AllowCredentials();
//});
app.UseCors();
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(Endpoint =>
{
    Endpoint.MapControllers();
});

app.Run();
