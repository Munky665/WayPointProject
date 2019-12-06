using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace _2DWaypoint
{//abstract class.
    public interface IGraphic : ISerializable
    {
   
         void Draw(Graphics g);
    }
}
