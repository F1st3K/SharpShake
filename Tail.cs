class Tail:Movable
{
    public string type = "tail";
    public int id;
    public int[] lastPosition = new int []{0,0};
    public Tail(int id, int []position)
    {
        this.position = position;
        this.lastPosition[0] = position[0]+1;
        this.lastPosition[1] = position[1];
        this.id = id;
        this.prevposition = position;
    }
}