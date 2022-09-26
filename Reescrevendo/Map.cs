
public class Map
{

    private int i = 0;
    private int j = 0;

    private int mnivel = 1;
    public ItemMap[,] matrix = new ItemMap[10,10];
   
    public Robo robo = new Robo(0, 0);

    public Map()
    {    
        /*   
        if(robo.proxnivel*mnivel == robo.pontos)
        {
            int xn = 10 + mnivel;
            int yn = 10 + mnivel;
            matrix = new ItemMap[xn,yn];
            matrix[0,0] = robo;
            mnivel = mnivel+1;
        }      */ //Testando
        
        for(i = 0; i < matrix.GetLength(0); i++){
            for(j = 0; j < matrix.GetLength(0); j++){
                matrix[i,j] = new Empty();
            }           
        }     
  

        matrix[robo.x, robo.y] = robo;

        matrix[1, 9] = new JewelRed();
        matrix[8,8] = new JewelRed();

       // JewelGreen jr2 = new JewelGreen();
        matrix[9, 1] = new JewelGreen();
        matrix[7,6] = new JewelGreen();

        //JewelBlue jr3 = new JewelBlue();
        matrix[3,4] = new JewelBlue();
        matrix[2,1] = new JewelBlue();

       // Tree tree = new Tree();
        matrix[5,9] = new Tree();
        matrix[3,9] = new Tree();
        matrix[8,3] = new Tree();
        matrix[2,5] = new Tree();
        matrix[1,4] = new Tree();

       // Water water = new Water();
        matrix[5,0] = new Water();
        matrix[5,1] = new Water();
        matrix[5,2] = new Water();
        matrix[5,3] = new Water();
        matrix[5,4] = new Water();
        matrix[5,5] = new Water();
        matrix[5,6] = new Water();

        // repete para todos os outros itens

    }

    public bool VerificarJewels()
    {
        for (i = 0; i < matrix.GetLength(0); i++) {
            for (j = 0; j < matrix.GetLength(0); j++) {
                if (matrix[i, j] is Jewel) return false;
            }
        }
        return true;

    }

    public void Print()
    {
        
        if(VerificarJewels() && i <= 30)
        {
            Console.Clear();
            int xn = 10 + mnivel;
            int yn = 10 + mnivel;
            matrix = new ItemMap[xn,yn];
            mnivel = mnivel+1;

            for(i = 0; i < matrix.GetLength(0); i++){
            for(j = 0; j < matrix.GetLength(0); j++){
                matrix[i,j] = new Empty();
            }
                       
        } 

            robo.x = 0;
            robo.y = 0;

            matrix[robo.x,robo.y] = robo;

            ItensRandom();
            
            Print();
        } //Testando
 
        else if (i<=30){
        Console.Clear();
        for(i = 0; i < matrix.GetLength(0); i++){
            for(j = 0; j < matrix.GetLength(0); j++){
                Console.Write(matrix[i,j]);                
            }
            Console.Write("\n");
        }

        
        Console.WriteLine("Nivel : "+ mnivel+" Pontuação : "+ robo.pontos+" Energia : "+robo.energia);
        //Console.WriteLine("Pontuação "+ robo.pontos);
        //Console.WriteLine("Energia "+robo.energia);
        Console.WriteLine();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Acabou o jogo");
        }
        
    }

    public void Insert(ItemMap Item, int x, int y)
    {
        matrix[x,y] = Item;
    }


    public void MoveSouth()
    {
        int mx = i;

        if(robo.x==mx)
        {
        Move(mx);
        }
        else
        {
            Move(robo.x);
        }
        void Move(int dc) // dc descer
        {
            try
                {
                if(matrix[robo.x+1,robo.y] is Empty && (robo.energia > 0) || matrix[robo.x+1,robo.y] is Radiotivo)
                    {

                        if(matrix[robo.x+1,robo.y] is Radiotivo)
                        {
                            (int x_old, int x) = robo.MoveSouth();

                            matrix[x_old, robo.y] = new Empty();
                            matrix[x, robo.y] = robo;
                            robo.energia = robo.energia - 30;
                            Radioativo1();

                        }
                        else
                        {
                            (int x_old, int x) = robo.MoveSouth();

                            matrix[x_old, robo.y] = new Empty();
                            matrix[x, robo.y] = robo;
                            robo.energia = robo.energia - 1;
                            Radioativo1();
                        }
                        } 


            }
            catch(IndexOutOfRangeException)
            {
                Console.WriteLine("Não pode descer");
            }
        }
              

    }

    public void MoveNorth()
    {
        if(robo.x==0)
        {
        Move(0);
        }
        else
        {
            Move(robo.x);
        }
        
        void Move(int su) // su = subir
        {
            try
                {
                if(matrix[robo.x-1,robo.y] is Empty && (robo.energia > 0) || matrix[robo.x-1,robo.y] is Radiotivo)
                {
                
                    if(matrix[robo.x-1,robo.y] is Radiotivo)
                        {
                            (int x_old, int x) = robo.MoveNorth();
                
                            matrix[x_old, robo.y] = new Empty();
                            matrix[x, robo.y] = robo;
                            robo.energia = robo.energia - 30;
                            Radioativo1();

                        }
                    else
                        {
                            (int x_old, int x) = robo.MoveNorth();
                            
                            matrix[x_old, robo.y] = new Empty();
                            matrix[x, robo.y] = robo;
                            robo.energia = robo.energia - 1;
                            Radioativo1();

                        }
                }


            }
            catch(IndexOutOfRangeException)
            {
                Console.WriteLine("Não pode subir");
            }
        }
                
    }


    public void MoveRigth()
    {
        int mx = j;

        if(robo.x==mx)
        {
        Move(mx);
        }
        else
        {
            Move(robo.x);
        }
        void Move(int di) // di = direita
        {
            try
                {
                if (matrix[robo.x, robo.y+1] is Empty && (robo.energia > 0) || matrix[robo.x, robo.y+1] is Radiotivo)
                    {
                        if(matrix[robo.x, robo.y+1] is Radiotivo)
                        {
                            (int y_old, int y) = robo.MoveRigth();

                            matrix[robo.x, y_old] = new Empty();
                            matrix[robo.x, y] = robo;
                            robo.energia = robo.energia - 30;
                            Radioativo1();
                        }
                        else
                        {
                            (int y_old, int y) = robo.MoveRigth();

                            matrix[robo.x, y_old] = new Empty();
                            matrix[robo.x, y] = robo;
                            robo.energia = robo.energia - 1;
                            Radioativo1();
                        }
                       
                    }


            }
            catch(IndexOutOfRangeException)
            {
                Console.WriteLine("Não pode ir para Direita");
            }
        }
        
    }

    public void MoveLeft()
    {
        if(robo.y==0)
        {
        Move(0);
        }
        else
        {
            Move(robo.y);
        }
        
        void Move(int su) // su = subir
        {
            try
                {
                    if (matrix[robo.x, robo.y-1] is Empty && (robo.energia > 0) || matrix[robo.x, robo.y-1] is Radiotivo)
                            {
                                if(matrix[robo.x, robo.y-1] is Radiotivo)
                                {
                                     (int y_old, int y) = robo.MoveLeft();
                                    matrix[robo.x, y_old] = new Empty();
                                    matrix[robo.x, y] = robo;
                                    robo.energia = robo.energia - 30;
                                    Radioativo1();
                                }
                                else
                                {
                                    (int y_old, int y) = robo.MoveLeft();
                                    matrix[robo.x, y_old] = new Empty();
                                    matrix[robo.x, y] = robo;
                                    robo.energia = robo.energia - 1;
                                    Radioativo1();
                                }
                            }

                }
            catch(IndexOutOfRangeException)
            {
                Console.WriteLine("Não pode ir para Esquerda");
            }
        }
        // matrix[robo.x, y_old] = new Empty();
        // matrix[robo.x, y] = robo;

    }

    public void Radioativo1()
   {
            if(matrix[robo.x, robo.y-1] is Radiotivo || matrix[robo.x, robo.y+1] is Radiotivo || matrix[robo.x-1, robo.y] is Radiotivo || matrix[robo.x+1, robo.y] is Radiotivo)
            {
                    robo.energia = robo.energia -10;
            }
            
   } 

    public void Capture()
    {
        (int x, int y) = robo.Capture();
        matrix[robo.x, robo.y] = new Empty();
        matrix[robo.x, robo.y] = robo;

        // Try Norte

        try
        {
            if(matrix[robo.x-1,robo.y] is JewelRed || matrix[robo.x-1,robo.y] is JewelBlue || matrix[robo.x-1,robo.y] is JewelGreen || matrix[robo.x-1,robo.y] is Tree || matrix[robo.x-1,robo.y] is Water)
        {
            if (matrix[robo.x-1,robo.y] is JewelRed jr)
            {
                robo.pontos = robo.pontos + jr.valor ;
                Situ(true);
            }
            if(matrix[robo.x-1,robo.y] is JewelBlue jb)
            {
                robo.pontos = robo.pontos + jb.valor ;
                robo.energia = robo.energia + jb.energiab;
                Situ(true);
            }
            if(matrix[robo.x-1,robo.y] is JewelGreen jg)
            {
                robo.pontos = robo.pontos + jg.valor;
                Situ(true);
            }
            if(matrix[robo.x-1,robo.y] is Tree tr)
            {
                robo.energia = robo.energia + tr.valor;
            }

            void Situ(bool h)
            {
                matrix[robo.x-1,robo.y] = new Empty();
                matrix[robo.x,robo.y] = robo;
            }
            //matrix[robo.x-1,robo.y] = new Empty();
            //matrix[robo.x,robo.y] = robo;
           
        }
            
        }
        catch(IndexOutOfRangeException)
        {
            Console.WriteLine("Não tem mais matrix");
        }

        // Excessão Sul
        try
        {
        
        if(matrix[robo.x+1,robo.y] is JewelRed || matrix[robo.x+1,robo.y] is JewelBlue || matrix[robo.x+1,robo.y] is JewelGreen || matrix[robo.x+1,robo.y] is Tree || matrix[robo.x+1,robo.y] is Water)
        {
             if (matrix[robo.x+1,robo.y] is JewelRed jr)
            {
                robo.pontos = robo.pontos + jr.valor;
                Situ(true);
            }
            if(matrix[robo.x+1,robo.y] is JewelBlue jb)
            {
                robo.pontos = robo.pontos + jb.valor;
                robo.energia = robo.energia + jb.energiab;
                Situ(true);
            }
            if(matrix[robo.x+1,robo.y] is JewelGreen jg)
            {
                robo.pontos = robo.pontos + jg.valor;
                Situ(true);
            }
            if(matrix[robo.x+1,robo.y] is Tree tr)
            {
                robo.energia = robo.energia + tr.valor;
            }
            

            void Situ(bool h)
            {
                matrix[robo.x+1,robo.y] = new Empty();
                matrix[robo.x,robo.y] = robo;
            }

            //matrix[robo.x+1,robo.y] = new Empty();
            //matrix[robo.x,robo.y] = robo;

        }
        }
        catch(IndexOutOfRangeException)
        {
            Console.WriteLine("Não tem mais matrix");
        }

        // Excessão esquerda

        try
        {
        if(matrix[robo.x,robo.y-1] is JewelRed || matrix[robo.x,robo.y-1] is JewelBlue || matrix[robo.x,robo.y-1] is JewelGreen || matrix[robo.x,robo.y-1] is Tree || matrix[robo.x,robo.y-1] is Water)
        {
             if (matrix[robo.x,robo.y-1] is JewelRed jr)
            {
                robo.pontos = robo.pontos + jr.valor;
                Situ(true);
            }
            if(matrix[robo.x,robo.y-1] is JewelBlue jb)
            {
                robo.pontos = robo.pontos + jb.valor;
                robo.energia = robo.energia + jb.energiab;
                Situ(true);
            }
            if(matrix[robo.x,robo.y-1] is JewelGreen jg)
            {
                robo.pontos = robo.pontos + jg.valor;
                Situ(true);
            }
            if(matrix[robo.x,robo.y-1] is Tree tr)
            {
                robo.energia = robo.energia + tr.valor;
            }
            

                void Situ(bool h)
            {
                matrix[robo.x,robo.y-1] = new Empty();
                matrix[robo.x,robo.y] = robo;
            }
            //matrix[robo.x,robo.y-1] = new Empty();
            //matrix[robo.x,robo.y] = robo;

        }
        }
        catch(IndexOutOfRangeException)
        {
            Console.WriteLine("Não tem mais matrix");
        }

        // Excessão Direita

        try{

        if(matrix[robo.x,robo.y+1] is JewelRed || matrix[robo.x,robo.y+1] is JewelBlue || matrix[robo.x,robo.y+1] is JewelGreen || matrix[robo.x,robo.y+1] is Tree || matrix[robo.x,robo.y+1] is Water)
        {
             if (matrix[robo.x,robo.y+1] is JewelRed jr)
            {
                robo.pontos = robo.pontos + jr.valor;
                Situ(true);
            }
            if(matrix[robo.x,robo.y+1] is JewelBlue jb)
            {
                robo.pontos = robo.pontos + jb.valor;
                robo.energia = robo.energia + jb.energiab;
                Situ(true);
            }
            if(matrix[robo.x,robo.y+1] is JewelGreen jg)
            {
                robo.pontos = robo.pontos + jg.valor;
                Situ(true);
            }
            if(matrix[robo.x,robo.y+1] is Tree tr)
            {
                robo.energia = robo.energia + tr.valor;
            }
           

                void Situ(bool h)
            {
                matrix[robo.x,robo.y+1] = new Empty();
                matrix[robo.x,robo.y] = robo;
            }

            //matrix[robo.x,robo.y+1] = new Empty();
            //matrix[robo.x,robo.y] = robo;


        }
        }
        catch(IndexOutOfRangeException)
        {
            Console.WriteLine("Não tem mais matrix");
        }

    }

    private void ItensRandom()
    {   

        double porj = (i*j)*0.02;
        double porw = (i*j)*0.07;
        double port = (i*j)*0.05;
       
        Random r = new Random(1);  

        for(int x = 0; x < porj; x++)
        {
            int xRandom = r.Next(0, i);
            int yRandom = r.Next(0, j);

            this.Insert(new JewelBlue(), xRandom, yRandom);

        }

        for(int x = 0; x < porj; x++)
        {
            int xRandom = r.Next(0, i);
            int yRandom = r.Next(0, j);

            this.Insert(new JewelGreen(), xRandom, yRandom);

        }

        for(int x = 0; x < porj; x++)
        {
            int xRandom = r.Next(0, i);
            int yRandom = r.Next(0, j);

            this.Insert(new JewelRed(), xRandom, yRandom);

        }

        for(int x = 0; x < porw; x++)
        {
            int xRandom = r.Next(0, i);
            int yRandom = r.Next(0, j);

            this.Insert(new Water(), xRandom, yRandom);

        }

        for(int x = 0; x < port; x++)
        {
            int xRandom = r.Next(0, i);
            int yRandom = r.Next(0, j);

            this.Insert(new Tree(), xRandom, yRandom);

        }
        for(int x = 0; x < porj; x++)
        {
            int xRandom = r.Next(0, i);
            int yRandom = r.Next(0, j);

            this.Insert(new Radiotivo(), xRandom, yRandom);

        }
    }

}

