using BookWorm.Ordering.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.AddApplicationServices();

var app = builder.Build();

app.UseExceptionHandler();

app.UseDefaultCors();

app.MapOpenApi();

app.MapDefaultEndpoints();

var apiVersionSet = app.NewApiVersionSet().HasApiVersion(new(1, 0)).ReportApiVersions().Build();

app.MapEndpoints(apiVersionSet);

app.MapAsyncApi();

app.Run();
