namespace Quartz_NETDemo;

public class UpdateCacheService
{
    private readonly ILogger<UpdateCacheService> _logger;
    
    public UpdateCacheService(ILogger<UpdateCacheService> logger)
    {
        _logger = logger;
    }
    
    public Task GetAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Get Data for cache");
        //update cache
        return Task.CompletedTask;
    }
}