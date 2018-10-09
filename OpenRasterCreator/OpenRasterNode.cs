using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace OpenRasterCreator
{
    abstract class OpenRasterNode
    {
        public abstract XElement ToXml();

        public abstract List<Layer> GetLayers();

    }
}
