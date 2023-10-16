// Paula Sierra Luque
// José Tomás Gómez Becerra

namespace PRACTICA1
{
    class MainClass
    {
        static Random rnd = new Random(); // generador de aleatorios (para mover abeja)
        const int ANCHO = 12,
          ALTO = 9; // dimensiones del área de juego

        public static void Main()
        {
            Console.SetWindowSize(ANCHO, ALTO); // tamaño de la consola
            int jugF, jugC,                     // posición del jugador
            abejaF, abejaC,                     // posición de la abeja
            delta = 300;                        // retardo entre frames (ms)
            bool colision = false;              // colisión entre abeja y jugador

            jugF = jugC = 0;                    //posicion inicial del player

            bool terminado = false;
            while (!terminado) //mientras no termine el juego
            {
                //recogida del input
                string s = "";
                while (Console.KeyAvailable) s = (Console.ReadKey(true)).KeyChar.ToString();

                //Movimiento del jugador en función del input
                if (s == "w" && jugF < ALTO)
                {
                    jugF--; //arriba
                }
                else if (s == "a" && jugC < ANCHO)
                {
                    jugC--; //izquierda
                }
                else if (s == "s" && jugF > ANCHO)
                {
                    jugF++; //abajo
                }
                else if (s == "d" && jugC < ANCHO)
                {
                    jugC++; //derecha
                }

                //Movimiento aleatorio de la abeja


                //Detección de la colisión


                //Renderizado de entidades en consola


                //Retardo entre frames
                System.Threading.Thread.Sleep(delta);
            }
        }   
    }
}    
