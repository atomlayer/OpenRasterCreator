using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.IO.Compression;

namespace OpenRasterCreator
{
    public class LayerFolder:OpenRasterNodeParent
    {
        public string FolderName;
        public NodeParametrs Parametrs=new NodeParametrs();

        public LayerFolder(string folderName)
        {
            FolderName = folderName;
        }

        public LayerFolder(string folderName, params OpenRasterNode[] nodes)
        {
            FolderName = folderName;
            this.nodes = nodes.ToList();
        }

        public LayerFolder(string folderName, Composite composite, params OpenRasterNode[] nodes) : this(folderName, nodes)
        {
            Parametrs.Composite = composite;
        }

        public LayerFolder(string folderName, Visibility visibility, params OpenRasterNode[] nodes) : this(folderName, nodes)
        {
            Parametrs.Visibility = visibility;
        }

        public LayerFolder(string folderName, double opasity, params OpenRasterNode[] nodes) : this(folderName, nodes)
        {
            Parametrs.Opasity = opasity;
        }

        public LayerFolder(string folderName,  Composite composite, Visibility visibility, params OpenRasterNode[] nodes) 
            : this(folderName, composite, nodes)
        {
            Parametrs.Visibility = visibility;
        }

        public LayerFolder(string folderName, Composite composite, Visibility visibility, double opasity, params OpenRasterNode[] nodes) 
            : this(folderName, composite, visibility, nodes)
        {
            Parametrs.Opasity = opasity;
        }


        public override XElement ToXml()
        {
            XElement xmlElement =new XElement("stack", 
                new XAttribute("isolation", "isolate"),
                new XAttribute("name", FolderName),
                new XAttribute("opacity", Parametrs.Opasity),
                new XAttribute("visibility", Parametrs.VisabilityDictionary[Parametrs.Visibility]),
                new XAttribute("composite-op", Parametrs.CompositeDictionary[Parametrs.Composite]),
                nodes.Select(n=>n.ToXml()));

            return xmlElement;
        }


        
    }
}
