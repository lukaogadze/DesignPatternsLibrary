using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DomainModel
{
    public interface ITile
    {
        void Draw(Graphics g, int x, int y, int width, int height);
    }
}
