public class ItemMap
{
   public int x; // protected
   public int y;
}

public class Empty : ItemMap
{
    public override string ToString()
    {
        return "-- ";
    }
}

public class Jewel : ItemMap
{
 
}

public class JewelRed : Jewel
{
    public int valor = 100;

    public override string ToString()
    {   
        return "JR ";
    }

}

public class JewelGreen : Jewel
{

    public int valor = 50;

    public override string ToString()
    {   
        
        return "JG ";
    }
}

public class JewelBlue : Jewel //, Recarregar
{
    public int valor = 10;
    public int energiab = 5;

    public override string ToString()
    {
        
        return "JB ";
    }

}

/*
public interface Recarregar

{
    public void Recharge(Robo r);
}

public class Collect
{
    public void Collected();
}
*/
