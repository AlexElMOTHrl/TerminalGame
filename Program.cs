using AlexLibs;
using System.Dynamic;
using System.Text;
using System.Threading;


namespace JuegoTerminal;
internal class Program
{

    private static void Main(string[] args)
    {
        // Var
    #region Variables
        
        var defaultConsoleColor = Console.BackgroundColor;
        var defaultConsoleTextColor = Console.ForegroundColor;

    #endregion
        // ExpandoObjects
    #region Items
        dynamic items = new ExpandoObject();
        items.DescribeItem = (Func<String>)(() =>
        { //! NO FUNCIONA, INTENTA CREAR UN EXPANDO PARA PEDIR LAS VARIABLES DEL OBJETO SELECCIONADO.
            return $"Id: {items}:\nNombre: {items.descItem.DisplayName}\nDescripción: {items.descItem.Description}\n";
        });
    
        items.caca = new ExpandoObject();
        items.caca.Id = 5;
        items.caca.DisplayName = "Caca";
        items.caca.CodeName = "caca";
        items.caca.Description = "Una mierda bien fresca lista para comer.";

        items.colacao = new ExpandoObject();
        items.colacao.Id = 4;
        items.colacao.DisplayName = "Colacao";
        items.colacao.CodeName = "colacao";
        items.colacao.Description = "Esto es un colacao, te lo puedes beber, ¿Tengo que explicarlo de verdad?";

        items.testitem = new ExpandoObject();
        items.testitem.Id = 999;
        items.testitem.DisplayName = "TEST ITEM";
        items.testitem.CodeName = "testitem";
        items.testitem.Description = "DEBUG - OBJETO DE PRUEBA - ¿FUNCIONO?";
    #endregion
        // Menus y parecidos.
    #region Menus
        
        string errorScreen = @$"
#################################################################################
#####                           ERROR SERIO                                ######
#################################################################################

ERROR => ";

        string opciones = @"Opciones:

    1) Ir           - Ve a otra localizacion adyacente.
    2) Coger        - Coge un objeto de la habitación.
    3) Mirar        - Mira los objetos a tu alrededor.
    4) Inventario   - Mira el contenido de tu inventario.
    5) Descripción  - Mira la descripcion de un objeto.

- Selección: ";

    #endregion
        //string itemDesc = @"Nombre: {describedItem}";

        // Fin de "Menus y parecidos".

        // Funciones

        void DebugERROR(string msg) //? Mensaje de error muy visible.
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(errorScreen + msg);
            Console.BackgroundColor = defaultConsoleColor;
        }

        void DebugPrint(string msg) //? Mensajes debug.
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("### DEBUG ### - " + msg + " - ### DEBUG ###");
            Console.BackgroundColor = defaultConsoleColor;
        }

        void KeyToContinue() //? Pulsas cualquier tecla para continuar.
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPulsa cualquier tecla para continuar...");
            Console.ForegroundColor = defaultConsoleTextColor;
            Console.ReadKey();
        }

        void Go()
        {
            DebugPrint("\"Go\" seleccionado...");
            KeyToContinue();
        }

        void Grab()
        {
            DebugPrint("\"Grab\" seleccionado...");
            KeyToContinue();
        }

        void Watch()
        {
            DebugPrint("\"Watch\" seleccionado...");
            KeyToContinue();
        }

        void Inv()
        {
            DebugPrint("\"Inv\" seleccionado...");
            KeyToContinue();
        }

        void ItemDesc()
        {
            Console.WriteLine("Item para recivir la informacion:");
            Console.WriteLine($"DEBUG:\nId: {items.colacao.Id}\nNombre: {items.colacao.DisplayName}\nDescripcion: {items.colacao.Description}\nDEBUG 2 --------\n{items.DescribeItem()}");
            int itemSelec = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.Write("DEBUG?"); // DEBUG DE CLASES
            KeyToContinue();
        }

        void AskAction()
        {
            while (true)
            {
                Console.Clear();
                Console.Write(opciones);
                string? action = Console.ReadLine();
                Console.Clear();
                switch (action?.ToLower())
                {
                    case "1":
                        Go();
                        break;

                    case "2":
                        Grab();
                        break;

                    case "3":
                        Watch();
                        break;

                    case "4":
                        Inv();
                        break;

                    case "5":
                        ItemDesc();
                        break;

                    default:
                        DebugERROR("Fuera de rango...");
                        KeyToContinue();
                        break;
                }
            }
        }

        // Fin de funciones.

        // Empieza el juego.

        AskAction();

    }
}