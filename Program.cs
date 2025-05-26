namespace sistema_gestion_nominas
{
    public class Program
    {
        private static List<Empleado> empleados = new List<Empleado>();

        static void Main(string[] args)
        {
            bool continuar = true;
            while (continuar)
            {
                Console.Clear();
                MostrarMenu();
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Clear();
                        CrearEmpleadoAsalariado();
                        break;
                    case "2":
                        Console.Clear();
                        CrearEmpleadoPorHoras();
                        break;
                    case "3":
                        Console.Clear();
                        CrearEmpleadoPorComision();
                        break;
                    case "4":
                        Console.Clear();
                        CrearEmpleadoAsalariadoPorComision();
                        break;
                    case "5":
                        Console.Clear();
                        ListarEmpleados();
                        break;
                    case "6":
                        Console.Clear();
                        EditarEmpleado();
                        break;
                    case "7":
                        Console.Clear();
                        continuar = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                        break;
                }
            }
        }

        static void MostrarMenu()
        {
          Console.Write(@$"
          ===========================================
               Sistema de Gestión de Nóminas 
          ===========================================

                1. Crear Empleado Asalariado
                2. Crear Empleado por Horas
                3. Crear Empleado por Comisión
                4. Crear Empleado Asalariado por Comisión
                5. Listar Empleados
                6. Editar Empleado
                7. Salir

          ===========================================
                   Seleccione una opción:            
          ");
        } 

        static void CrearEmpleadoAsalariado()
        {
            Console.WriteLine("\n=== Crear Empleado Asalariado ===");
            Console.Write("Número de Seguro Social: ");
            string nss = Console.ReadLine();
            Console.Write("Primer Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Apellido Paterno: ");
            string apellido = Console.ReadLine();
            Console.Write("Salario Semanal: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal salario))
            {
                var empleado = new Empleado_asalariado(nss, nombre, apellido, salario);
                empleados.Add(empleado);
                Console.WriteLine("Empleado asalariado creado exitosamente.");
            }
            else
            {
                Console.WriteLine("Error: El salario debe ser un número válido.");
            }
        }

        static void CrearEmpleadoPorHoras()
        {
            Console.WriteLine("\n=== Crear Empleado por Horas ===");
            Console.Write("Número de Seguro Social: ");
            string nss = Console.ReadLine();
            Console.Write("Primer Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Apellido Paterno: ");
            string apellido = Console.ReadLine();
            Console.Write("Sueldo por Hora: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal sueldoPorHora))
            {
                Console.Write("Horas Trabajadas: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal horasTrabajadas))
                {
                    var empleado = new EmpleadoPorHoras(nss, nombre, apellido, sueldoPorHora, horasTrabajadas);
                    empleados.Add(empleado);
                    Console.WriteLine("Empleado por horas creado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Error: Las horas trabajadas deben ser un número válido.");
                }
            }
            else
            {
                Console.WriteLine("Error: El sueldo por hora debe ser un número válido.");
            }
        }

        static void CrearEmpleadoPorComision()
        {
            Console.WriteLine("\n=== Crear Empleado por Comisión ===");
            Console.Write("Número de Seguro Social: ");
            string nss = Console.ReadLine();
            Console.Write("Primer Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Apellido Paterno: ");
            string apellido = Console.ReadLine();
            Console.Write("Ventas Frutas: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal ventasFrutas))
            {
                Console.Write("Tarifa Comisión: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal tarifaComision))
                {
                    var empleado = new EmpleadoPorComision(nss, nombre, apellido, ventasFrutas, tarifaComision);
                    empleados.Add(empleado);
                    Console.WriteLine("Empleado por comisión creado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Error: La tarifa de comisión debe ser un número válido.");
                }
            }
            else
            {
                Console.WriteLine("Error: Las ventas deben ser un número válido.");
            }
        }

        static void CrearEmpleadoAsalariadoPorComision()
        {
            Console.WriteLine("\n=== Crear Empleado Asalariado por Comisión ===");
            Console.Write("Número de Seguro Social: ");
            string nss = Console.ReadLine();
            Console.Write("Primer Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Apellido Paterno: ");
            string apellido = Console.ReadLine();
            Console.Write("Ventas Frutas: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal ventasFrutas))
            {
                Console.Write("Tarifa Comisión: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal tarifaComision))
                {
                    Console.Write("Salario Base: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal salarioBase))
                    {
                        var empleado = new EmpleadoAsalariadoPorComision(nss, nombre, apellido, ventasFrutas, tarifaComision, salarioBase);
                        empleados.Add(empleado);
                        Console.WriteLine("Empleado asalariado por comisión creado exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine("Error: El salario base debe ser un número válido.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: La tarifa de comisión debe ser un número válido.");
                }
            }
            else
            {
                Console.WriteLine("Error: Las ventas deben ser un número válido.");
            }
        }

        static void ListarEmpleados()
        {
            Console.WriteLine("\n=== Lista de Empleados ===");
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
                return;
            }

            for (int i = 0; i < empleados.Count; i++)
            {
                Console.WriteLine(
                $@"\nEmpleado #{i + 1}:
                {empleados[i].ToString()}
                ----------------------------------------");
            }
        }

        static void EditarEmpleado()
        {
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
                return;
            }

            ListarEmpleados();
            Console.Write("\nIngrese el número de Seguro Social del empleado a editar: ");
            string nss = Console.ReadLine();

            Empleado empleado = empleados.FirstOrDefault(e => e.NSS == nss);
            if (empleado == null)
            {
                Console.WriteLine("Empleado no encontrado.");
                return;
            }

            Console.WriteLine($"\nEditando empleado: {empleado.Nombre} {empleado.Apellido}");
            Console.Write("Nuevo Primer Nombre (presione Enter para mantener actual): ");
            string nuevoNombre = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nuevoNombre)) nuevoNombre = empleado.Nombre;

            Console.Write("Nuevo Apellido Paterno (presione Enter para mantener actual): ");
            string nuevoApellido = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nuevoApellido)) nuevoApellido = empleado.Apellido;

            if (empleado is Empleado_asalariado asalariado)
            {
                Console.Write("Nuevo Salario Semanal (presione Enter para mantener actual): ");
                string input = Console.ReadLine();
                decimal nuevoSalario = asalariado.SalarioSemanal;
                if (!string.IsNullOrWhiteSpace(input) && decimal.TryParse(input, out decimal salario))
                {
                    nuevoSalario = salario;
                }
                asalariado.ActualizarDatos(nuevoNombre, nuevoApellido, nuevoSalario);
            }
            else if (empleado is EmpleadoPorHoras porHoras)
            {
                Console.Write("Nuevo Sueldo por Hora (presione Enter para mantener actual): ");
                string inputSueldo = Console.ReadLine();
                decimal nuevoSueldoPorHora = porHoras.SueldoPorHora;
                if (!string.IsNullOrWhiteSpace(inputSueldo) && decimal.TryParse(inputSueldo, out decimal sueldo))
                {
                    nuevoSueldoPorHora = sueldo;
                }

                Console.Write("Nuevas Horas Trabajadas (presione Enter para mantener actual): ");
                string inputHoras = Console.ReadLine();
                decimal nuevasHoras = porHoras.HorasTrabajadas;
                if (!string.IsNullOrWhiteSpace(inputHoras) && decimal.TryParse(inputHoras, out decimal horas))
                {
                    nuevasHoras = horas;
                }
                porHoras.ActualizarDatos(nuevoNombre, nuevoApellido, nuevoSueldoPorHora, nuevasHoras);
            }
            else if (empleado is EmpleadoPorComision porComision)
            {
                Console.Write("Nuevas Ventas Frutas (presione Enter para mantener actual): ");
                string inputVentas = Console.ReadLine();
                decimal nuevasVentas = porComision.VentasFrutas;
                if (!string.IsNullOrWhiteSpace(inputVentas) && decimal.TryParse(inputVentas, out decimal ventas))
                {
                    nuevasVentas = ventas;
                }

                Console.Write("Nueva Tarifa Comisión (presione Enter para mantener actual): ");
                string inputTarifa = Console.ReadLine();
                decimal nuevaTarifa = porComision.TarifaComision;
                if (!string.IsNullOrWhiteSpace(inputTarifa) && decimal.TryParse(inputTarifa, out decimal tarifa))
                {
                    nuevaTarifa = tarifa;
                }
                porComision.ActualizarDatos(nuevoNombre, nuevoApellido, nuevasVentas, nuevaTarifa);
            }
            else if (empleado is EmpleadoAsalariadoPorComision asalariadoPorComision)
            {
                Console.Write("Nuevas Ventas Frutas (presione Enter para mantener actual): ");
                string inputVentas = Console.ReadLine();
                decimal nuevasVentas = asalariadoPorComision.VentasFrutas;
                if (!string.IsNullOrWhiteSpace(inputVentas) && decimal.TryParse(inputVentas, out decimal ventas))
                {
                    nuevasVentas = ventas;
                }

                Console.Write("Nueva Tarifa Comisión (presione Enter para mantener actual): ");
                string inputTarifa = Console.ReadLine();
                decimal nuevaTarifa = asalariadoPorComision.TarifaComision;
                if (!string.IsNullOrWhiteSpace(inputTarifa) && decimal.TryParse(inputTarifa, out decimal tarifa))
                {
                    nuevaTarifa = tarifa;
                }

                Console.Write("Nuevo Salario Base (presione Enter para mantener actual): ");
                string inputSalario = Console.ReadLine();
                decimal nuevoSalarioBase = asalariadoPorComision.SalarioBase;
                if (!string.IsNullOrWhiteSpace(inputSalario) && decimal.TryParse(inputSalario, out decimal salario))
                {
                    nuevoSalarioBase = salario;
                }
                asalariadoPorComision.ActualizarDatos(nuevoNombre, nuevoApellido, nuevasVentas, nuevaTarifa, nuevoSalarioBase);
            }

            Console.WriteLine("Empleado actualizado exitosamente.");
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}