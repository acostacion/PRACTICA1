// Paula Sierra Luque
// José Tomás Gómez Becerra

using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace PRACTICA1
{
    // HAY QUE HACER COMENTARIOS BIEN EXPLICAETES Y TO GUAPOS <3.

    class MainClass
    {
        // Generador de aleatorios (para mover abeja).
        //static Random rnd = new Random(); // Solo se usa si el movimiento de la abeja es aleatorio.

        // D0imensiones del área de juego.
        const int ANCHO = 12,
                  ALTO = 9;
        public static void Main()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(ANCHO, ALTO); // Tamaño de la consola.
            int jugF, jugC,                     // Posición del jugador.
            abejaF, abejaC,                     // Posición de la abeja.
            delta = 300,                        // Retardo entre frames (ms).
            framesAbeja = 2,                    // Número de frames para reiniciar el contador.
            contador = 0;                       // Contador para los frames que llevará la abeja.
            bool colision = false,                      // Colisión entre abeja y jugador.
                 exit = false;                          // Finalizar el juego de forma forzosa.

            // Posicion inicial del player.
            jugF = jugC = 0;

            // La abeja aparece en la esquina abajo derecha.
            abejaF = ALTO - 1;
            abejaC = ANCHO - 1;

            // Renderizado inicial.
            Console.Clear(); // Limpia pantalla antes de un nuevo renderizado.
            Console.SetCursorPosition(jugC, jugF);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(0);

            // Abeja (en proceso):
            Console.SetCursorPosition(abejaC, abejaF);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("+");

            // Mientras no haya colisión y no salgamos.
            while (!colision && !exit)
            {
                // Recogida del input.
                string s = "";
                while (Console.KeyAvailable) s = (Console.ReadKey(true)).KeyChar.ToString().ToUpper();
                exit = s == "Q";

                // Movimiento del jugador en función del input.
                if (s == "W" && jugF > 0)
                {
                    jugF--; // Arriba.
                }
                else if (s == "A" && jugC > 0)
                {
                    jugC--; // Izquierda.
                }
                else if (s == "S" && jugF < ALTO - 1)
                {
                    jugF++; // Abajo.
                }
                else if (s == "D" && jugC < ANCHO - 1)
                {
                    jugC++; // Derecha.
                }

                // Detección de la colisión.
                colision = jugF == abejaF && jugC == abejaC;

                if (!colision) // Si no haya colisión.
                {
                    if (contador >= framesAbeja) // Si el contador es mayor o igual a los frames, se ejecutará el movimiento.
                    {
                        int vectorF = jugF - abejaF,
                        vectorC = jugC - abejaC;

                        if (Math.Abs(vectorC) > Math.Abs(vectorF))
                        {
                            if (vectorC > 0)
                            {
                                abejaC++;
                            }
                            else
                            {
                                abejaC--;
                            }
                        }
                        else
                        {
                            if (vectorF > 0)
                            {
                                abejaF++;
                            }
                            else
                            {
                                abejaF--;
                            }
                        }

                        // Movimiento aleatorio de la abeja.
                        //int direccion = rnd.Next(0, 4); // Random entre las 4 direcciones (0, 1, 2, 3). (Cuatro no se cuenta porque es [a, b).

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

                        contador = 0; // Reiniciamos contador.
                    }
                    else
                    {
                        contador++; // Sumamos al contador.
                    }
                    
                    // Detección de la colisión.
                    colision = jugF == abejaF && jugC == abejaC;

                    // Renderizado de entidades en consola.
                    // Player:
                    Console.Clear(); // Limpia pantalla antes de un nuevo renderizado.
                    Console.SetCursorPosition(jugC, jugF);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(0);
                    // Abeja:
                    Console.SetCursorPosition(abejaC, abejaF);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("+");

                    if (colision) // Si hay colisión.
                    {
                        // Dibujamos * en el lugar del player.
                        Console.Clear();
                        Console.SetCursorPosition(jugC, jugF);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("*");
                    }

                    // Retardo entre frames.
                    System.Threading.Thread.Sleep(delta);
                }
            }
        }
    }
}
