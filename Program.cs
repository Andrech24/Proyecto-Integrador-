var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<TaskFlowSolid.Repositories.ITareaRepository, TaskFlowSolid.Repositories.InMemoryTareaRepository>();
builder.Services.AddScoped<TaskFlowSolid.Services.ITareaService, TaskFlowSolid.Services.TareaService>();
builder.Services.AddScoped<TaskFlowSolid.Patterns.ITareaFactory, TaskFlowSolid.Patterns.TareaFactory>();
builder.Services.AddScoped<TaskFlowSolid.Patterns.IPrioridadStrategy, TaskFlowSolid.Patterns.FechaEntregaPrioridadStrategy>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
