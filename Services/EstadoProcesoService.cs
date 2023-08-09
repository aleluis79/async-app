namespace async_app;

public class EstadoProcesoService : IEstadoProcesoService
{
    private bool running;

    public bool Running
    {
        get { return running; }
        set { 
            running = value;
            if (running) {
                StartTime = DateTime.Now;    
            } else {
                LastTime = StartTime;
            }            
        }
    }    

    private DateTime StartTime { get; set; }

    private DateTime? LastTime { get; set; }

    public string RunningTime() {
        if (Running) {
            return DateTime.Now.Subtract(StartTime).TotalSeconds.ToString() + " seg";
        } else {
            var lastTimeStr = LastTime != null ? "Last time: " + LastTime : "";
            return $"Not running! {lastTimeStr}";
        }
    }
}
