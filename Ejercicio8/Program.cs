using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static string archivo = "terminos.txt";

    static void Main()
    {
        if (!File.Exists(archivo))
        {
            Dictionary<string, string> terminos = ObtenerTerminosIniciales();
            GuardarTerminosEnArchivo(terminos);
        }

        Console.WriteLine("Términos actuales en el archivo:");
        MostrarTerminosDesdeArchivo();

        Console.WriteLine("\n¿Quieres añadir un nuevo término? (s/n)");
        string respuesta = Console.ReadLine().ToLower();

        while (respuesta == "s")
        {
            Console.Write("Escribe el término: ");
            string nuevoTermino = Console.ReadLine();

            Console.Write("Escribe la definición: ");
            string nuevaDefinicion = Console.ReadLine();

            AñadirTerminoAlArchivo(nuevoTermino, nuevaDefinicion);

            Console.WriteLine("\n¿Quieres añadir otro término? (s/n)");
            respuesta = Console.ReadLine().Trim().ToLower();
        }

        Console.WriteLine("\nContenido final del archivo:");
        MostrarTerminosDesdeArchivo();
    }

    static Dictionary<string, string> ObtenerTerminosIniciales()
    {
        return new Dictionary<string, string>
        {
            {"HTML", "Lenguaje de marcado utilizado para estructurar páginas web."},
            {"CSS", "Lenguaje para diseñar y dar estilo a páginas web."},
            {"JavaScript", "Lenguaje de programación que permite interactividad en sitios web."},
            {"Frontend", "Parte de una aplicación web que interactúa con el usuario."},
            {"Backend", "Parte del sistema que gestiona la lógica y el acceso a datos."},
            {"API", "Interfaz que permite que dos sistemas se comuniquen entre sí."},
            {"Base de datos", "Sistema que almacena y organiza datos de manera estructurada."},
            {"SQL", "Lenguaje utilizado para consultar y manipular bases de datos relacionales."},
            {"NoSQL", "Tipo de base de datos no relacional que permite almacenar datos de forma flexible."},
            {"Cloud Computing", "Uso de servidores remotos a través de internet para almacenar y procesar datos."},
            {"AWS", "Plataforma de servicios en la nube de Amazon."},
            {"Azure", "Plataforma de servicios en la nube de Microsoft."},
            {"DevOps", "Conjunto de prácticas que integran desarrollo y operaciones para mejorar el ciclo de vida del software."},
            {"Docker", "Herramienta para crear, desplegar y ejecutar aplicaciones en contenedores."},
            {"Virtualización", "Creación de versiones virtuales de sistemas operativos o servidores."},
            {"Git", "Sistema de control de versiones que permite gestionar cambios en el código fuente."},
            {"Repositorio", "Lugar donde se almacena y gestiona el código de un proyecto."},
            {"Framework", "Conjunto de herramientas y bibliotecas que facilita el desarrollo de software."},
            {"REST", "Estilo de arquitectura para diseñar servicios web utilizando métodos HTTP."},
            {"CDN", "Red de distribución de contenido que entrega recursos web desde servidores cercanos al usuario."}
        };
    }

    static void GuardarTerminosEnArchivo(Dictionary<string, string> terminos)
    {
        using (StreamWriter sw = new StreamWriter(archivo))
        {
            foreach (var termino in terminos)
            {
                sw.WriteLine($"{termino.Key}: {termino.Value}");
            }
        }
    }

    static void MostrarTerminosDesdeArchivo()
    {
        if (File.Exists(archivo))
        {
            string[] lineas = File.ReadAllLines(archivo);
            foreach (string linea in lineas)
            {
                Console.WriteLine(linea);
            }
        }
        else
        {
            Console.WriteLine("No hay archivo creado.");
        }
    }

    static void AñadirTerminoAlArchivo(string termino, string definicion)
    {
        using (StreamWriter sw = File.AppendText(archivo))
        {
            sw.WriteLine($"{termino}: {definicion}");
        }

        Console.WriteLine("Término añadido correctamente.");
    }
}
