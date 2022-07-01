class Event
{
    private Map MainMap;
    private Shake SomeShake;
    public Event(object[,] map)
    {
        
        this.MainMap = new Map(map);
        this.SomeShake = new Shake();
        MainMap.ChangeMap(10,10,SomeShake.HeadShake);
        MainMap.ChangeMap(11,10,SomeShake.TailsShake[0]);
        
        RunMainLoop(3);
    }
    public void RunMainLoop(double MS_PER_UPDATE)
    {
        double previous = getCurrentTime();
        double lag = 0.0;
        while (true)
        {
            double current = getCurrentTime();
            double elapsed = current - previous;
            previous = current;
            lag += elapsed;

            ProcessInput();

            while (lag >= MS_PER_UPDATE)
            {
                Update();
                lag -= MS_PER_UPDATE;
            }

            MainMap.RenderMap();
        }
    }
    private void ProcessInput()
    {

    }
    private void Update()
    {
        
    }
}
