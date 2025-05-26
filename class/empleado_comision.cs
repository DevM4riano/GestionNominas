
namespace sistema_gestion_nominas
{
    class EmpleadoPorComision : Empleado
    {
        public decimal ventasFrutas { get; set; }
        public decimal tarifaComision { get; set; }


        public EmpleadoPorComision(
            string numeroSeguroSocial,
            string primer_nombre,
            string apellido_paterno,
            decimal ventasFrutas,
            decimal tarifaComision)
        // heredando el constructor
        : base(numeroSeguroSocial, primer_nombre, apellido_paterno)
        {
            this.ventasFrutas = ventasFrutas;
            this.tarifaComision = tarifaComision;
        }



        public override decimal calcularPagoPorSemana()
        {
            return ventasFrutas * tarifaComision;
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
