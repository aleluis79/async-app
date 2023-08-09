using Microsoft.AspNetCore.Mvc;

namespace async_app.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{

    private readonly ILogger<HomeController> _logger;

    private readonly IHomeService _homeService;

    private readonly IEstadoProcesoService _estadoProcesoService;

    public HomeController(ILogger<HomeController> logger, IHomeService homeService, IEstadoProcesoService estadoProcesoService)
    {
        _logger = logger;
        _homeService = homeService;
        _estadoProcesoService = estadoProcesoService;
    }

    [HttpGet("procesar")]
    public ActionResult<int> Procesar()
    {
        if (!_estadoProcesoService.Running) {
            _logger.LogInformation("Llamando al servicio...");
            new Thread(() => {
                _homeService.Procesar();
            }).Start();
            return 0;
        } else {
            _logger.LogInformation("El proceso ya está en ejecución.");
            return -1;
        }
    }

    [HttpGet("estado")]
    public ActionResult<string> Estado() {
        return _estadoProcesoService.RunningTime();
    }
}
