using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace OpenRasterCreator
{
    
    public class Layer:OpenRasterNode
    {
        public Bitmap Bitmap;
        public string LayerName;
        public NodeParametrs Parametrs=new NodeParametrs();

        public Layer(Bitmap bitmap, string layerName)
        {
            Bitmap = bitmap;
            LayerName = layerName;
        }

        public Layer(Bitmap bitmap, string layerName,Composite composite) :this (bitmap, layerName)
        {
            Parametrs.Composite = composite;
        }

        public Layer(Bitmap bitmap, string layerName, Visibility visibility) : this(bitmap, layerName)
        {
            Parametrs.Visibility = visibility;
        }

        public Layer(Bitmap bitmap, string layerName, double opasity) : this(bitmap, layerName)
        {
            Parametrs.Opasity = opasity;
        }

        public Layer(Bitmap bitmap, string layerName, Composite composite, Visibility visibility) : this(bitmap, layerName, composite)
        {
            Parametrs.Visibility = visibility;
        }

        public Layer(Bitmap bitmap, string layerName, Composite composite, Visibility visibility, double opasity) : this(bitmap, layerName, composite, visibility)
        {
            Parametrs.Opasity = opasity;
        }

        

        public int Id;

        public override XElement ToXml()
        {
            XElement xmlElement = new XElement("layer",
                new XAttribute("name", LayerName),
                new XAttribute("opacity", Parametrs.Opasity),
                new XAttribute("visibility", Parametrs.VisabilityDictionary[Parametrs.Visibility]),
                new XAttribute("composite-op", Parametrs.CompositeDictionary[Parametrs.Composite]),
                new XAttribute("src", $"data/layer{Id}.png"));
            return xmlElement;
        }

        public override List<OpenRasterNode> GetNodes()
        {
            return new List<OpenRasterNode>(){this};
        }
    }
}
