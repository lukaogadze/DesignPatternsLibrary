using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Ink;

namespace Paint
{
    public class InkCanvasWithUndo : InkCanvas
    {
        public IMomento CreateMomento()
        {
            Stroke[] copy = Strokes.ToArray();
            return new InkCanvasMomento() { State = copy };
        }

        public void SetMomento(IMomento momento)
        {
            Strokes = new StrokeCollection((Stroke[])momento.State);
        }


        private class InkCanvasMomento : IMomento
        {
            public object State { get; set; }
        }
    }
}
