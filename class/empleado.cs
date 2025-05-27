namespace sistema_gestion_nominas
{
    public abstract class Empleado
    {
        public string numero_seguro_social { get; set; }
        public string primer_nombre { get; set; }
        public string apellido_paterno { get; set; }

        
        // constructor 
        public Empleado (string numeroSeguroSocial, string primer_nombre, string apellido_paterno) {
            this.primer_nombre = primer_nombre;
            this.numero_seguro_social = numeroSeguroSocial;
            this.apellido_paterno = apellido_paterno;
        }


        //metodos
        public abstract decimal calcularPagoPorSemana();

        public override string ToString(){
            return
            $@" primer nombre: {primer_nombre}
                apellido paterno: {apellido_paterno}
                pago semanal: {calcularPagoPorSemana():F2}
            ";
        }
    }
}