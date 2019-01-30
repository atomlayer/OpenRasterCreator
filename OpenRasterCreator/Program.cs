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
            /* //Test data
             List<Bitmap> list = new List<Bitmap>();
             list.Add(new Bitmap("img0.png"));
             list.Add(new Bitmap("img1.png"));
             list.Add(new Bitmap("img2.png"));

             var openRaster = new Openraster(
                                  new LayerFolder("testFolder",
                                      new Layer(list[1],"test1"),
                                      new Layer(list[2], "test2"),
                                      new LayerFolder("testFolder2",
                                          new Layer(list[0], "test1"))),
                                  new Layer(list[0], "test1")   
                                  );

             openRaster.Save(@"output.ora");*/

            //Test data
            List<Bitmap> list = new List<Bitmap>();
            list.Add(new Bitmap("img0.png"));
            list.Add(new Bitmap("img1.png"));
            list.Add(new Bitmap("img2.png"));

            var openRaster = new Openraster(
                new LayerFolder("testFolder",
                    new Layer(list[1], "test1",Composite.Multiply,Visibility.Visible,0.6),
                    new Layer(list[2], "test2"),
                    new LayerFolder("testFolder2",Composite.Multiply,
                        new Layer(list[0], "test1"))),
                new Layer(list[0], "test1")
            );

            openRaster.Save(@"output.ora");

            /*for (int i = 0; i < 2; i++)
            {
                var groupFolder = new LayerFolder("testGroup");

                
                    var lineFolder = new LayerFolder("line");
                    lineFolder.AddNodeToEndPos(new Layer(list[2], "line"));
                    groupFolder.AddNodeToEndPos(lineFolder);

              
                    groupFolder.AddNodeToEndPos(new Layer(list[2], "shadow"));
                   
             
                    groupFolder.AddNodeToEndPos(new Layer(list[2], "base"));
              
                
                rendring.AddNodeToEndPos(groupFolder);

            }

            openraster.AddNodeToEndPos(rendring);
            openraster.BuildFile();



            /*List<Bitmap> list =new List<Bitmap>();
            list.Add(new Bitmap("layer0.png"));
            list.Add(new Bitmap("layer1.png"));
            list.Add(new Bitmap("layer2.png"));

            Openraster openraster =new Openraster();

            openraster.AddNodeToEndPos(new OpenRasterNode(list[0],"first"));

            var folder = new LayerFolder("FolderTest");
            folder.AddNodeToEndPos(new OpenRasterNode(list[1], "second"));
            folder.AddNodeToEndPos(new OpenRasterNode(list[2], "third"));

            openraster.AddNodeToEndPos(folder);

            openraster.BuildFile();*/
        }
    }
}
