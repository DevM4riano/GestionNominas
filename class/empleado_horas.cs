
namespace sistema_gestion_nominas
{
    class EmpleadoPorHoras : Empleado
    {
        public decimal sueldoPorHora {get; set;}
        
        public decimal horasTrabajadas {get; set;}
        

        public EmpleadoPorHoras(
            string numeroSeguroSocial,
            string primer_nombre,
            string apellido_paterno,
            decimal sueldoPorHora,
            decimal horasTrabajadas
            )
            // heredando el constructor
            : base(numeroSeguroSocial, primer_nombre, apellido_paterno)
            {
                this.sueldoPorHora = sueldoPorHora;
                this.horasTrabajadas = horasTrabajadas;
            }


        public override decimal calcularPagoPorSemana()
        {
            if (horasTrabajadas <= 40)
            {
                return sueldoPorHora * horasTrabajadas;
            }
            else
            {
                return (sueldoPorHora * 40) + (sueldoPorHora * 1.5m * (horasTrabajadas - 40));
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}