class Movable:UnpossibleToPassThrough
{
    public int[] position = new int[]{0,0};
    public bool StumbledUponFood = false;
    public bool StumbledUponObstacle = false;
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
                this.position = new int[]{position[0],position[1]};
            }
            else if (map[position[0],position[1]] is UnpossibleToPassThrough)
                StumbledUponObstacle = true;
        }
        catch(IndexOutOfRangeException)
        {

        }
    }
}