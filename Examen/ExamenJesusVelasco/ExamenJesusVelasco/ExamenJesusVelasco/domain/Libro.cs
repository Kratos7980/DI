using ExamenJesusVelasco.persistence.manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenJesusVelasco.domain
{
    public class Libro
    {
        LibroManage lm;
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Año { get; set; }
        public string Autor { get; set; }
        public int Genero { get; set; }
        public string GeneroString { get; set; }
        public Libro()
        {
            lm = new LibroManage();
        }
        public Libro(int id)
        {
            lm = new LibroManage();
            Id = id;
        }
        public Libro(int id, string titulo, string autor, int genero, int año)
        {
            lm = new LibroManage();
            Id = id;
            Titulo = titulo;
            Año = año;
            Autor = autor;
            Genero = genero;
        }

        public Libro(string titulo, int año, string autor, int genero)
        {
            lm = new LibroManage();
            Titulo = titulo;
            Año = año;
            Autor = autor;
            Genero = genero;
        }
        public List<Libro> leer()
        {
            return lm.selectAll();
        }
        public void insertar()
        {
            lm.insertar(this);
        }
        public void modificar()
        {
            lm.modificar(this);
        }
        public void borrar() { lm.borrar(this); }
        public override string ToString()
        {
            return Id + " " + Titulo;
        }
    }
}
