using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using Practica_1_abstract_factory;

namespace Practica_1_abstract_factory
{
    // Fabrica abstrata
    public abstract class MaterialFactory
    {
        public abstract Guia CrearGuia();
        public abstract Examen CrearExamen();
    }


    public abstract class Guia
    {
        public abstract void Mostrar();
    }

    public abstract class Examen
    {
        public abstract void Aplicar();
    }


    public class GuiaImpresa : Guia
    {
        public override void Mostrar()
        {
            Console.WriteLine("Mostrando la guia impresa");
        }
    }

    public class ExamenEnPapel : Examen
    {
        public override void Aplicar()
        {
            Console.WriteLine("Se aplica examen en papel");

        }

    }

    public class GuiaPDF : Guia
    {
        public override void Mostrar()
        {
            Console.WriteLine("Mostrando la guia en pdf");
        }
    }

    public class ExamenOnline : Examen
    {

        public override void Aplicar()
        {
            Console.WriteLine("Se aplica examen en linea");
        }
    }

   
    public class GuiaHibrida : Guia
    {
        public override void Mostrar()
        {
            Console.WriteLine("Mostrando la guia hibrida");
        }
    }

    public class ExamenHibrido : Examen
    {
        public override void Aplicar()
        {
            Console.WriteLine("Se aplica examen hibrido");
        }
    }


    public class MaterialImpresoFactory : MaterialFactory
    {
        public override Guia CrearGuia()
        {
            return new GuiaImpresa();
        }

        public override Examen CrearExamen()
        {
            return new ExamenEnPapel();
        }
    }

    public class MaterialDigitalFactory : MaterialFactory
    {
        public override Guia CrearGuia()
        {
            return new GuiaPDF();
        }

        public override Examen CrearExamen()
        {
            return new ExamenOnline();
        }
    }

    
    public class MaterialHibridoFactory : MaterialFactory
    {
        public override Guia CrearGuia()
        {
            return new GuiaHibrida();
        }

        public override Examen CrearExamen()
        {
            return new ExamenHibrido();
        }
    }


    //cliente

    internal class Program
 
    {
        static void Main(string[] args)
        {
            MaterialFactory fabrica;

            Console.WriteLine("1. Material Impreso");
            Console.WriteLine("2. Material Digital");
            Console.WriteLine("3. Material Hibrido"); 
            Console.Write("Seleccione una opción: ");

            int opcion = int.Parse(Console.ReadLine());

            if (opcion == 1)
                fabrica = new MaterialImpresoFactory();
            else if (opcion == 2)
                fabrica = new MaterialDigitalFactory();
            else
                fabrica = new MaterialHibridoFactory();

            Guia guia = fabrica.CrearGuia();
            Examen examen = fabrica.CrearExamen();

            guia.Mostrar();
            examen.Aplicar();

            Console.ReadKey();
        }
    }
}

