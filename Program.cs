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
                Console.WriteLine(@$"
    ========================================
    == Sistema de Gestión de Nóminas ==
    ========================================
    | 1. Crear empleado                    | 
    | 2. Listar empleados                  |
    | 3. Editar empleado                   |
    | 4. Salir                             |
    ========================================
                
            Elija una opción: ");

                string? opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        CrearEmpleado();
                        break;
                    case "2":
                        ListarEmpleados();
                        break;
                    case "3":
                        EditarEmpleado();
                        break;
                    case "4":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void CrearEmpleado()
        {
            Console.Clear();
            Console.WriteLine(@$"
    ========================================
            === Crear Empleado ===
    ========================================
    | 1. Empleado Asalariado               |
    | 2. Empleado por Horas                |
    | 3. Empleado por Comisión             |
    | 4. Empleado Asalariado por Comisión  |
    ========================================
    
        Seleccione tipo de empleado: ");
             

            string? tipo = Console.ReadLine();

            // Validar datos básicos
            Console.Write("NSS: ");
            string nss = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(nss))
            {
                Console.WriteLine("El NSS no puede estar vacío.");
                Console.ReadKey();
                return;
            }

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("El nombre no puede estar vacío.");
                Console.ReadKey();
                return;
            }

            Console.Write("Apellido: ");
            string apellido = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(apellido))
            {
                Console.WriteLine("El apellido no puede estar vacío.");
                Console.ReadKey();
                return;
            }

            switch (tipo)
            {
                case "1":
                    Console.Write("Salario semanal: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal salario))
                    {
                        empleados.Add(new Empleado_asalariado(nss, nombre, apellido, salario));
                        Console.WriteLine("Empleado asalariado creado con éxito.");
                    }
                    else
                    {
                        Console.WriteLine("Salario inválido.");
                    }
                    break;

                case "2":
                    Console.Write("Sueldo por hora: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal sueldoHora))
                    {
                        Console.Write("Horas trabajadas: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal horas))
                        {
                            empleados.Add(new EmpleadoPorHoras(nss, nombre, apellido, sueldoHora, horas));
                            Console.WriteLine("Empleado por horas creado con éxito.");
                        }
                        else
                        {
                            Console.WriteLine("Horas inválidas.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Sueldo inválido.");
                    }
                    break;

                case "3":
                    Console.Write("Ventas: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal ventas))
                    {
                        Console.Write("Tarifa comisión (ejemplo: 0.10 para 10%): ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal tarifa))
                        {
                            empleados.Add(new EmpleadoPorComision(nss, nombre, apellido, ventas, tarifa));
                            Console.WriteLine("Empleado por comisión creado con éxito.");
                        }
                        else
                        {
                            Console.WriteLine("Tarifa inválida.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ventas inválidas.");
                    }
                    break;

                case "4":
                    Console.Write("Ventas: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal ventasAC))
                    {
                        Console.Write("Tarifa comisión (ejemplo: 0.10 para 10%): ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal tarifaAC))
                        {
                            Console.Write("Salario base: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal salarioBase))
                            {
                                empleados.Add(new EmpleadoAsalariadoPorComision(nss, nombre, apellido, ventasAC, tarifaAC, salarioBase));
                                Console.WriteLine("Empleado asalariado por comisión creado con éxito.");
                            }
                            else
                            {
                                Console.WriteLine("Salario base inválido.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Tarifa inválida.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ventas inválidas.");
                    }
                    break;

                default:
                    Console.WriteLine("Tipo de empleado inválido.");
                    break;
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        static void ListarEmpleados()
        {
            Console.Clear();
            Console.WriteLine("=== Lista de Empleados ===\n");
            
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
            }
            else
            {
                for (int i = 0; i < empleados.Count; i++)
                {
                    var emp = empleados[i];
                    Console.WriteLine($"Empleado #{i + 1}");
                    Console.WriteLine($"NSS: {emp.numero_seguro_social}");
                    Console.WriteLine($"Nombre: {emp.primer_nombre} {emp.apellido_paterno}");
                    
                    if (emp is Empleado_asalariado asalariado)
                    {
                        Console.WriteLine("Tipo: Asalariado");
                        Console.WriteLine($"Salario semanal: ${asalariado.salario_semanal}");
                    }
                    else if (emp is EmpleadoPorHoras porHoras)
                    {
                        Console.WriteLine("Tipo: Por Horas");
                        Console.WriteLine($"Sueldo por hora: ${porHoras.sueldoPorHora}");
                        Console.WriteLine($"Horas trabajadas: {porHoras.horasTrabajadas}");
                    }
                    else if (emp is EmpleadoPorComision porComision)
                    {
                        Console.WriteLine("Tipo: Por Comisión");
                        Console.WriteLine($"Ventas: ${porComision.ventasFrutas}");
                        Console.WriteLine($"Tarifa comisión: {porComision.tarifaComision:P0}");
                    }
                    else if (emp is EmpleadoAsalariadoPorComision asalariadoComision)
                    {
                        Console.WriteLine("Tipo: Asalariado por Comisión");
                        Console.WriteLine($"Ventas: ${asalariadoComision.ventasFrutas}");
                        Console.WriteLine($"Tarifa comisión: {asalariadoComision.tarifaComision:P0}");
                        Console.WriteLine($"Salario base: ${asalariadoComision.salarioBase}");
                    }
                    Console.WriteLine($"Pago semanal calculado: ${emp.calcularPagoPorSemana():F2}");
                    Console.WriteLine("------------------------\n");
                }
            }
            
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        static void EditarEmpleado()
        {
            Console.Clear();
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("=== Editar Empleado ===\n");
            for (int i = 0; i < empleados.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {empleados[i].primer_nombre} {empleados[i].apellido_paterno} (NSS: {empleados[i].numero_seguro_social})");
            }
            
            Console.Write("\nSeleccione el número de empleado a editar: ");
            if (int.TryParse(Console.ReadLine(), out int indice) && indice >= 1 && indice <= empleados.Count)
            {
                var emp = empleados[indice - 1];

                if (emp is Empleado_asalariado asalariado)
                {
                    Console.Write($"Nuevo salario semanal (actual: ${asalariado.salario_semanal}): ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal salario))
                    {
                        asalariado.salario_semanal = salario;
                        Console.WriteLine("Salario actualizado.");
                    }
                    else
                    {
                        Console.WriteLine("Salario inválido.");
                    }
                }
                else if (emp is EmpleadoPorHoras porHoras)
                {
                    Console.Write($"Nuevo sueldo por hora (actual: ${porHoras.sueldoPorHora}): ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal sueldo))
                    {
                        porHoras.sueldoPorHora = sueldo;
                        Console.Write($"Nuevas horas trabajadas (actual: {porHoras.horasTrabajadas}): ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal horas))
                        {
                            porHoras.horasTrabajadas = horas;
                            Console.WriteLine("Datos actualizados.");
                        }
                        else
                        {
                            Console.WriteLine("Horas inválidas.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Sueldo inválido.");
                    }
                }
                else if (emp is EmpleadoPorComision porComision)
                {
                    Console.Write($"Nuevas ventas (actual: ${porComision.ventasFrutas}): ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal ventas))
                    {
                        porComision.ventasFrutas = ventas;
                        Console.Write($"Nueva tarifa comisión (actual: {porComision.tarifaComision:P0}): ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal tarifa))
                        {
                            porComision.tarifaComision = tarifa;
                            Console.WriteLine("Datos actualizados.");
                        }
                        else
                        {
                            Console.WriteLine("Tarifa inválida.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ventas inválidas.");
                    }
                }
                else if (emp is EmpleadoAsalariadoPorComision asalariadoComision)
                {
                    Console.Write($"Nuevas ventas (actual: ${asalariadoComision.ventasFrutas}): ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal ventas))
                    {
                        asalariadoComision.ventasFrutas = ventas;
                        Console.Write($"Nueva tarifa comisión (actual: {asalariadoComision.tarifaComision:P0}): ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal tarifa))
                        {
                            asalariadoComision.tarifaComision = tarifa;
                            Console.Write($"Nuevo salario base (actual: ${asalariadoComision.salarioBase}): ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal salarioBase))
                            {
                                asalariadoComision.salarioBase = salarioBase;
                                Console.WriteLine("Datos actualizados.");
                            }
                            else
                            {
                                Console.WriteLine("Salario base inválido.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Tarifa inválida.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ventas inválidas.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Selección no válida.");
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}