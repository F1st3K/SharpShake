class Shake : Movable
{
    public Head HeadShake;
    public List<Tail> TailsShake;
    public Shake(int []position)
    {
        HeadShake = new Head(new int []{position[0],position[1]});
        TailsShake = new List<Tail>{new Tail(0, new int []{position[0]+1,position[1]})};
    }
    public override void Move(object [,] map, string direction)
    {
        int [] prevPosition = HeadShake.position;
        HeadShake.Move(map, direction);
        for (int i=0; i<TailsShake.Count;i++)
        {
            TailsShake[i].lastPosition = TailsShake[i].position;
            TailsShake[i].Move(map, prevPosition);
            prevPosition = TailsShake[i].lastPosition;
        }
    }
    public void GrowTail(object[,] map)
    {
        TailsShake.Add(new Tail(TailsShake[TailsShake.Count-1].id+1, TailsShake[TailsShake.Count-1].lastPosition));
        map[TailsShake[TailsShake.Count-1].position[0], TailsShake[TailsShake.Count-1].position[1]] = TailsShake[TailsShake.Count-1];
    }
}