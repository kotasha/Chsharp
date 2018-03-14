using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstWebApplication
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnClick_Click(object sender, EventArgs e)
        {
            try
            {
                FirstServiceReference.FirstServiceClient objClient = new FirstServiceReference.FirstServiceClient();
                lblClick.Text = objClient.Increment().ToString();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
