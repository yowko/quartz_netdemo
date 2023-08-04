using Quartz;
using Quartz_NETDemo;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<UpdateCacheService>();
builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionJobFactory();
    
    //直接觸發
    q.ScheduleJob<UpdateCacheJob>(trigger => trigger
        .WithIdentity("UpdateCacheJob")
        .StartNow()
    );
    
    //建立 job
    var jobKey = new JobKey("updateCacheJob");
    q.AddJob<UpdateCacheJob>(jobKey);
    //建立 trigger(規則) 來觸發 job
    q.AddTrigger(t => t
        .WithIdentity("updateCacheTrigger")    
        .ForJob(jobKey)
        .StartNow()
        .WithCronSchedule("0 0 0 * * ?", x=>x.InTimeZone(TimeZoneInfo.FindSystemTimeZoneById("Asia/Shanghai")))
    );
});

builder.Services.AddQuartzHostedService(opt =>
{
    opt.WaitForJobsToComplete = true;
});
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();