using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]

public class Service : System.Web.Services.WebService
{
    public Service () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public XmlElement GetUserDetails(string userName)
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ToString());
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from padron  where Apellido like @userName+'%'", con);
        cmd.Parameters.AddWithValue("@userName", userName);
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        // Create an instance of DataSet.
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        // Return the DataSet as an XmlElement.
        XmlDataDocument xmldata = new XmlDataDocument(ds);
        XmlElement xmlElement = xmldata.DocumentElement;
        return xmlElement;
    }
    
}
