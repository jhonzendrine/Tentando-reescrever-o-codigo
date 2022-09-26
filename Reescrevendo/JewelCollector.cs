using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class JewelCollector {

  public static void Main() {

      Map map = new Map();
                  
      bool running = true;

      do {

          map.Print();
          // Mostrar pontuação aqui.

          ConsoleKeyInfo cki = Console.ReadKey(true);

switch (cki.Key.ToString())
{
  case "W": map.MoveNorth(); break;
  case "S" : map.MoveSouth(); break;
  case "D" : map.MoveRigth(); break;
  case "A" : map.MoveLeft(); break;
  case "G" : map.Capture();break;
  case "Escape" : running = false; break;
  default: Console.WriteLine(cki.Key.ToString()); break;
}

      } while (running);

  }
}