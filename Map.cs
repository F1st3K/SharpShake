class Map
{
    private object[,] map;
    private string[,] textureMap;
    private Render render;
    public Map(object[,] map)
    {
        this.map  = map;
        this.textureMap = new string[this.map.GetLength(0),this.map.GetLength(1)];
        this.render = new Render(new int[]{5, 3});

    }
    public void ChangeMap(int cordX, int cordY, object replacement)
    {
        this.map[cordX, cordY] = replacement;
    }
    public void RenderMap()
    {
        for (int i=0; i < this.map.GetLength(0); i++)
        {
            //Console.Write("\n");
            for (int j=0; j < this.map.GetLength(1); j++)
            {
                ReplacementCalculation(i,j);
                //Console.Write(this.textureMap[i,j]);
            }
        }
        render.OutputDisplay(textureMap);
    }
    private void ReplacementCalculation(int i,int j)
    {
        switch (this.map[i,j])
        {
            case Obstacle:
            {
                Obstacle obstacle = (Obstacle)this.map[i,j];
                this.textureMap[i,j]=obstacle.type;
            }
            break;
            case Space:
            {
                this.textureMap[i,j] = "space";
            }
            break;
            case Head:
            {
                Head head = (Head)this.map[i,j];
                this.textureMap[i,j]=head.type;
            }
            break;
            case Tail:
            {
                Tail tail = (Tail)this.map[i,j];
                this.textureMap[i,j] = TailDynamicTexturing(tail.type, tail.id, i, j);
            }
            break;
            default:
            {
                this.textureMap[i,j] = "space";
            }
            break;
        }
    }
    private string TailDynamicTexturing(string type, int id, int i,int j)
    {
        string direction = "";
        if (SearchTailsNextWithID( i+1, j, id-1) || SearchHeadNext( i+1, j))
            direction+="-D";
        else if (SearchTailsNextWithID( i-1, j, id-1) || SearchHeadNext( i-1, j))
            direction+="-U";
        else if (SearchTailsNextWithID( i, j+1, id-1) || SearchHeadNext( i, j+1))
            direction+="-R";
        else if (SearchTailsNextWithID( i, j-1, id-1) || SearchHeadNext( i, j-1))
            direction+="-L";
        if (SearchTailsNextWithID( i+1, j, id+1))
            direction+="D";
        else if (SearchTailsNextWithID( i-1, j, id+1))
            direction+="U";
        else if (SearchTailsNextWithID( i, j+1, id+1))
            direction+="R";
        else if (SearchTailsNextWithID( i, j-1, id+1))
            direction+="L";
        else
            direction+="E";
        return type+direction;
    }
    private bool SearchTailsNextWithID(int i, int j, int id)
    {
        try
        {
            if (((Tail)this.map[i,j]).id == id)
                return true;
        }
        catch(IndexOutOfRangeException)
        {

        }
        catch(InvalidCastException)
        {

        }
        return false;
    }
    private bool SearchHeadNext(int i, int j)
    {
        try
        {
            if (((Head)this.map[i,j]) is Head)
                return true;
        }
        catch(IndexOutOfRangeException)
        {

        }
        catch(InvalidCastException)
        {

        }
        return false;
    }
}