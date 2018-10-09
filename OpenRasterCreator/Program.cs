using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenRasterCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            Openraster openraster = new Openraster();

            var rendring = new LayerFolder("rendering");


            List<Bitmap> list = new List<Bitmap>();
            list.Add(new Bitmap("layer0.png"));
            list.Add(new Bitmap("layer1.png"));
            list.Add(new Bitmap("layer2.png"));


            Console.WriteLine("\nSave combime input layers");

            for (int i = 0; i < 2; i++)
            {
                var groupFolder = new LayerFolder("testGroup");

                
                    var lineFolder = new LayerFolder("line");
                    lineFolder.AddNodeToEndPosition(new Layer(list[2], "line"));
                    groupFolder.AddNodeToEndPosition(lineFolder);

              
                    groupFolder.AddNodeToEndPosition(new Layer(list[2], "shadow"));
                   
             
                    groupFolder.AddNodeToEndPosition(new Layer(list[2], "base"));
              
                
                rendring.AddNodeToEndPosition(groupFolder);

            }

            openraster.AddNodeToEndPosition(rendring);
            openraster.BuildFile();



            /*List<Bitmap> list =new List<Bitmap>();
            list.Add(new Bitmap("layer0.png"));
            list.Add(new Bitmap("layer1.png"));
            list.Add(new Bitmap("layer2.png"));

            Openraster openraster =new Openraster();

            openraster.AddNodeToEndPosition(new OpenRasterNode(list[0],"first"));

            var folder = new LayerFolder("FolderTest");
            folder.AddNodeToEndPosition(new OpenRasterNode(list[1], "second"));
            folder.AddNodeToEndPosition(new OpenRasterNode(list[2], "third"));

            openraster.AddNodeToEndPosition(folder);

            openraster.BuildFile();*/
        }
    }
}
