﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace OpenRasterCreator
{
    public abstract class OpenRasterNode
    {
        public abstract XElement ToXml();

        public abstract List<OpenRasterNode> GetNodes();

    }
}
