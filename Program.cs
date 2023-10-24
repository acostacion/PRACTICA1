// Paula Sierra Luque
// José Tomás Gómez Becerra

using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace PRACTICA1
{
    class MainClass
    {
        // Generador de aleatorios (para mover abeja).
        //static Random rnd = new Random(); // Solo se usa si el movimiento de la abeja es aleatorio.

        // Dimensiones del área de juego.
        const int ANCHO = 12,
                  ALTO = 9,

        // Número de frames para reiniciar el contador.
                  FRAMESABEJA = 2;

        public static void Main()
        {
            Console.CursorVisible = false;      // Para que no se muestre el cursor.
            Console.SetWindowSize(ANCHO, ALTO); // Tamaño de la consola.

            int jugF, jugC,                     // Posición del jugador.
            abejaF, abejaC,                     // Posición de la abeja.
            balaF = -1, balaC,                  // Posición de la bala. Es -1 al comienzo porque no está.
            delta = 300,                        // Retardo entre frames (ms).
            contador = 0;                       // Contador para los frames que llevará la abeja.

            bool colision = false,              // Colisión entre abeja y jugador.
                 colBalaAbeja = false,          // Colisión entre bala y abeja.
                 exit = false;                  // Finalizar el juego de forma forzosa.

            // Posicion inicial del player (esquina arriba izquierda).
            jugF = jugC = 0;

            // Posicion inicial de la abeja (esquina abajo derecha).
            abejaF = ALTO - 1;
            abejaC = ANCHO - 1;

            #region RENDERIZADO INICIAL [MEJORA].

            // Jugador:
            Console.Clear();                                     // Limpiar la consola para un nuevo renderizado.                                
            Console.SetCursorPosition(jugC, jugF);               // Establecer la posición del cursor para el jugador.
            Console.ForegroundColor = ConsoleColor.DarkCyan;     // Configurar el color del texto para el jugador.
            Console.Write(0);                                    // Mostrar el jugador en la posición del cursor especificada.

            // Abeja:
            Console.SetCursorPosition(abejaC, abejaF);           // Establecer la posición del cursor para la abeja.
            Console.ForegroundColor = ConsoleColor.Yellow;       // Configurar el color del texto para la abeja.   
            Console.Write("+");                                  // Mostrar la abeja en la posición del cursor especificada.
            #endregion

            #region BUCLE PRINCIPAL

            // Mientras no haya colisión entre la abeja y el jugador y no salgamos (no hagamos un escape).
            while (!colision && !exit && !colBalaAbeja)
            {
                # region RECOGIDA DEL INPUT.

                string s = "";

                // Leer la tecla presionada sin mostrarla en la consola y convertirla a mayúsculas.
                while (Console.KeyAvailable) s = (Console.ReadKey(true)).KeyChar.ToString().ToUpper();

                // Vector dirección del jugador.
                int dirJugF = 0,
                    dirJugC = 0;

                exit = s == "Q"; // Al presionar la "q" se hace un escape del juego.
                #endregion

                # region MOVIMIENTO DEL JUGADOR EN FUNCIÓN DEL INPUT.

                if (s == "W" && jugF > 0)
                {
                    jugF--; // Arriba.
                    dirJugF = -1;
                }
                else if (s == "A" && jugC > 0)
                {
                    jugC--; // Izquierda.
                    dirJugC = -1;
                }
                else if (s == "S" && jugF < ALTO - 1)
                {
                    jugF++; // Abajo.
                    dirJugF = 1;
                }
                else if (s == "D" && jugC < ANCHO - 1)
                {
                    jugC++; // Derecha.
                    dirJugC = 1;
                }
                else if (s == "L" && balaF == -1)
                {
                    // Vector dirección de la bala.
                    int dirBalaF = dirJugF,
                        dirBalaC = dirJugC;

                    // Le ponemos a la bala la posición actual del jugador.
                    balaF = jugF;
                    balaC = jugC;
                }
                #endregion

                #region MOVIMIENTO DE LA BALA.

                if (balaF != -1)
                {
                    // Mover la bala en la dirección de la bala.
                    balaF += dirBalaF;
                    balaC += dirBalaC;

                    // Verificar si la bala ha salido de los límites del juego.
                    if (balaF < 0 || balaF >= ALTO || balaC < 0 || balaC >= ANCHO)
                    {
                        balaF = -1; // La bala desaparece.
                    }
                }
                #endregion

                #region DETECCIÓN DE COLISIÓN [MEJORA].

                colision = jugF == abejaF && jugC == abejaC;

                colBalaAbeja = balaF == abejaF && balaC == abejaC;

                if (!colision) // Si no hay colisión.
                {
                    if (contador >= FRAMESABEJA) // Si el contador es mayor o igual a los frames, se ejecutará el movimiento.
                    {
                        // Vector dirección.
                        int vectorF = jugF - abejaF,
                            vectorC = jugC - abejaC;

                        // Si la magnitud de vectorC (horizontal) es mayor que la de vectorF...
                        if (Math.Abs(vectorC) > Math.Abs(vectorF))
                        {
                            // Si es positivo...
                            if (vectorC > 0)
                            {
                                abejaC++; // Derecha.
                            }
                            // Si es negativo...
                            else
                            {
                                abejaC--; // Izquierda.
                            }
                        }
                        // Si la magnitud de vectorF (vertical) es mayor que la de vectorC...
                        else
                        {
                            // Si es positivo...
                            if (vectorF > 0)
                            {
                                abejaF++; // Abajo.
                            }
                            // Si es negativo...
                            else
                            {
                                abejaF--; // Arriba.
                            }
                        }
                        #endregion

                        #region MOVIMIENTO ALEATORIO DE LA ABEJA [SIN USAR].

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
                    #endregion

                    #region DETECCIÓN DE LA COLISIÓN.

                    colision = jugF == abejaF && jugC == abejaC;

                    colBalaAbeja = balaF == abejaF && balaC == abejaC;
                    #endregion

                    #region RENDERIZADO DE ENTIDADES EN CONSOLA.

                    // Jugador.
                    Console.Clear();                                     // Limpiar la consola para un nuevo renderizado.                                
                    Console.SetCursorPosition(jugC, jugF);               // Establecer la posición del cursor para el jugador.
                    Console.ForegroundColor = ConsoleColor.DarkCyan;     // Configurar el color del texto para el jugador.
                    Console.Write(0);                                    // Mostrar el jugador en la posición del cursor especificada.

                    // Abeja.
                    Console.SetCursorPosition(abejaC, abejaF);           // Establecer la posición del cursor para la abeja.
                    Console.ForegroundColor = ConsoleColor.Yellow;       // Configurar el color del texto para la abeja.   
                    Console.Write("+");                                  // Mostrar la abeja en la posición del cursor especificada.

                    // Si hay colisión entre el jugador y la abeja...
                    if (colision) 
                    {
                        Console.Clear();                                 // Limpiamos la consola.
                        Console.SetCursorPosition(jugC, jugF);           // Ponemos el cursor en la posición actual del jugador.   
                        Console.ForegroundColor = ConsoleColor.Red;      // Configurar el color del texto para el "*".
                        Console.Write("*");                              // Dibujamos un '*' en la posición del jugador.
                    }   

                    // Si hay colisión entre la bala y la abeja...
                    if (colBalaAbeja)
                    {
                        abejaF = -1;
                        Console.Clear();                                 // Limpiamos la consola.
                        Console.SetCursorPosition(abejaC, abejaF);       // Ponemos el cursor en la posición actual de la abeja.   
                        Console.ForegroundColor = ConsoleColor.Red;      // Configurar el color del texto para el "#".
                        Console.Write("#");                              // Dibujamos un '#' en la posición del jugador.
                    }

                    // Si no hay ninguna bala en pantalla...
                    if (balaF != -1)
                    {
                        Console.SetCursorPosition(balaC, balaF);         // Ponemos el cursor en la posición actual de la abeja. 
                        Console.ForegroundColor = ConsoleColor.Magenta;  // Configurar el color del texto para el "o".
                        Console.Write("o");                              // Dibujamos un '#' en la posición del jugador.
                    }
                }
                #endregion

                #region RETARDO ENTRE FRAMES.

                System.Threading.Thread.Sleep(delta);
                #endregion
            }
            #endregion
        }
    }
}
