
namespace sistema_gestion_nominas
{
    public class Empleado_asalariado : Empleado
    {
        public decimal salario_semanal;


        public Empleado_asalariado(
            string numeroSeguroSocial,
            string primer_nombre,
            string apellido_paterno,
            decimal salario_semanal)
            // heredando el constructor
            : base(numeroSeguroSocial, primer_nombre, apellido_paterno)
            {
                this.salario_semanal = salario_semanal;
            }


        public override decimal calcularPagoPorSemana()
        {
            return salario_semanal;
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
