// Paula Sierra Luque
// José Tomás Gómez Becerra

using System.ComponentModel.Design;

namespace PRACTICA1
{
    // HAY QUE HACER COMENTARIOS BIEN EXPLICAETES Y TO GUAPOS <3.

    class MainClass
    {
        // Generador de aleatorios (para mover abeja).
        static Random rnd = new Random(); 

        // D0imensiones del área de juego.
        const int ANCHO = 12,
                  ALTO = 9; 

        public static void Main()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(ANCHO, ALTO); // Tamaño de la consola.
            int jugF, jugC,                     // Posición del jugador.
            abejaF, abejaC,                     // Posición de la abeja.
            delta = 300;                        // Retardo entre frames (ms).
            bool colision = false,                      // Colisión entre abeja y jugador.
                 exit = false;                          // Finalizar el juego de forma forzosa.

            // Posicion inicial del player.
            jugF = jugC = 0;   
            
            // La abeja aparece en una posición aleatoria.
            abejaF = rnd.Next(0, ALTO);
            abejaC = rnd.Next(0, ANCHO);

            // Para que sea imposible que aparezca encima del player la abeja (mirar si esto se puede implementar dentro del bucle principal).
            while (jugF == abejaF && jugC == abejaC)
            {
                abejaF = rnd.Next(0, ALTO);
                abejaC = rnd.Next(0, ANCHO);
            }

            // Renderizado inicial.
            Console.Clear(); // Limpia pantalla antes de un nuevo renderizado.
            Console.SetCursorPosition(jugC, jugF);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(0);

            // Abeja (en proceso):
            Console.SetCursorPosition(abejaC, abejaF);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("+");

            // Mientras el juego no haya terminado... (He cambiado terminado por colision ya que el juego termina AL COLISIONAR).
            while (!colision && !exit) 
            {
                // Recogida del input.
                string s = "";
                while (Console.KeyAvailable) s = (Console.ReadKey(true)).KeyChar.ToString();

                exit = s == "q";

                // Movimiento del jugador en función del input.
                if (s == "w" && jugF > 0)
                {
                    jugF--; // Arriba.
                }
                else if (s == "a" && jugC > 0)
                {
                    jugC--; // Izquierda.
                }
                else if (s == "s" && jugF < ALTO - 1)
                {
                    jugF++; // Abajo.
                }
                else if (s == "d" && jugC < ANCHO - 1)
                {
                    jugC++; // Derecha.
                }

                // Detección de la colisión.
                colision = jugF == abejaF && jugC == abejaC;

                if (!colision)
                {
                    // Movimiento aleatorio de la abeja.
                    //int direccion = rnd.Next(0, 4); // Random entre las 4 direcciones (0, 1, 2, 3). (Cuatro no se cuenta porque es [a, b).

                    // IA de la Abeja.
                    // Vector dirección.
                    int vectorF = jugF - abejaF,
                        vectorC = jugC - abejaC;
                    
                    if(vectorF < 0)
                    {
                        abejaF--; // Arriba.
                    } 
                    else if (vectorC < 0)
                    {
                        abejaC--; // Izquierda.
                    }
                    else if (vectorF > 0)
                    {
                        abejaF++; // Abajo.
                    }
                    else if (vectorC > 0)
                    {
                        abejaC++; // Derecha.
                    }
                  

                    //// Establezcamos que 0 arriba, 1 izquierda, 2 abajo, 3 derecha.
                    //if (direccion == 0 && abejaF > 0)
                    //{
                    //    abejaF--; // Arriba.
                    //}
                    //else if (direccion == 1 && abejaC > 0)
                    //{
                    //    abejaC--; // Izquierda.
                    //}
                    //else if (direccion == 2 && abejaF < ALTO -1)
                    //{
                    //    abejaF++; // Abajo.
                    //}
                    //else if (direccion == 3 && abejaC < ANCHO -1)
                    //{
                    //    abejaC++; // Derecha.
                    //}
                }

                // Detección de la colisión.
                colision = jugF == abejaF && jugC == abejaC;

                // Renderizado de entidades en consola.
                Console.Clear(); // Limpia pantalla antes de un nuevo renderizado.
                Console.SetCursorPosition(jugC, jugF);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(0);

                // Abeja (en proceso):
                Console.SetCursorPosition(abejaC, abejaF);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("+");

                // Retardo entre frames.
                System.Threading.Thread.Sleep(delta);
            }

            if (colision)
            {
                Console.Clear();
                Console.SetCursorPosition(jugC, jugF);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("*");
                Console.ForegroundColor = ConsoleColor.Black;
            }
        }   
    }
}    
