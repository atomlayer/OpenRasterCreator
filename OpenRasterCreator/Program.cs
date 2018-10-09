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
            List<Bitmap> list =new List<Bitmap>();
            list.Add(new Bitmap("layer0.png"));
            list.Add(new Bitmap("layer1.png"));
            list.Add(new Bitmap("layer2.png"));

            Openraster openraster =new Openraster();

            openraster.AddNodeToEndPosition(new Layer(list[0],"first"));

            var folder = new LayerFolder("FolderTest");
            folder.AddNodeToEndPosition(new Layer(list[1], "second"));
            folder.AddNodeToEndPosition(new Layer(list[2], "third"));

            openraster.AddNodeToEndPosition(folder);

            openraster.BuildFile();
        }
    }
}
