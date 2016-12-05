using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            Prihl.Text = User.Identity.Name;
            PrOdhl.Text = "Odhlaseni";
            Prihl.NavigateUrl = "UserPage.aspx";
            blockbtn.NavigateUrl = "UserPage.aspx";
        }
        else
        {
            Prihl.Text = "Home";
            Prihl.NavigateUrl = "Default.aspx";
            PrOdhl.Text = "Prihlaseni";
            blockbtn.NavigateUrl = "Login.aspx";
        }
    }
    protected void PrOdhl_Click(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
}