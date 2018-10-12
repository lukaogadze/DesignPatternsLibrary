using System;
using System.Windows.Forms;
using DomainModel;

namespace HouseInteriorApp
{
    public partial class TileDemo : Form
    {
        private readonly Random _random =  new Random();

        public TileDemo()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {            
            base.OnPaint(e);

            for (int i = 0; i < 20; i++)
            {
                ITile ceramicTile = TileFactory.GetTile("Ceramic");
                ceramicTile.Draw(e.Graphics, GetRandomNumber(), 
                    GetRandomNumber(), GetRandomNumber(), GetRandomNumber());
            }

            for (int i = 0; i < 20; i++)
            {
                ITile stoneTile = TileFactory.GetTile("Stone");
                stoneTile.Draw(e.Graphics, GetRandomNumber(), 
                    GetRandomNumber(), GetRandomNumber(), GetRandomNumber());
            }

            toolStripStatusLabel1.Text = "Total Objects Created : " + 
                Convert.ToString(CeramicTile.ObjectCounter 
                + StoneTile.ObjectCounter);
        }

        private int GetRandomNumber()
        {
            return _random.Next(100);
        }       
    }
}