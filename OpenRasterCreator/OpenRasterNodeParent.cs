using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenRasterCreator
{
    abstract class OpenRasterNodeParent :OpenRasterNode
    {
        public List<OpenRasterNode> nodes = new List<OpenRasterNode>();

        public void AddNodeToEndPosition(OpenRasterNode openRasterNode)
        {
            nodes.Add(openRasterNode);
        }

        public void AddNodeToFirstPosition(OpenRasterNode openRasterNode)
        {
            nodes.Insert(0, openRasterNode);

        }
    }
}
