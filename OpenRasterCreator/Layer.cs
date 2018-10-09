using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        public Layer(Bitmap bitmap, string layerName)
        {
            Bitmap = bitmap;
            LayerName = layerName;
        }

        public int Id;

        public override XElement ToXml()
        {
            XElement xmlElement = new XElement("layer",
                new XAttribute("name", LayerName),
                new XAttribute("opacity", 1),
                new XAttribute("visibility", "visible"),
                new XAttribute("composite-op", "svg:src-over"),
                new XAttribute("src", $"data/layer{Id}.png"));
            return xmlElement;
        }

        public override List<OpenRasterNode> GetNodes()
        {
            return new List<OpenRasterNode>(){this};
        }
    }
}
