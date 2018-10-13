using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MVP.Manufacturers.List;

namespace PS.WinForm
{
    public partial class Form1 : Form, IManufacturerListView
    {
        readonly ManufacturerListPresenter presenter;

        public Form1()
        {
            InitializeComponent();
            presenter = new ManufacturerListPresenter(this);
            presenter.Init();
        }

        public void Show(ManufacturerListVM viewModel)
        {
            titleLabel.Text = viewModel.Title;
            sortButton.Tag = viewModel.IsSorted;
            
            manufacturersListBox.DataSource = new List<ManufacturerListVM.ManufacturerVM>(viewModel.Manufacturers);
            manufacturersListBox.DisplayMember = "Name";
            manufacturersListBox.ValueMember = "Id";
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            presenter.Sort((bool)sortButton.Tag);
        }
    }
}
