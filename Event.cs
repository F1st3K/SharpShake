class Event
{
    private object[,] map;
    private Render render;
    private Shake SomeShake;
    private string direction = "Up";
    private ConsoleKey info;
    public Event(object[,] map)
    {
        this.map = map;
        this.render = new Render(new int[]{5, 3}, map);
        this.SomeShake = new Shake(new int[]{10,10});
        map[SomeShake.HeadShake.position[0], SomeShake.HeadShake.position[1]] = SomeShake.HeadShake;
        map[SomeShake.TailsShake[0].position[0], SomeShake.TailsShake[0].position[1]] = SomeShake.TailsShake[0];
        SomeShake.GrowTail(map);
        FoodPoint firstFood = new FoodPoint(map);
        map[firstFood.posX, firstFood.posY] = firstFood;
        RunMainLoop(1.2);
    }
    public void RunMainLoop(double speed)
    {
        double previous = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        double lag = 0.0;
        Console.CursorVisible = false;
        new Thread(() => ProcessInput()){IsBackground = true}.Start();
        while (true)
        {
            double current = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            double elapsed = current - previous;
            previous = current;
            lag += elapsed;
            while (lag >= 1000/speed)
            {
                Update();
                lag -= 1000/speed;
                speed += 0.05;
            }

            render.RenderMap(this.map);
        }
    }
    private void ProcessInput()
    {
        for(;;)
        {
            this.info = Console.ReadKey(true).Key;
            if(info == ConsoleKey.UpArrow)
                this.direction = "Up";
            else if(info == ConsoleKey.DownArrow)
                this.direction = "Down";
            else if(info == ConsoleKey.LeftArrow)
                this.direction = "Left";
            else if(info == ConsoleKey.RightArrow)
                this.direction = "Right";
        }
    }
    private void Update()
    {
        SomeShake.Move(map, this.direction);
    }
} 
