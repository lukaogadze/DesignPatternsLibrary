using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using MVP.Manufacturers.List;

namespace PS.WebForm
{
    public partial class _Default : Page, IManufacturerListView
    {
        private ManufacturerListPresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new ManufacturerListPresenter(this);

            if(!IsPostBack)
                presenter.Init();
        }

        public ManufacturerListVM ViewModel { get; private set; }

        public void Show(ManufacturerListVM viewModel)
        {
            ViewModel = viewModel;

            sortedHiddenField.Value = ViewModel.IsSorted.ToString();

            manufacturersRepeater.DataSource = ViewModel.Manufacturers;
            manufacturersRepeater.DataBind();
        }

        protected void Sort_Click(object sender, EventArgs eventArgs)
        {
            presenter.Sort(bool.Parse(sortedHiddenField.Value) );
        }
    }
}
