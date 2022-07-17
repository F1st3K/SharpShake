class Movable:UnpossibleToPassThrough
{
    public int[] position = new int[]{0,0};
    public int[] prevposition = new int[]{0,0};
    public bool StumbledUponFood = false;
    public bool StumbledUponObstacle = false;
    public int TickAnimetion = 0;
    public virtual void Move(object [,] map, string direction)
    {
        int i = this.position[0];
        int j = this.position[1];
        switch (direction)
        {
            case "Up":
            {
                i -= 1;
            }
            break;
            case "Down":
            {
                i += 1;
            }
            break;
            case "Left":
            {
                j -= 1;
            }
            break;
            case "Right":
            {
                j += 1;
            }
            break;
            default:break;
        }
        Move(map, new int[] {i, j});
    }
    public virtual void Move(object [,] map, int [] position)
    {
        try
        {
            if (map[position[0],position[1]] is FoodPoint)
                StumbledUponFood = true;
            if (map[position[0],position[1]] is PossibleToPassThrough)
            {
                map[position[0],position[1]] = map[this.position[0], this.position[1]];
                map[this.position[0], this.position[1]] = new Space();
                this.prevposition = this.position;
                this.position = position;
            }
            else if (map[position[0],position[1]] is UnpossibleToPassThrough)
                StumbledUponObstacle = true;
        }
        catch(IndexOutOfRangeException)
        {

        }
    }
    public string GetDirection()
    {
        string direction = "";
        if (Math.Abs(this.prevposition[0] - this.position[0])>Math.Abs(this.prevposition[1] - this.position[1]))
        {
            if (this.prevposition[0] > this.position[0])
                direction = "U";
            else if (this.prevposition[0] < this.position[0])
                direction = "D";
        }
        else
        {
            if (this.prevposition[1] > this.position[1])
                direction = "L";
            else if (this.prevposition[1] < this.position[1])
                direction = "R";
        }
        return direction;
    }
}