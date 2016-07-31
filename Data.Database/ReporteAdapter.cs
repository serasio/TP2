using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;


namespace Data.Database
{
    public class ReporteAdapter : Adapter
    {

        public DataTable GetDatosAlumnos(int IDCurso)
        {
            DataTable dtDatosAlumno = new DataTable("DatosAlumnos");
            dtDatosAlumno.Columns.Add("id_persona", typeof(int));
            dtDatosAlumno.Columns.Add("nombre", typeof(string));
            dtDatosAlumno.Columns.Add("apellido", typeof(string));
            List<Persona> datosAlu = new List<Persona>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdReportes = new SqlCommand("select id_persona, nombre, apellido from personas "+
                  "inner join alumnos_inscripcion on alumnos_inscripcion.id_alumno = personas.id_persona "+
                  "where alumnos_inscripcion.id_curso = @id_curso", SqlConn);

                cmdReportes.Parameters.Add("@id_curso", SqlDbType.Int).Value = IDCurso;
                SqlDataReader drReportes = cmdReportes.ExecuteReader();

                while (drReportes.Read())
                {
                    Persona alu = new Persona();
                    alu.ID = (int)drReportes["id_persona"];
                    alu.Nombre = (string)drReportes["nombre"];
                    alu.Apellido = (string)drReportes["apellido"];
                    datosAlu.Add(alu);
                }

                foreach (Persona per in datosAlu)
                {
                    DataRow rowid = dtDatosAlumno.NewRow();
                    rowid["id_persona"] = per.ID;
                    dtDatosAlumno.Rows.Add(rowid);
                    DataRow rownom = dtDatosAlumno.NewRow();
                    rownom["nombre"] = per.Nombre;
                    dtDatosAlumno.Rows.Add(rownom);
                    DataRow rowape = dtDatosAlumno.NewRow();
                    rowape["apellido"] = per.Apellido;
                    dtDatosAlumno.Rows.Add(rowape);
                }

                drReportes.Close();
                /*SqlDataAdapter sqladap = new SqlDataAdapter("Select id_persona, nombre, apellido from personas "+
                    "inner join alumnos_inscripciones on personas.id_persona = alumnos_inscripciones.id_alumno ", SqlConn);
                sqladap.FillSchema(dsDatosAlumno, SchemaType.Source, "personas");
                sqladap.Fill(dsDatosAlumno,"personas");*/
            }
            catch(Exception ex)
            {
                Exception e = new Exception("Error al recuperar datos para reporte", ex);
                throw e;
            }
            finally
            {
                this.CloseConnection();
            }

            return dtDatosAlumno;
        }

    }
}
