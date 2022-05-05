using ConsoleApp2.Models;
using DocumentFormat.OpenXml.Bibliography;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;




namespace ConsoleApp2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //static void Main(string[] args)
            Program muobject = new Program();

            //Ejemplo listo de HHTP POST
            string uid = "7A1A518F-1C2D-4110-8BD4-4440B9266BD7";
            string url = "https://canal1.xsa.com.mx:9050/bf2e1036-ba47-49a0-8cd9-e04b36d5afd4/cfdis/cancelar?";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            string json = "{\"motivo\":\"02\",\"uuid\":[\"" + uid + "\"]}";
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var httpResponse = await client.PostAsync(url, content);
            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();
                List<PostResponse> postResult2 = JsonConvert.DeserializeObject<List<PostResponse>>(result);

                foreach (var item in postResult2)
                {
                    Console.WriteLine("uuid: " + item.uuid + " - " + "Status: " + item.status + " - " + "Descripcion: " + item.descripcion);
                }
            }

            // FIN DE EJEMPLO HTTP POST



            //var data = new StringContent(JsonConvert.SerializeObject(new
            //{
            //    abc = "jsjs",
            //    xyz = "hhhh"
            //}));
            //data.Headers.ContentType = new MediaTypeHeaderValue("application/json"); // <-
            ////var response = client.PostAsync(url, data).Result;

            //Console.WriteLine(data);
            // Ejemplo de HTTP GET
            //string url = "https://jsonplaceholder.typicode.com/posts";
            //string url2 = "https://canal1.xsa.com.mx:9050/bf2e1036-ba47-49a0-8cd9-e04b36d5afd4/tiposCfds";
            //string url3 = "https://canal1.xsa.com.mx:9050/bf2e1036-ba47-49a0-8cd9-e04b36d5afd4/sucursales";
            //HttpClient client = new HttpClient();

            //var httpResponse = await client.GetAsync(url3);
            //if (httpResponse.IsSuccessStatusCode)
            //{
            //    var content = await httpResponse.Content.ReadAsStringAsync();
            //    List<Post> posts = 
            //        JsonConvert.DeserializeObject<List<Post>>(content);

            //    foreach (var item in posts)
            //    {
            //        Console.WriteLine("IdSucursal: " + item.idSucursal + "Nombre: " + item.NOMBRE + "Tipo sucursal: " + item.TIPOSUCURSAL);
            //    }
            //}


            // Fin de ejemplo de HTTP GET

            //// Ejemplo de HTTP POST
            //string url = "https://canal1.xsa.com.mx:9050/bf2e1036-ba47-49a0-8cd9-e04b36d5afd4/cfdis/cancelar?";
            //HttpClient client = new HttpClient();
            ////client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            //Post cerveza = new Post();
            //string miJson = JsonConvert.SerializeObject(cerveza);
            ////Escribir el json en un archivo externo
            //File.WriteAllText("objecto.txt", miJson);


            ////string data = "{ motivo:'02', uuid:['7A1A518F - 1C2D - 4110 - 8BD4 - 4440B9266BD7']}";
            ////data.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //string uid = "7A1A518F-1C2D-4110-8BD4-4440B9266BD7";
            ////string jsonp = "{\"motivo\":\"02\",\"uuid\":[\""+uid+"\"]}";
            ////Console.WriteLine(jsonp);
            //string url = "https://canal1.xsa.com.mx:9050/bf2e1036-ba47-49a0-8cd9-e04b36d5afd4/cfdis/cancelar?";
            //HttpClient client = new HttpClient();
            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //string json = "{\"motivo\":\"02\",\"uuid\":[\"" + uid + "\"]}";
            //HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            //var httpResponse = await client.PostAsync(url, content);
            ////var resulta = await httpResponse.Content.ReadAsStringAsync();
            ////List<Post> postResult = JsonConvert.DeserializeObject<List<Post>>(resulta);

            //if (httpResponse.IsSuccessStatusCode)
            //{
            //    var result = await httpResponse.Content.ReadAsStringAsync();
            //    List<PostResponse> postResult2 = JsonConvert.DeserializeObject<List<PostResponse>>(result);

            //    foreach (var item in postResult2)
            //    {
            //        Console.WriteLine("uuid: " + item.uuid +" - "+"Status: " + item.status +" - " + "Descripcion: " + item.descripcion);
            //    }
            //}
            // Fin de ejemplo de HTTP POST






            //Cerveza cerveza = new Cerveza(10, "Cerveza");

            //Con esto convierto un objeto en formato JSON
            //string miJson = JsonConvert.SerializeObject(cerveza);
            //Escribir el json en un archivo externo
            //File.WriteAllText("objecto.txt", miJson);

            //Ejemplo de extraer los datos de un archivo JSON
            //string miJson = File.ReadAllText("objecto.txt");
            //Cerveza cerveza1 = JsonConvert.DeserializeObject<Cerveza>(miJson);



            //var bebidaAlcoholica = new Vino(100);
            //MostrarRecomendacion(bebidaAlcoholica);

            // Creando listas 

            //List<int> lista = new List<int>() { 1,2,3,4,5,6,7,8};

            ////Par ingresar elementos a la lista
            //lista.Add(9);
            //lista.Add(0);
            //// Quitar elementos a la lista
            ////lista.Remove(1);

            //foreach (var item in lista)
            //{
            //    Console.WriteLine(item);
            //}

            //List<Cerveza> cervezas = new List<Cerveza>() { new Cerveza(10,"Cerveza premium")};
            //cervezas.Add(new Cerveza(500));
            //Cerveza modelo = new Cerveza(500, "Cerveza de trigo");
            //cervezas.Add(modelo);

            //foreach (var item in cervezas)
            //{
            //    Console.WriteLine("Cerveza: " + item.Nombre);
            //}






            //string[] file = Directory.GetFiles(@"C:\Archivos", "*.txt");
            //foreach (var item in file)
            //{
            //    Console.WriteLine(item);
            //}






            //Console.WriteLine(ultimo_archivo);


            //int cantidad = files.Length;
            //if (cantidad > 0 && cantidad < 2)
            //{

            //    var last = files.Last();
            //    string sourceFile = @"C:\Archivos\" + last;
            //    string destinationFile = @"C:\Archivos\Uploads\" + last;

            //    System.IO.File.Move(sourceFile, destinationFile);
            //    DirectoryInfo dis = new DirectoryInfo(@"C:\Archivos\Uploads");
            //    FileInfo[] filess = dis.GetFiles("*.txt");
            //    var lasts = filess.Last();
            //    Console.WriteLine("Copia existosa: " + lasts);
            //}
            //else
            //{
            //    Console.WriteLine("No hay archivos nuevos");
            //}

            //Console.WriteLine(cantidad);
            //System.IO.File.Move(files,);
            //foreach (FileInfo file in files)
            //{
            //    string archivo = file.Name + DateTime.Today; 
            //    Console.WriteLine(archivo);

            //    //if (file.Equals(last))
            //    //{

            //    //}
            //}





            //Bebidas bebida = new Bebidas("Coca cola", 1000);
            //bebida.Beberse(500);
            //Cerveza cerveza = new Cerveza();
            //cerveza.Beberse(10);
            //Console.WriteLine(cerveza.Cantidad);
            // Con esto creamos un arreglo de 10 valores
            //int[] numeros = new int[10] {1,2,3,4,5,6,7,8,9,0};

            // Con esto obtenemos el valor solicitado
            //int numero = numeros[1];
            //Console.WriteLine(numero);

            // Con esto recorro el arreglo y lo imprimo

            //for (int i = 0; i < numeros.Length; i++)
            //{
            //    Console.WriteLine(numeros[i]);
            //}

            //foreach (var item in numeros)
            //{
            //    Console.WriteLine(item);
            //}

            //// Con esto creamos una lista
            //List<int> lista = new List<int>();

            ////Con esto agregamos elementos a la lista
            //lista.Add(1);
            //lista.Add(2);

            //-----------------------------------------------------------------------------

            // Funcion para cargar archivos
            //muobject.extraer();

            //------------------------------------------------

        }

        //static void MostrarRecomendacion(IBebidaAlcoholica bebida)
        //{
        //    bebida.MaxRecomendado();
        //}

        //public void extraer()
        //{

        //    DirectoryInfo di = new DirectoryInfo(@"C:\Archivos");
        //    FileInfo[] files = di.GetFiles("*.txt");

        //    int cantidad = files.Length;
        //    if (cantidad > 0)
        //    {
        //        var ultimo_archivo = (from f in di.GetFiles()
        //                              orderby f.LastWriteTime descending
        //                              select f).First();



        //        string datestring = DateTime.Now.ToString("yyyyMMddHHmmss");
        //        string aname = datestring + "-" + ultimo_archivo.Name;
        //        string farchivo = ultimo_archivo + datestring;
        //        //Console.WriteLine("Copia existosa: " + farchivo);


        //        string sourceFile = @"C:\Archivos\" + ultimo_archivo;
        //        string destinationFile = @"C:\Archivos\Uploads\" + datestring + "-" + ultimo_archivo;
        //        System.IO.File.Move(sourceFile, destinationFile);
        //        DirectoryInfo dis = new DirectoryInfo(@"C:\Archivos\Uploads");
        //        FileInfo[] filess = dis.GetFiles("*.txt");
        //        var lasts = filess.Last();
        //        cargarEnSQL(aname);
        //        Console.WriteLine("Copia existosa: " + lasts);
        //    }
        //    else
        //    {
        //        Console.WriteLine("No hay más archivos");
        //    }


        //}
        //public int cargarEnSQL(string narchivo)
        //{
        //    string usuario = "jcherrera@bgcapitalgroup.mx";
        //    int resultado = 0;
        //    try
        //    {
        //        //NOS CONECTAMOS CON LA BASE DE DATOS
        //        string cadena = @"Data source=DESKTOP-CV57FOU\SQLEXPRESS; Initial Catalog=DBCARGA; User ID=jdev; Password=tdr123;Trusted_Connection=false;MultipleActiveResultSets=true";
        //        using (SqlConnection cn = new SqlConnection(cadena))
        //        {
        //            SqlCommand cmd = new SqlCommand("usp_xml", cn);
        //            //cmd.Parameters.AddWithValue("@nombre", nombre);
        //            cmd.Parameters.AddWithValue("@usuario", usuario);
        //            cmd.Parameters.AddWithValue("@narchivo", narchivo);

        //            cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;

        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cn.Open();
        //            cmd.ExecuteNonQuery();
        //            resultado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);

        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        string mensaje = ex.Message.ToString();
        //        resultado = 0;
        //    }

        //    return resultado;
        //}


    }
}
