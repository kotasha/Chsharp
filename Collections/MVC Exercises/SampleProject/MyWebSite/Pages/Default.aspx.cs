using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var product = this.Request.QueryString["Product"];

        var message = default(string);

        if (string.IsNullOrEmpty(product))
        {
            product = Page.RouteData.Values["Product"] as string;

            if (string.IsNullOrEmpty(product))
                message = "Invalid products";
            else
            {
                var random = new Random();
                message = string.Format("Total {0} product found for {1} [ROUTING]", random.Next(100), product);
            }
        }
        else
        {
            var random = new Random();
            message = string.Format("Total {0} product found for {1}", random.Next(100), product);
        }

        Response.Write(message);
    }
}