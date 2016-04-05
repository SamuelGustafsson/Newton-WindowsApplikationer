using System.Collections.Generic;
using System.Windows.Shapes;

namespace WPF_Assignment_1
{
  public class GridElementToCanvas
    {

      public string Name { get; set; }
      public double GridCenterX { get; set; }
      public double GridCenterY { get; set; }

        public List<Line> StartLine = new List<Line>(); 
        public List<Line> EndLine = new List<Line>(); 
    }
}
