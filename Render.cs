class Render
{
    private int[] resolution;
    private object[,] map;
    private string[,] textureMap;
    private Dictionary<string, string> TextureCollection = new()
    {
        {"border"      , "███████████████"},
        {"foodpoint"   , " ▗▚▁ ▐▓▓▓▌ ▘▀▝ "},
        {"space"       , "               "},
        {"head"        , "╔═══╗║   ║╚═══╝"},
        {"tail"        , "┌───┐│   │└───┘"},
        {"tail-LR"     , "─────     ─────"},
        {"tail-UD"     , "│   ││   ││   │"},
        {"tail-LU"     , "┘   │    │────┘"},
        {"tail-UR"     , "│   └│    └────"},
        {"tail-LD"     , "────┐    │┐   │"},
        {"tail-RD"     , "┌────│    │   ┌"},
        {"tail-RL"     , "─────     ─────"},
        {"tail-DU"     , "│   ││   ││   │"},
        {"tail-UL"     , "┘   │    │────┘"},
        {"tail-RU"     , "│   └│    └────"},
        {"tail-DL"     , "────┐    │┐   │"},
        {"tail-DR"     , "┌────│    │   ┌"},
        {"tail-LE"     , "────┐    │────┘"},
        {"tail-UE"     , "│   ││   │└───┘"},
        {"tail-RE"     , "┌────│    └────"},
        {"tail-DE"     , "┌───┐│   ││   │"},
    };
    public Render(int [] resolution, object[,] map)
    {
        this.resolution = resolution;
        this.map  = map;
        this.textureMap = new string[this.map.GetLength(0),this.map.GetLength(1)];
    }
    public void RenderMap(object[,] map)
    {
        this.map  = map;
        this.textureMap = new string[this.map.GetLength(0),this.map.GetLength(1)];
        for (int i=0; i < this.map.GetLength(0); i++)
        {
            for (int j=0; j < this.map.GetLength(1); j++)
            {
                ReplacementCalculation(i,j);
            }
        }
        OutputDisplay(textureMap);
    }
    private void OutputDisplay(string[,] map)
    {   
        Console.SetCursorPosition(0,0);
        for (int i=0; i < map.GetLength(0); i++)
        {
            for (int k=0; k < resolution[1]; k++)
            {
                for (int j=0; j < map.GetLength(1); j++)
                {
                    Console.Write(TextureCollection[map[i,j]].Substring(k*resolution[0], resolution[0]));
                }
                Console.Write("\n");
            }
        }
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
            case FoodPoint:
            {
                FoodPoint foodPoint = (FoodPoint)this.map[i,j];
                this.textureMap[i,j]=foodPoint.type;
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
        if (SearchTailsNextWithID( i+1, j, id-1))
            direction+="-D";
        else if (SearchTailsNextWithID( i-1, j, id-1))
            direction+="-U";
        else if (SearchTailsNextWithID( i, j+1, id-1))
            direction+="-R";
        else if (SearchTailsNextWithID( i, j-1, id-1))
            direction+="-L";
        else if (SearchHeadNext( i+1, j))
            direction+="-D";
        else if (SearchHeadNext( i-1, j))
            direction+="-U";
        else if (SearchHeadNext( i, j+1))
            direction+="-R";
        else if (SearchHeadNext( i, j-1))
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