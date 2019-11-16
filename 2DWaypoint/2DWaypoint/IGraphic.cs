using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace _2DWaypoint
{
    class IGraphic : ISerializable
    {
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            
        }

        public virtual void Draw(Graphics g) { }
    }
}
