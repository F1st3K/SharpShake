class Render
{
    private int[] resolution;
    private object[,] map;
    private string[,] textureMap;
    private Dictionary<string, string> TextureCollection = new()
    {
        {"border"         , "████████████████████████████████"},
        {"foodpoint"      , " ▗▄▞▚▂▁ ▐▓▓▓▓▓▓▌▐▓▓▓▓▓▓▌ ▘▀▀▀▀▝ "},
        {"space"          , "                                "},
        {"head(0)"        , "╔══════╗║      ║║      ║╚══════╝"},
        {"tail"           , "┌──────┐│      ││      │└──────┘"},
        {"tail-LR(0)"     , "────────                ────────"},
        {"tail-UD(0)"     , "│      ││      ││      ││      │"},
        {"tail-LU(0)"     , "┘      │       │       │───────┘"},
        {"tail-UR(0)"     , "│      └│       │       └───────"},
        {"tail-LD(0)"     , "───────┐       │       │┐      │"},
        {"tail-RD(0)"     , "┌───────│       │       │      ┌"},
        {"tail-RL(0)"     , "────────                ────────"},
        {"tail-DU(0)"     , "│      ││      ││      ││      │"},
        {"tail-UL(0)"     , "┘      │       │       │───────┘"},
        {"tail-RU(0)"     , "│      └│       │       └───────"},
        {"tail-DL(0)"     , "───────┐       │       │┐      │"},
        {"tail-DR(0)"     , "┌───────│       │       │      ┌"},
        {"tail-LE(0)"     , "───────┐       │       │───────┘"},
        {"tail-UE(0)"     , "│      ││      ││      │└──────┘"},
        {"tail-RE(0)"     , "┌───────│       │       └───────"},
        {"tail-DE(0)"     , "┌──────┐│      ││      ││      │"},
            {"head(7U)1"        , "                        ╔══════╗"},
            {"head(6U)1"        , "                        ╔══════╗"},
            {"head(5U)1"        , "                ╔══════╗║      ║"},
            {"head(4U)1"        , "                ╔══════╗║      ║"},
            {"head(3U)1"        , "        ╔══════╗║      ║║      ║"},
            {"head(2U)1"        , "        ╔══════╗║      ║║      ║"},
            {"head(1U)1"        , "╔══════╗║      ║║      ║╚══════╝"},
            {"head(7D)1"        , "╚══════╝                        "},
            {"head(6D)1"        , "╚══════╝                        "},
            {"head(5D)1"        , "║      ║╚══════╝                "},
            {"head(4D)1"        , "║      ║╚══════╝                "},
            {"head(3D)1"        , "║      ║║      ║╚══════╝        "},
            {"head(2D)1"        , "║      ║║      ║╚══════╝        "},
            {"head(1D)1"        , "╔══════╗║      ║║      ║╚══════╝"},
            {"head(7L)1"        , "       ╔       ║       ║       ╚"},
            {"head(6L)1"        , "      ╔═      ║       ║       ╚═"},
            {"head(5L)1"        , "     ╔══     ║       ║       ╚══"},
            {"head(4L)1"        , "    ╔═══    ║       ║       ╚═══"},
            {"head(3L)1"        , "   ╔════   ║       ║       ╚════"},
            {"head(2L)1"        , "  ╔═════  ║       ║       ╚═════"},
            {"head(1L)1"        , " ╔══════ ║       ║       ╚══════"},
            {"head(7R)1"        , "╗       ║       ║       ╝       "},
            {"head(6R)1"        , "═╗       ║       ║      ═╝      "},
            {"head(5R)1"        , "══╗       ║       ║     ══╝     "},
            {"head(4R)1"        , "═══╗       ║       ║    ═══╝    "},
            {"head(3R)1"        , "════╗       ║       ║   ════╝   "},
            {"head(2R)1"        , "═════╗       ║       ║  ═════╝  "},
            {"head(1R)1"        , "══════╗       ║       ║ ══════╝ "},
            {"tail-LR(11L)"     , "────────                ────────"},
            {"tail-UD(1U)"     , "│      ││      ││      ││      │"},
            {"tail-LU(1L)"     , "┘      │       │       │───────┘"},
            {"tail-UR(1U)"     , "│      └│       │       └───────"},
            {"tail-LD(1L)"     , "───────┐       │       │┐      │"},
            {"tail-RD(1R)"     , "┌───────│       │       │      ┌"},
            {"tail-RL(1R)"     , "────────                ────────"},
            {"tail-DU(1D)"     , "│      ││      ││      ││      │"},
            {"tail-UL(1U)"     , "┘      │       │       │───────┘"},
            {"tail-RU(1R)"     , "│      └│       │       └───────"},
            {"tail-DL(1D)"     , "───────┐       │       │┐      │"},
            {"tail-DR(1D)"     , "┌───────│       │       │      ┌"},
            {"tail-LE(1L)"     , "───────┐       │       │───────┘"},
            {"tail-UE(1U)"     , "│      ││      ││      │└──────┘"},
            {"tail-RE(1R)"     , "┌───────│       │       └───────"},
            {"tail-DE(1D)"     , "┌──────┐│      ││      ││      │"},
    };
    private Dictionary<string, string> AnimeCollection = new()
        {
            
        };
    public Render(int [] resolution, object[,] map)
    {
        this.resolution = resolution;
        this.map  = map;
        this.textureMap = new string[this.map.GetLength(0),this.map.GetLength(1)];
        CreateAnimation("head", "space", 8);
        foreach(var texture in TextureCollection)
        {
            Console.WriteLine($"key: {texture.Key}  value: {texture.Value}");
        }
        Console.Write("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
    }
    public void RenderMap(object[,] map)
    {
        this.map  = map;
        this.textureMap = new string[this.map.GetLength(0),this.map.GetLength(1)];
        for (int i=0; i < this.map.GetLength(0); i++)
        {
            for (int j=0; j < this.map.GetLength(1); j++)
            {
                DinamicTail(i,j);
            }
        }
        for (int i=0; i < this.map.GetLength(0); i++)
        {
            for (int j=0; j < this.map.GetLength(1); j++)
            {
                if (this.map[i,j] is Movable)
                    AnimeMove((Movable)this.map[i,j]);
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
    private void CreateAnimation(string textureName, string replacement, int tickNumber)
    {
        for (int j=tickNumber-1; j>=0; j--)
        {
            string texture = (this.TextureCollection[replacement] + this.TextureCollection[textureName+"(0)"]).Substring(this.resolution[0]*(int)Math.Round((float)(tickNumber - j)/2, 1), this.resolution[0]*this.resolution[1]);
            this.TextureCollection.Add(textureName+"("+j+"U)", texture);
        }
        for (int j=tickNumber-1; j>=0; j--)
        {
            string texture = (this.TextureCollection[textureName+"(0)"] + this.TextureCollection[replacement]).Substring(this.resolution[0]*(int)Math.Round((float)j/2, 1), this.resolution[0]*this.resolution[1]);
            this.TextureCollection.Add(textureName+"("+j+"D)", texture);
        }
        for (int j=tickNumber-1; j>=0; j--)
        {
            string texture = "";
            for ( int i = 0; i < this.resolution[1]; i ++)
            {
               texture += (this.TextureCollection[replacement].Substring(i*this.resolution[0]+1, j) + this.TextureCollection[textureName+"(0)"]).Substring(i*this.resolution[0], this.resolution[0]);
            }
            this.TextureCollection.Add(textureName+"("+j+"L)", texture);
        }
        for (int j=tickNumber-1; j>=0; j--)
        {
            string texture = "";
            for ( int i = 0; i < this.resolution[1]; i ++)
            {
               texture += (this.TextureCollection[textureName+"(0)"].Substring(i*this.resolution[0]+1, j) + this.TextureCollection[replacement]).Substring(0, this.resolution[0]);
            }
            this.TextureCollection.Add(textureName+"("+j+"R)", texture);
        }
        
    }
    private void AnimeMove(Movable movable)
    {
        if (movable is Head && !(movable.TickAnimetion == 0)/*|| (movable is Tail && ((Tail)movable).id == 0)*/)
        {
            this.textureMap[movable.position[0],movable.position[1]] += "("+movable.TickAnimetion.ToString()+movable.GetDirection()+")";
        }
        else
        {
            this.textureMap[movable.position[0],movable.position[1]] += "("+0+")";
        }
    }
    private void DinamicTail(int i,int j)
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