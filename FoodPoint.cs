class FoodPoint
{
    public int posY {get; private set;}
    public int posX {get; private set;}
    public string type {get; private set;} = "foodpoint";
    public FoodPoint(object [,] map)
    {
        RandomPosition(map);
    }
    public FoodPoint(object [,] map, int posX, int posY)
    {
        try
        {
            if (map[posX, posY] is object)
            {
                this.posX = posX;
                this.posY = posY;
            }  
        }
        catch(IndexOutOfRangeException){}
    }
    private void RandomPosition(object [,] map)
    {
        do
        {
            Random rand = new Random();
            this.posX = rand.Next(0,map.GetLength(0));
            this.posY = rand.Next(0,map.GetLength(1));
        }
        while (!(map[this.posX, this.posX] is Space));

    }
}