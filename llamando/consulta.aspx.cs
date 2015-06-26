using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Xml;

namespace llamando
{
    public partial class consulta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BindUserDetails();
        }

        private void BindUserDetails()
        {
            string UName = txtUserName.Text; //Textbox to read the values
            localhost.Service objService = new localhost.Service();
            //webservice aliase name with object
            DataSet ds = new DataSet();
            XmlElement elem = objService.GetUserDetails(UName);
            if (elem != null)
            {
                XmlNodeReader nodereader = new XmlNodeReader(elem);
                ds.ReadXml(nodereader, XmlReadMode.Auto);
                gvUserDetails.DataSource = ds;
                gvUserDetails.DataBind();
            }
            else
            {
                gvUserDetails.DataSource = null;
                gvUserDetails.DataBind();
            }
        }
    }
}