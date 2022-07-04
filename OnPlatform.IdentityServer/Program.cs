using OnPlatform.IdentityServer.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentityServer().AddInMemoryClients(Clients.Get())
        .AddInMemoryIdentityResources(Resources.GetIdentityResources())
        .AddInMemoryApiResources(Resources.GetApiResources())
        .AddInMemoryApiScopes(Scopes.GetApiScopes())
        .AddTestUsers(Users.Get())
        .AddDeveloperSigningCredential();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //TODO
    app.UseDeveloperExceptionPage();
}
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.UseIdentityServer();
app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());

app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();

app.MapControllers();

app.Run();
