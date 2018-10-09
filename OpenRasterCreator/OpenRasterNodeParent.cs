using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenRasterCreator
{
    public abstract class OpenRasterNodeParent :OpenRasterNode
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

        public override List<OpenRasterNode> GetNodes()
        {
            var allNodes = new List<OpenRasterNode>();
            allNodes = nodes.SelectMany(n => n.GetNodes()).ToList();
            allNodes.AddRange(nodes);
            return allNodes;
        }
    }
}
