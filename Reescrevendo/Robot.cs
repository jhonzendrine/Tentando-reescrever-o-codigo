public class Robo : ItemMap
{

    public int pontos {get; set;} = 0;

    public int energia {get; set;} = 5;

    public List<Jewel> Bag = new List<Jewel>();
    
    //public int proxnivel {get; set;} = ; //Testando
            
    public Robo(int x, int y)
    {
        this.x = x; //this usando variavel da classe principal esse exemplo aqui usamos da ItemMap
        this.y = y;
    }

    public (int, int) MoveSouth()
    {
        
        int x_old = x;
        x = x+1;

        return (x_old, x);
    }

    public (int, int) MoveNorth()
    {
        
        int x_old = x;
        x = x-1;

        return (x_old, x);
    }

    public (int, int) MoveRigth()
    {
        int y_old = y;
        y = y+1;

        return(y_old, y);
    }

    public (int, int) MoveLeft()
    {
        int y_old = y;
        y = y-1;

        return(y_old, y);
    }

       public (int, int) Capture()
    {
        int y_old = y;
        int x_old = x;

        return(x,y);
       
    }


    public override string ToString() // Override subscrever uma String
    {
        return "ME ";
    }
}