namespace async_app;

public interface IEstadoProcesoService
{
    bool Running { get; set; }

    string RunningTime();
}
