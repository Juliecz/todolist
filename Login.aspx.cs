using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;
using System.Activities.Statements;
using System.Data.Linq;
using System.Configuration;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            Response.Redirect("UserPage.aspx");
        }
    }
    protected void prihl_Click(object sender, EventArgs e)
    {
        try
        {
            using (ListDbLinqDataContext db = new ListDbLinqDataContext())
            {
                string heslo;
                var userQuery = (from user in db.Users
                                  where user.UserName == uzjmenoP.Text
                                  select user).SingleOrDefault();
                if (userQuery == null)
                {
                    Label1.Text = " Zadejte spravne udaje";
                }
                else
                {
                    if(hesloP.Text != userQuery.Password)
                    {
                        Label1.Text = " Zadejte spravne udaje";
                    }
                    else
                    {
                        var username = uzjmenoP.Text;
                        FormsAuthentication.SetAuthCookie(username, createPersistentCookie);
                        Response.Redirect("UserPage.aspx");
                    }
                }
                
            }
        }
        catch (Exception er)
        {
            Label1.Text = er.ToString();
        }
    }

    protected void registr_Click(object sender, EventArgs e)
    {
        //registrace
       
        try
        {
            using (ListDbLinqDataContext db = new ListDbLinqDataContext())
            {
                var query = from q in db.Users
                                where q.UserName == uzjmenoR.Text
                                select q;
                    var count = query.Count();
                    if (count == 0)
                    {
                        if (hesloR.Text == phesloR.Text)
                        {
                            User user = new User();
                            user.UserName = uzjmenoR.Text;
                            user.Password = hesloR.Text;
                            user.Email = emailR.Text;
                            db.Users.InsertOnSubmit(user);
                            db.SubmitChanges();
                            var username = uzjmenoR.Text;
                            FormsAuthentication.SetAuthCookie(username, createPersistentCookie);
                            Response.Redirect("UserPage.aspx");
                        }
                        else
                        {
                            potvrzeniH.Text = "   Hesla se neschoduji"; //label
                        }
                    }
                    else
                    {
                        uzjmenoExistuje.Text = "Uzivatel s takovym jmenem uz existuje"; //???????????
                    }
            }
        }
        catch (Exception er)
        {
            Label1.Text = er.ToString();
        }
    }

    public bool createPersistentCookie { get; set; }
}