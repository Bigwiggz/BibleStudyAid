using BibleStudyAidMVC.Data;
using BibleStudyAidMVC.Services.EmailServices;
using BibleStudyAidMVC.ViewModels;
using BibleStudyDataAccessLibrary.DataAccess;
using BibleStudyDataAccessLibrary.Internal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using AutoMapper;
using BibleStudyAidMVC.Services.HttpServices;
using BibleStudyAidMVC.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DBBibleStudyAidAuth");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

//Add Personal Services
builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddTransient<IDailyBibleReadingData, DailyBibleReadingData>();
builder.Services.AddTransient<IFamilyStudyProjectsData, FamilyStudyProjectsData>();
builder.Services.AddTransient<IDocumentsData, DocumentsData>();
builder.Services.AddTransient<IReferencesData, ReferencesData>();
builder.Services.AddTransient<IScripturesData, ScripturesData>();
builder.Services.AddTransient<IMeetingAssembliesData, MeetingAssembliesData>();
builder.Services.AddTransient<ITagsData, TagsData>();
builder.Services.AddTransient<ITagsToOtherTablesData,TagsToOtherTablesData>();
builder.Services.AddTransient<ISpiritualGemsData, SpiritualGemsData>();
builder.Services.AddTransient<ITalksData, TalksData>();

//Add HttpClient
string uri = builder.Configuration.GetValue<string>("BibleTextAPI");
builder.Services.AddHttpClient("BibleTextAPI", c =>
{
    c.BaseAddress = new Uri(uri);
});

builder.Services.AddSingleton<IHttpRequestService, HttpRequestService>();

//Add Automapper
builder.Services.AddAutoMapper(typeof(Program));

//Add Document Migration
builder.Services.AddSingleton<IDocumentMigration, DocumentMigration>();

//Make everything authorized access
builder.Services.AddMvc(o => 
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
    o.Filters.Add(new AuthorizeFilter(policy));
});

//Register preconfigured instance of mail settings
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddScoped<IEmailSender, EmailService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
