class Render
{
    private int[] resolution;
    private Dictionary<string, string> TextureCollection33 = new()
    {
        {"border"      , "█████████"},
        {"space"       , "         "},
        {"head"        , "╔═╗║ ║╚═╝"},
        {"tail"        , "┌─┐│ │└─┘"},
        {"tail-LR"     , "─────────"},
        {"tail-UD"     , "│ ││ ││ │"},
        {"tail-LU"     , "┘ │  │──┘"},
        {"tail-UR"     , "│ └│  └──"},
        {"tail-LD"     , "──┐  │┐ │"},
        {"tail-RD"     , "┌──│  │ ┌"},
        {"tail-RL"     , "─────────"},
        {"tail-DU"     , "│ ││ ││ │"},
        {"tail-UL"     , "┘ │  │──┘"},
        {"tail-RU"     , "│ └│  └──"},
        {"tail-DL"     , "──┐  │┐ │"},
        {"tail-DR"     , "┌──│  │ ┌"},
        {"tail-LE"     , "──┐  │──┘"},
        {"tail-UE"     , "│ ││ │└─┘"},
        {"tail-RE"     , "┌──│  └──"},
        {"tail-DE"     , "┌─┐│ ││ │"},
    };
    private Dictionary<string, string> TextureCollection = new()
    {
        {"border"      , "███████████████"},
        {"space"       , "               "},
        {"head"        , "╔═══╗║   ║╚═══╝"},
        {"tail"        , "┌───┐│   │└───┘"},
        {"tail-LR"     , "───────────────"},
        {"tail-UD"     , "│   ││   ││   │"},
        {"tail-LU"     , "┘   │    │────┘"},
        {"tail-UR"     , "│   └│    └────"},
        {"tail-LD"     , "────┐    │┐   │"},
        {"tail-RD"     , "┌────│    │   ┌"},
        {"tail-RL"     , "───────────────"},
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
    public Render(int [] resolution)
    {
        this.resolution = resolution;
    }
    public void OutputDisplay(string[,] map)
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
    
}