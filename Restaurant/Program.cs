using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Models;
using Restaurant.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddScoped<IRepository<MasterMenu>, MasterMenuRepository>();
builder.Services.AddScoped<IRepository<MasterCategoryMenu>, MasterCategoryMenuRepository>();
builder.Services.AddScoped<IRepository<TransactionBookTable>, TransactionBookTableRepository>();
builder.Services.AddScoped<IRepository<TransactionNewsletter>, TransactionNewsletterRepository>();
builder.Services.AddScoped<IRepository<MasterWorkingHours>, MasterWorkingHoursRepository>();
builder.Services.AddScoped<IRepository<TransactionContactUs>, TransactionContactUsRepository>();
builder.Services.AddScoped<IRepository<MasterOffer>, MasterOfferRepository>();
builder.Services.AddScoped<IRepository<MasterPartner>, MasterPartnerRepository>();
builder.Services.AddScoped<IRepository<MasterServices>, MasterServicesRepository>();
builder.Services.AddScoped<IRepository<MasterSlider>, MasterSliderRepository>();
builder.Services.AddScoped<IRepository<MasterSocialMedia>, MasterSocialMediaRepository>();
builder.Services.AddScoped<IRepository<SystemSetting>, SystemSettingRepository>();
builder.Services.AddScoped<IRepository<MasterItemMenu>, MasterItemMenuRepository>();
builder.Services.AddScoped<IRepository<MasterContactUsInformation>, MasterContactUsInformationRepository>();
builder.Services.AddScoped<IRepository<MasterFeedBack>, MasterFeedBackRepository>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();


builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon").ToString());
});


builder.Services.Configure<IdentityOptions>(x =>
{
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequireDigit = false;
    x.Password.RequireLowercase = false;
    x.Password.RequireUppercase = false;
    x.Password.RequiredLength = 3;

});


builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Admin/Account/Login";

});


var app = builder.Build();



app.UseRouting();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(

    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(

   name: "default",
   pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
