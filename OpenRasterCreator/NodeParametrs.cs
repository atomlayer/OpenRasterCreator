using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenRasterCreator
{
    public enum Visibility
    {
        Visible, Hidden
    }

    public enum Composite
    {
        Normal, Multiply, Screen, Overlay, Darken, Lighten, ColorDodge, ColorBurn, HardLight,
        SoftLight, Difference, Color, Luminosity, Hue, Saturation, Lighter, DestinationIn,
        DestinationOut, SourceAtop, DestinationAtop
    }

    public class NodeParametrs
    {
        public Dictionary<Visibility, string> VisabilityDictionary = new Dictionary<Visibility, string>
        {
            [Visibility.Visible] = "visible",
            [Visibility.Hidden] = "hidden",
        };

        public Dictionary<Composite, string> CompositeDictionary = new Dictionary<Composite, string>
        {
            [Composite.Normal] = "svg:src-over",
            [Composite.Multiply] = "svg:multiply",
            [Composite.Screen] = "svg:screen",
            [Composite.Overlay] = "svg:overlay",
            [Composite.Darken] = "svg:darken",
            [Composite.Lighten] = "svg:lighten",
            [Composite.ColorDodge] = "svg:color-dodge",
            [Composite.ColorBurn] = "svg:color-burn",
            [Composite.HardLight] = "svg:hard-light",
            [Composite.SoftLight] = "svg:soft-light",
            [Composite.Difference] = "svg:difference",
            [Composite.Color] = "svg:color",
            [Composite.Luminosity] = "svg:luminosity",
            [Composite.Hue] = "svg:hue",
            [Composite.Saturation] = "svg:saturation",
            [Composite.Lighter] = "svg:plus",
            [Composite.DestinationIn] = "svg:dst-in",
            [Composite.DestinationOut] = "svg:dst-out",
            [Composite.SourceAtop] = "svg:src-atop",
            [Composite.DestinationAtop] = "svg:dst-atop",
        };

        public Composite Composite = Composite.Normal;

        public Visibility Visibility = Visibility.Visible;

        private double _opasity = 1;

        public double Opasity
        {
            set
            {
                if (value > 1 || value < 0) throw new Exception("The value must be from zero to one");
                else _opasity = value;
            }
            get => _opasity;
        }

    }
}
