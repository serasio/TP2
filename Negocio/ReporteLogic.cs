using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Data.Database;
using System.Data;
using System.Data.SqlClient;


namespace Negocio
{
    public class ReporteLogic : Negocio
    {
        private ReporteAdapter _ReporteDatos;

        public ReporteAdapter ReporteDatos
        {
            get { return _ReporteDatos; }
            set { _ReporteDatos = value; }
        }

        public ReporteLogic()
        {
            ReporteDatos = new ReporteAdapter();
        }

        public DataTable GetDatosAlumnos(int IDCurso)
        {
            return GetDatosAlumnos(IDCurso);
        }

    }
}
