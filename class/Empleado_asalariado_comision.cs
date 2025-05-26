
namespace sistema_gestion_nominas
{
    public class EmpleadoAsalariadoPorComision : Empleado
    {
        public decimal ventasFrutas { get; set; }
        public decimal tarifaComision { get; set; }
        public decimal salarioBase { get; set; }


        // constructor

        public EmpleadoAsalariadoPorComision(
            string numeroSeguroSocial,
            string primer_nombre,
            string apellido_paterno,
            decimal ventasFrutas,
            decimal tarifaComision,
            decimal salarioBase)
            // heredando el constructor
            : base(numeroSeguroSocial, primer_nombre, apellido_paterno)
            {
                this.ventasFrutas = ventasFrutas;
                this.tarifaComision = tarifaComision;
                this.salarioBase = salarioBase;
            }


        public override decimal calcularPagoPorSemana()
        {
            return (ventasFrutas * tarifaComision) + (salarioBase + (salarioBase) * 0.10m);
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}