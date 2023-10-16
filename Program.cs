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
            int jugF, jugC, // posición del jugador
            abejaF, abejaC, // posición de la abeja
            delta = 300; // retardo entre frames (ms)
            bool colision = false; // colisión entre abeja y jugador

            while (true)
            { // mientras no termine el juego
              // recogida de de input
                string s = "";
                while (Console.KeyAvailable) s = (Console.ReadKey(true)).KeyChar.ToString();

                // movimiento del jugador (en función del input)

                // movimiento aleatorio de la abeja

                // detección de colisión

                // renderizado de las entidades en consola

                // retardo entre frames
                System.Threading.Thread.Sleep(delta);
            }
        }   
    }
}    
