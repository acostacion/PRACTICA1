// Paula Sierra Luque
// José Tomás Gómez Becerra

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
            Console.SetWindowSize(ANCHO, ALTO); // Tamaño de la consola.
            int jugF, jugC,                     // Posición del jugador.
            abejaF, abejaC,                     // Posición de la abeja.
            delta = 300;                        // Retardo entre frames (ms).
            bool colision = false;              // Colisión entre abeja y jugador.

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

            // Mientras el juego no haya terminado... (He cambiado terminado por colision ya que el juego termina AL COLISIONAR).
            while (!colision) 
            {
                // Recogida del input.
                string s = "";
                while (Console.KeyAvailable) s = (Console.ReadKey(true)).KeyChar.ToString();

                // Movimiento del jugador en función del input.
                if (s == "w" && jugF > 0)
                {
                    jugF--; // Arriba.
                }
                else if (s == "a" && jugC > 0)
                {
                    jugC--; // Izquierda.
                }
                else if (s == "s" && jugF < ALTO)
                {
                    jugF++; // Abajo.
                }
                else if (s == "d" && jugC < ANCHO)
                {
                    jugC++; // Derecha.
                }

                // Movimiento aleatorio de la abeja.
                int direccion = rnd.Next(0,3); // Random entre las 4 direcciones (0, 1, 2, 3).

                // Establezcamos que 0 arriba, 1 izquierda, 2 abajo, 3 derecha.

                if (direccion == 0 && abejaF > 0)
                {
                    abejaF--; // Arriba.
                }
                else if (direccion == 1 && abejaC > 0)
                {
                    abejaC--; // Izquierda.
                }
                else if (direccion == 2 && abejaF < ALTO)
                {
                    abejaF++; // Abajo.
                }
                else if (direccion == 3 && abejaC < ANCHO)
                {
                    abejaC++; // Derecha.
                }

                // Detección de la colisión (en proceso).

                if(jugF == abejaF && jugC == abejaC)
                {
                    // Colisionan.
                    colision = true;

                    Console.Clear(); 
                    Console.SetCursorPosition(jugC, jugF);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*");
                }

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
        }   
    }
}    
