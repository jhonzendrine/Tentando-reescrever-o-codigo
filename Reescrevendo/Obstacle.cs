public class Obstacle : ItemMap
{
 
}


public class Tree : Obstacle
{
    public int valor = 3;

    public override string ToString()
    {
        return "$$ ";
    }
}

public class Water : Obstacle
{

    public override string ToString()
    {
        return "## ";
    }
}

public class Radiotivo : Obstacle

{
    public int valor = -10;
    public int valor1 = -30;

    public override string ToString()
    {
        return "!! ";
    }
}
