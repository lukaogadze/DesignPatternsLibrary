using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DomainModel;

namespace HouseInteriorApp
{
    public partial class TileDemo : Form
    {
        Random random =  new Random();

        public TileDemo()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {            
            base.OnPaint(e);

            for (int i = 0; i < 20; i++)
            {
                ITile ceramicTile = new CeramicTile(GetRandomNumber(), GetRandomNumber(), 
                    GetRandomNumber(), GetRandomNumber());
                ceramicTile.Draw(e.Graphics);
            }

            for (int i = 0; i < 20; i++)
            {
                ITile stoneTile = new StoneTile(GetRandomNumber(), GetRandomNumber(), 
                    GetRandomNumber(), GetRandomNumber());
                stoneTile.Draw(e.Graphics);
            }

            this.toolStripStatusLabel1.Text = "Total Objects Created : " + 
                Convert.ToString(CeramicTile.ObjectCounter + StoneTile.ObjectCounter);
        }

        private int GetRandomNumber()
        {
            return random.Next(100);
        }       
    }
}