using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace demoConversorTextoBinario
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                String archivoOriginal = @"C:\Users\datasoft-edgardo\Desktop\demo.txt";//Archivo original en formato texto
                String archivoBinario = @"C:\Users\datasoft-edgardo\Desktop\demo-binario.txt";//Archivo en formato texto binario
                String archivoOriginalDecodificado = @"C:\Users\datasoft-edgardo\Desktop\demo-binario-decodificado.txt";//Archivo original en formato texto obtenido del la conversion del archivo en formato texto binario

                //======================================================================
                //Codificando a Binario

                //Leo un archivo de texto
                byte[] fileToByteArray = File.ReadAllBytes(archivoOriginal);
                string miDatobinario = "";//Para depositar los datos de la lectura binaria

                //Recorro fileToByteArray y conbierto a binario cada elemento
                for (int i = 0; i < fileToByteArray.Length; i++)
                {
                    //Concateno a la variable que sera miDatobinario, ademas agrego un "espacio" en cada iteracion, para facilitar la comprencion
                    miDatobinario = miDatobinario + ToBinary(fileToByteArray[i]) + " ";
                }
                //Opcion con foreach
                //foreach (var item in fileToByteArray)
                //{
                //    miDatobinario += ToBinary(item) + " ";
                //}
                //Opcion con operacion Lambda
                //b.ToList().ForEach(n => miDatobinario += ToBinary(n) + " ");
                //Guardo la variable en un texto, elimino los espacios al principio y al final de la cadena
                File.WriteAllText(archivoBinario, miDatobinario.Trim());
                Console.WriteLine("En formato binario: \n" + miDatobinario);
                //Fin Codificando a Binario
                //======================================================================

                //======================================================================
                //======================================================================
                //======================================================================
                //======================================================================
                Console.WriteLine("===================================================");
                //======================================================================
                //======================================================================
                //======================================================================
                //======================================================================

                //======================================================================
                //DECODIFICANDO A TEXTO

                //Leo un archivo de texto binario
                String fileToString = File.ReadAllText(archivoBinario);
                //asigno la cadena a un array de string separandolo por 'espacio', esto es para recorrerlo y reinterpretar cada bloque de 8 caracteres binarios
                string[] ArrayCadenaBinaria = fileToString.Trim().Split(' ');


                //Creo el byteArray y lo instancio con el tamaño del "ArrayCadenaBinaria", este byteArray sera usado para reinterpretar a texto legible (no binario)
                byte[] textoClaro = new byte[ArrayCadenaBinaria.Length];

                //for (int i = 0; i < ArrayCadenaBinaria.Length; i++)
                //{
                //    //Recorro la cadena de string para poderlos procesar con los metodos de conversion
                //    int valor = ToInt(ArrayCadenaBinaria[i]);
                //    //Convierto el valor a un byte (0-255) y lo almacena en el byte[] con tamaño predefinido
                //    textoClaro[i] = Convert.ToByte(valor);
                //}

                //int posicion = 0;//Usado para mantener la posicion del byte[] texto claro
                //foreach (var item in ArrayCadenaBinaria)
                //{
                //    int valor = ToInt(item);
                //    textoClaro[posicion] = Convert.ToByte(valor);
                //    posicion += 1;
                //}
                
                //Opcion con operacion Lambda
                //ArrayCadenaBinaria
                //    .ToList()//Convierto a lista para poder usar select
                //    .Select((x, i) => new { dato = x , index = i })//con select obtengo el dato y el indice, y los asigno a una nueva instancia de objeto "dinamico", este tendra el dato y el indice
                //    .ToList()//Convierto a lista para poder usar ForEach
                //    .ForEach(x => textoClaro[x.index] = Convert.ToByte(ToInt(x.dato)));//Almaceno el dato en su indice correspondiente del byte array textoClaro



                //Guardo el datos decoficado en un archivo de texto, este metodo soporta la ruta del archivo a crear y un byte[] el cual sera escrito en el archivo
                File.WriteAllBytes(archivoOriginalDecodificado, textoClaro);

                //Decodifico en UTF-8 para poder mostrarlo en consola
                Console.WriteLine("En formato texto: \n" + System.Text.Encoding.UTF8.GetString(textoClaro));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Pequeña demo de conversion de decimales a binarios y binarios a decimales
        /// </summary>
        static void demoConversion()
        {
            int a = 1;
            int b = 10;
            int c = 100;
            int d = 250;

            string data1 = ToBinary(c);
            int data2 = ToInt(data1);

            Console.WriteLine("Binario: " + data1);
            Console.WriteLine("Decimal: " + data2);
        }

        /// <summary>
        /// Metodo que convierte de un entero a un binario
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private static String ToBinary(int n)
        {
            //Conversion a base 2 binaria
            string binario = Convert.ToString(n, 2);
            //Rellenar valores faltantes con 0
            string formateado = binario.PadLeft(8, '0');
            return formateado;
        }

        /// <summary>
        ///  Metodo que convierte de un binario a un text
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private static int ToInt(string n)
        {
            //Convierto el entereo en un numero decimal
            //Se debe entregar el numero como un string e indicar de que BASE numerica proviene.
            return Convert.ToInt32(n, 2);
        }
    }
}
