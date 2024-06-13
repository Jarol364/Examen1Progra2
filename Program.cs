using System;

namespace Examen1Progra2
{
    class Cliente
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }

        public Cliente(string nombre, string direccion, string telefono, string correoElectronico)
        {
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            CorreoElectronico = correoElectronico;
        }
        public void MostrarInformacion()
        {
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Dirección: {Direccion}");
            Console.WriteLine($"Teléfono: {Telefono}");
            Console.WriteLine($"Correo Electrónico: {CorreoElectronico}\n");
        }
    }

    class Program
    {
        static Cliente[] clientes = new Cliente[10];
        static int clienteCount = 0;

        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Console.WriteLine("Sistema de Gestión de Clientes");
                Console.WriteLine("1. Registrar Cliente");
                Console.WriteLine("2. Mostrar Clientes");
                Console.WriteLine("3. Modificar Cliente");
                Console.WriteLine("4. Borrar Cliente");
                Console.WriteLine("5. Consultar Cliente");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");
                while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 6)
                {
                    Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                    Console.Write("Seleccione una opción: ");
                }
                switch (opcion)
                {
                    case 1:
                        RegistrarCliente();
                        break;
                    case 2:
                        MostrarClientes();
                        break;
                    case 3:
                        ModificarCliente();
                        break;
                    case 4:
                        BorrarCliente();
                        break;
                    case 5:
                        ConsultarCliente();
                        break;
                    case 6:
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                }

            } while (opcion != 6);
        }

        static void RegistrarCliente()
        {
            if (clienteCount >= 10)
            {
                Console.WriteLine("No se pueden registrar más clientes.\n");
                return;
            }

            Console.Write("Ingrese nombre del cliente: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese dirección del cliente: ");
            string direccion = Console.ReadLine();

            Console.Write("Ingrese teléfono del cliente: ");
            string telefono = Console.ReadLine();

            Console.Write("Ingrese correo electrónico del cliente: ");
            string correoElectronico = Console.ReadLine();

            Cliente nuevoCliente = new Cliente(nombre, direccion, telefono, correoElectronico);
            clientes[clienteCount] = nuevoCliente;
            clienteCount++;

            Console.WriteLine("Cliente registrado con éxito.\n");
        }

        static void MostrarClientes()
        {
            if (clienteCount == 0)
            {
                Console.WriteLine("No hay clientes registrados.\n");
            }
            else
            {
                for (int i = 0; i < clienteCount; i++)
                {
                    Console.WriteLine($"Cliente {i + 1}:");
                    clientes[i].MostrarInformacion();
                }
            }
        }

        static void ModificarCliente()
        {
            if (clienteCount == 0)
            {
                Console.WriteLine("No hay clientes registrados.\n");
                return;
            }

            Console.Write("Ingrese el número de teléfono del cliente a modificar: ");
            string telefono = Console.ReadLine();

            int indice = -1;
            for (int i = 0; i < clienteCount; i++)
            {
                if (clientes[i].Telefono == telefono)
                {
                    indice = i;
                    break;
                }
            }

            if (indice != -1)
            {
                Console.Write("Ingrese nuevo nombre del cliente: ");
                clientes[indice].Nombre = Console.ReadLine();

                Console.Write("Ingrese nueva dirección del cliente: ");
                clientes[indice].Direccion = Console.ReadLine();

                Console.Write("Ingrese nuevo teléfono del cliente: ");
                clientes[indice].Telefono = Console.ReadLine();

                Console.Write("Ingrese nuevo correo electrónico del cliente: ");
                clientes[indice].CorreoElectronico = Console.ReadLine();

                Console.WriteLine("Cliente modificado con éxito.\n");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.\n");
            }
        }

        static void BorrarCliente()
        {
            if (clienteCount == 0)
            {
                Console.WriteLine("No hay clientes registrados.\n");
                return;
            }

            Console.Write("Ingrese el número de teléfono del cliente a borrar: ");
            string telefono = Console.ReadLine();

            int indice = -1;
            for (int i = 0; i < clienteCount; i++)
            {
                if (clientes[i].Telefono == telefono)
                {
                    indice = i;
                    break;
                }
            }

            if (indice != -1)
            {
                for (int i = indice; i < clienteCount - 1; i++)
                {
                    clientes[i] = clientes[i + 1];
                }

                clientes[clienteCount - 1] = null;
                clienteCount--;

                Console.WriteLine("Cliente borrado con éxito.\n");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.\n");
            }
        }

        static void ConsultarCliente()
        {
            if (clienteCount == 0)
            {
                Console.WriteLine("No hay clientes registrados.\n");
                return;
            }

            Console.Write("Ingrese el número de teléfono del cliente a consultar: ");
            string telefono = Console.ReadLine();

            int indice = -1;
            for (int i = 0; i < clienteCount; i++)
            {
                if (clientes[i].Telefono == telefono)
                {
                    indice = i;
                    break;
                }
            }

            if (indice != -1)
            {
                clientes[indice].MostrarInformacion();
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.\n");
            }
        }
    }
}

