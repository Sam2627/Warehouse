using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Warehouse_SQL;
using Warehouse_SQL.Repository;
using Warehouse_SQL.RepositoryInteface;
using Warehouse_UseCases;
using Warehouse_UseCases.Interfaces;
using Warehouse_Web.Components;
using Warehouse_Web.Components.Account;
using Warehouse_Web.Data;
using Warehouse_Web.Data.UseCases;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("WarehouseUserDbConnection") ?? throw new InvalidOperationException("Connection string 'WarehouseUserDbContextConnection' not found.");;

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireClaim("Position", "Admin"));
    options.AddPolicy("StaffOnly", policy => policy.RequireClaim("Position", "Staff"));
});

builder.Services.AddDbContext<WarehouseDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WarehouseDbConnection") ?? throw new InvalidOperationException("Connection string 'WarehouseDbContextConnection' not found.")));

// Using EF Data Store
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

// Add Dependency Injection for User Cases
builder.Services.AddTransient<ICategoryUseCase, CategoryUseCase>();
builder.Services.AddTransient<IProductUseCase, ProductUseCase>();
builder.Services.AddTransient<ITransactionUseCase, TransactionUseCase>();
//builder.Services.AddTransient<IUserUseCases, UserUseCases>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();

builder.Services.AddScoped<ApplicationUserAccessor>();

builder.Services.AddScoped<IdentityRedirectManager>();

builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Configure authentication and authorization
app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapAdditionalIdentityEndpoints();;

app.Run();
