﻿using System;
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

        public LayerFolder(string folderName)
        {
            FolderName = folderName;
        }

        public LayerFolder(string folderName, params OpenRasterNode[] nodes)
        {
            FolderName = folderName;
            this.nodes = nodes.ToList();
        }

        public override XElement ToXml()
        {
            XElement xmlElement =new XElement("stack", 
                new XAttribute("isolation", "isolate"),
                new XAttribute("name", FolderName),
                new XAttribute("opacity", 1),
                new XAttribute("visibility", "visible"),
                new XAttribute("composite-op", "svg:src-over"),
                nodes.Select(n=>n.ToXml()));

            return xmlElement;
        }


        
    }
}
