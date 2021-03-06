using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using WpfMath.Rendering;
using WpfMath.Utils;

namespace WpfMath.Boxes
{
    /// <summary>
    /// Box representing a down diagonal line.
    /// </summary>
    internal class DownDiagonalRule:Box
    {
        public double LineThickness{get;}

        /// <summary>
        /// Initializes a new instance of the <see cref="HorizontalRule"/>.
        /// </summary>
        /// double lX,double lY,double rX,double rY,
        public DownDiagonalRule(TexEnvironment environment, double thickness,double width, double height, double shift)
        {
            LineThickness = thickness;
            this.Width = width;
            this.Height = height;
            this.Shift = shift;
            this.Foreground = environment.Foreground;
            this.Background = environment.Background;
        }

        public override void RenderTo(IElementRenderer renderer, double x, double y)
        {
            var color = Foreground ?? Brushes.Black;
            var pt1 = new Point(x,y-Height);
            var pt2 = new Point(x+Width,y);
            renderer.RenderLine(pt1,pt2,color);
        }

        public override int GetLastFontId()
        {
            return TexFontUtilities.NoFontId;
        }
    }
}
