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

        public void AddNodeToEndPos(params OpenRasterNode[] openRasterNodes)
        {
            nodes.AddRange(openRasterNodes);
        }

        public void AddNodeToFirstPos(params OpenRasterNode[] openRasterNodes)
        {
            nodes = openRasterNodes.Concat(nodes).ToList();
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
