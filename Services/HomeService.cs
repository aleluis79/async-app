namespace async_app;

public class HomeService : IHomeService
{

    private readonly ILogger<HomeService> _logger;

    private readonly IEstadoProcesoService _estadoProcesoService;

    public HomeService(ILogger<HomeService> logger, IEstadoProcesoService estadoProcesoService)
    {
        _logger = logger;
        _estadoProcesoService = estadoProcesoService;
    }
    public void Procesar()
    {
        _estadoProcesoService.Running = true;
        _logger.LogInformation("Iniciando procesamiento...");
        
        Thread.Sleep(10000);
        
        _estadoProcesoService.Running = false;
        _logger.LogInformation("Finalizado!");
    }
}
