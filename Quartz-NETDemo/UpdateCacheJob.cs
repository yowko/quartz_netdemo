using Quartz;

namespace Quartz_NETDemo;

public class UpdateCacheJob:IJob
{
    private readonly ILogger<UpdateCacheJob> _logger;
    private readonly UpdateCacheService _updateCacheService;
    
    public UpdateCacheJob(ILogger<UpdateCacheJob> logger,UpdateCacheService updateCacheService)
    {
        _logger = logger;
        _updateCacheService = updateCacheService;
    }

    public Task Execute(IJobExecutionContext context)
    {
        return _updateCacheService.GetAsync(new CancellationToken());
    }
}