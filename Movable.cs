class Movable
{
    public int[] position = new int[]{0,0};
    public virtual void Move(object [,] map, string direction)
    {
        try
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
            if (map[i,j] is Space)
            {
                map[i,j] = map[position[0], position[1]];
                map[position[0], position[1]] = new Space();
                this.position = new int[]{i,j};
            }
        }
        catch(IndexOutOfRangeException)
        {

        }
    }
    public virtual void Move(object [,] map, int [] position)
    {
        try
        {
            if (map[position[0],position[1]] is Space)
            {
                map[position[0],position[1]] = map[this.position[0], this.position[1]];
                map[this.position[0], this.position[1]] = new Space();
                this.position = new int[]{position[0],position[1]};
            }
        }
        catch(IndexOutOfRangeException)
        {

        }
    }
}