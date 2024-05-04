namespace BooksStore;

public class DemoLoggingHandler(ILogger<DemoLoggingHandler> logger) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"HTTP request sent {request.Method} {request.RequestUri}");
        var response = await base.SendAsync(request, cancellationToken);
        logger.LogInformation($"HTTP response received :{response.StatusCode}");
        return response;
    }
}