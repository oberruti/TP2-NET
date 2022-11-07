using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Text.RegularExpressions;

namespace Business.Logic
{
    public class BusinessRules
    {
        //SELECT_CURSOS INSCRIBIRSE
        public static List<Curso> ValidarCursosAlumnos(List<Curso> listaCursos)
        {
            //Quita cursos en los que ya esta inscripto o es de una materia ya insripta
            if (listaCursos.Count != 0)
            {
                listaCursos = ValidarYaInsAlu(listaCursos);
            }
            //Quita cursos que ya no tengan cupos
            if (listaCursos.Count != 0)
            {
                listaCursos = ValidarCupo(listaCursos);
            }


            return listaCursos;
        }
        public static List<Curso> ValidarCupo(List<Curso> listaCursos)
        {
            //Consultar a la base todas las incripciones para este año
            for (int i = listaCursos.Count - 1; i >= 0; i--)
            {
                List<AlumnoInscripcion> inscCurso = new AlumnoInscripcionLogic().GetAllCurso(listaCursos[i].ID);
                if (inscCurso.Count >= listaCursos[i].Cupo)
                {
                    listaCursos.RemoveAt(i);
                }
            }
            return listaCursos;

            //sacar los cursos de listaCursos en los que los cupos > a count(inscripciones de ese curso)
            //foreach para cada curso foreach de insciociones contando para ese curso

        }
        public static List<Curso> ValidarYaInsAlu(List<Curso> listaCursos)
        {
            //Consultar a la base todos los cursos en los que el alumno ya se inscribio este año
            List<Curso> cursosInscripto = new CursoLogic().GetAllYearAlum(Session.currentUser.ID, Int32.Parse(DateTime.Now.ToString("yyyy")));
            foreach (var insAlu in cursosInscripto)
            {

                listaCursos.RemoveAll(item => item.ID == insAlu.ID || item.IDMateria == insAlu.IDMateria);
            }
            return listaCursos;
        }

        //INSCRIPCIONES_ALUMNOS_DESKTOP 
        public static bool ValidarCampos(string[] labels)//agarra todos los txt que le mandes y se fija si tienen texto
        {
            foreach (string labelPosicion in labels)
            {
                if (String.IsNullOrWhiteSpace(labelPosicion))
                {
                    return false;
                }
            }
            return true;
        }

        public static Boolean email_bien_escrito(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}
