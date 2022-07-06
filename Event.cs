class Event
{
    private object[,] map;
    private int [] resolution = new int[]{8, 4};
    private Render render;
    private Shake SomeShake;
    private string direction = "Up";
    private ConsoleKey info;
    public Event(object[,] map)
    {
        this.map = map;
        this.render = new Render(this.resolution, map);
        this.SomeShake = new Shake(new int[]{10,10});
        map[SomeShake.HeadShake.position[0], SomeShake.HeadShake.position[1]] = SomeShake.HeadShake;
        map[SomeShake.TailsShake[0].position[0], SomeShake.TailsShake[0].position[1]] = SomeShake.TailsShake[0];
        SomeShake.GrowTail(map);
        FoodPoint firstFood = new FoodPoint(map);
        map[firstFood.posX, firstFood.posY] = firstFood;
        RunMainLoop(0.5);
    }
    public void RunMainLoop(double speed)
    {
        double previous = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        double lag = 0.0;
        Console.CursorVisible = false;
        new Thread(() => ProcessInput()){IsBackground = true}.Start();
        for(;;)
        {
            double current = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            double elapsed = current - previous;
            previous = current;
            lag += elapsed;
            while (lag >= 1000/speed)
            {
                Update();
                MotionSmoothing(speed);
                lag -= 1000/speed;
                speed += 0.00;
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
        if (SomeShake.StumbledUponFood)
            {
                SomeShake.GrowTail(map);
                FoodPoint foodPoint = new FoodPoint(map);
                map[foodPoint.posX, foodPoint.posY] = foodPoint;
                SomeShake.StumbledUponFood = false;
            }
        else if (SomeShake.StumbledUponObstacle)
        {
            GameOver();
            SomeShake.StumbledUponObstacle=false;
        }
    }
    private void MotionSmoothing(double speed)
    {
        new Thread(() => SomeShake.Animation(speed)){IsBackground = true}.Start();
    }
    private void GameOver()
    {
        Console.Clear();
        render.RenderMap(this.map);
        Console.SetCursorPosition(map.GetLength(0)*resolution[0]/2,map.GetLength(1)*resolution[1]/2);
        Console.WriteLine("Game Over");
        Console.SetCursorPosition(map.GetLength(0)*resolution[0],map.GetLength(1)*resolution[1]);
        Console.CursorVisible = true;
        Environment.Exit(0);
    }
} 
