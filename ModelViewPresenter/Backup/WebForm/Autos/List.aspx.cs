using System;
using System.Collections.Generic;
using System.Web.UI;
using MVP.Autos.List;

namespace PS.WebForm.Autos
{
    public partial class List : Page, IAutoListView
    {
        AutoListPresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            Guid manufacturerId = GetManufacturerId();
            presenter = new AutoListPresenter(this, manufacturerId);

            if(!IsPostBack)
                presenter.Init();
        }

        public void SetManufacturersName(string name)
        {
            manufacturerNameLabel.Text = name;
        }

        public void SetManufacturerId(Guid Id)
        {
            manufacturerIdHiddenField.Value = Id.ToString();
        }

        public void BindAutoList(IEnumerable<AutoListVM.AutoVM> autos)
        {
            autosRepeater.DataSource = autos;
            autosRepeater.DataBind();
        }

        Guid GetManufacturerId()
        {
            string id = Guid.Empty.ToString();

            if (!IsPostBack)
                id = Request.QueryString["m"];
            else
                id = manufacturerIdHiddenField.Value;

            return Guid.Parse(id);
        }

    }
}