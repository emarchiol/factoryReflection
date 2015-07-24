using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using System.Collections;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
namespace ConsoleApplication1
{
    class CollectionGenerator
    {

        string xmlCore;
        string ggeName;
        int ggeQuantity;

        public static List<IGenericGameElement> gges = new List<IGenericGameElement>();

        public void go()
        {
            GGEFactory factory = new GGEFactory();
            //Factory
            IGenericGameElement objetoGGE = factory.CreateInstance("GGECard");

            if (objetoGGE == null)
                return;

            ReadCoreXML("C:\\loveLetter\\");

            Console.ReadLine();
        }


        //METODOS
        public IGenericGameElement ReadSerialized(IGenericGameElement gge, string path, string type)
        {
            GGEFactory fac = new GGEFactory();
            //GGECard card = new GGECard();
            IGenericGameElement ggeUnknow;
            path = "C:\\loveLetter";
            string ggePath = path + "\\app\\" + this.ggeName + ".xml";

            //Reflection get type
            Type MyType = Type.GetType("ConsoleApplication1."+type);


            XmlSerializer serializer = new XmlSerializer(MyType);
            FileStream stream = new FileStream(ggePath, FileMode.Open);
            Console.WriteLine("Hurray gge XML cargado");


            try
            {
                ggeUnknow = serializer.Deserialize(stream) as IGenericGameElement;
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid XML");
                Console.WriteLine(e);
                ggeUnknow = fac.CreateInstance("GGECard");
            }
            finally { stream.Close(); }
            return ggeUnknow;
        }

        //Abrir el XML y leerlo
        public void ReadCoreXML(string path)
        {
            IGenericGameElement gge;
            string xmlValue;
            GGEFactory factory = new GGEFactory();
            //Ubico el archivo xml principal
            
            try
            {

                Console.WriteLine(path);
                if (File.Exists(path + "core.xml"))
                {
                    Console.WriteLine("Hurray archivo core.xml encontrado");
                    StreamReader sr = new StreamReader(path + "core.xml");
                    xmlCore = sr.ReadToEnd();
                }
                else {
                    Console.WriteLine("core no existe");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("File not found or corrupt.");
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
            //Reading game objects
            XmlReader reader = XmlReader.Create(new StringReader(xmlCore));

            //Game options

            //Collection elements
            int breaker = 0;
            try
            {
                reader.ReadToFollowing("Collection");
                do
                {
                    reader.MoveToFirstAttribute();
                    xmlValue = reader.Value.ToString();
                    Console.WriteLine("Atributo:" + reader.Value);
                    string ggeType = reader.Value;

                    //El xml me indicara cuantas copias de cada objeto hay (por ejemplo cartas iguales), con ese quantity genero x cantidad de GGE
                    if (xmlValue.CompareTo("GGEToken") ==0 || xmlValue.CompareTo("GGECard") == 0)
                    {
                        reader.MoveToNextAttribute();
                        ggeQuantity = Convert.ToInt16(reader.Value);
                        reader.MoveToNextAttribute();
                        ggeName = reader.Value;

                        for (int i = 0; i < ggeQuantity; i++)
                        {
                            gge = factory.CreateInstance(ggeType);
                            gge = ReadSerialized(gge, path, ggeType);
                            gges.Add(gge);
                            Console.WriteLine("recolectando objetos...");
                            Console.WriteLine("=====");
                            gge.printAtt();
                            Console.WriteLine("=====");
                        }
                    }
                    
                    breaker++;
                } while (reader.ReadToFollowing("Collection") && !reader.EOF);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong:" + e);
            }
            
        }
    }
}