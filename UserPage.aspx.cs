using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

public partial class UserPage : System.Web.UI.Page
{
    int k;
    protected void addToCheckboxList(string liText, int liV, bool liChecked, CheckBoxList CheckboxName)
    {
        ListItem li = new ListItem();
        if (liChecked == false)
            li.Selected = false;
        else li.Selected = true;
        li.Text = "&nbsp"+liText;
        li.Value = liV.ToString();
        CheckboxName.Items.Add(li);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        var idUser = userId();
        string del = Request.QueryString["del"];
        if (del!=null)
        {
            using (ListDbLinqDataContext db1 = new ListDbLinqDataContext())
            {
                var qUkol = from qU in db1.Texts
                            where idUser == qU.IdUser && qU.IdCategory == Convert.ToInt32(del)
                            select qU;
                foreach (var row in qUkol)
                {
                    db1.Texts.DeleteOnSubmit(row);
                    db1.SubmitChanges();
                }
                var q = from d in db1.Categories
                        where idUser == d.IdUser && d.IdCategory == Convert.ToInt32(del)
                        select d;
                foreach (var row in q)
                {
                    db1.Categories.DeleteOnSubmit(row);
                    db1.SubmitChanges();
                }
            }
            Response.Redirect("UserPage.aspx");
        }
        string par = Request.QueryString["category"];
        if (!IsPostBack)
        {
            Form.DefaultButton = addText.UniqueID; // Enter, novy ukol
            linkName.Text = Context.User.Identity.Name;
            CheckBoxList1.Items.Clear();
            using (ListDbLinqDataContext db = new ListDbLinqDataContext())
            {
                if (par == null)
                {
                    var query = from q in db.Texts
                                where q.IdUser == idUser && q.Completed == false
                                select q;

                    foreach (var checkbox in query)
                    {
                        addToCheckboxList(checkbox._Task.ToString(), checkbox.IdText, checkbox.Completed, CheckBoxList1);
                    }
                    var query2 = from q2 in db.Texts
                                 where q2.IdUser == idUser && q2.Completed == true
                                 select q2;

                    if (query2.Count() != 0)
                    {
                        smazSplnene.Visible = true;
                        //hrLine.Visible = false;
                        if (query.Count() != 0)
                        {
                            hrLine.Visible = true;
                        }
                    }
                    foreach (var checkbox in query2)
                    {
                        addToCheckboxList(checkbox._Task.ToString(), checkbox.IdText, checkbox.Completed, checkboxListCompleted);
                    }

                }

                if (par != null)
                {
                    var queryCateg = (from qC in db.Categories
                                     where qC.IdCategory == Convert.ToInt32(par)
                                     select qC).Single();
                    labelCategName.Text = queryCateg.CategoryName;
                    var query4 = from q4 in db.Texts
                                 where q4.IdUser == idUser && q4.IdCategory ==  Convert.ToInt32(par) && q4.Completed == false
                                 select q4;
                    foreach (var k in query4)
                    {
                        addToCheckboxList(k._Task.ToString(), k.IdText, k.Completed, CheckBoxList1);
                    }

                    var query5 = from q5 in db.Texts
                                 where q5.IdUser == idUser && q5.IdCategory == Convert.ToInt32(par) && q5.Completed == true
                                 select q5;
                    foreach (var k in query5)
                    {
                        addToCheckboxList(k._Task.ToString(), k.IdText, k.Completed, checkboxListCompleted);
                    }
                    if (query5.Count() != 0 )
                    {
                        smazSplnene.Visible = true;
                        if (query4.Count() != 0)
                        {
                            hrLine.Visible = true;
                        }
                    }
                }

                var query3 = from q3 in db.Categories
                            where q3.IdUser == idUser
                            select q3;
                foreach (var c in query3)
                {

                    /*HyperLink btn = new HyperLink();
                    btn.CssClass = "btn btn-default btn-sm";
                    btn.NavigateUrl = "UserPage.aspx?category=" + c.IdCategory;
                    btn.Text = c.CategoryName;
                    btnCat.Controls.Add(btn);
                    */
                    HtmlGenericControl newdiv = new HtmlGenericControl("div");
                    newdiv.ID = c.IdCategory.ToString();
                    newdiv.Attributes["class"] = "btn-group mezera";
                    newdiv.Attributes["role"] = "group";
                    HyperLink btn = new HyperLink();
                    btn.CssClass = "btn btn-default btn-sm";
                    btn.NavigateUrl = "UserPage.aspx?category=" + c.IdCategory;
                    btn.Text = c.CategoryName;
                    //newdiv.Controls.Add(btn, btn2);
                    HyperLink btn2 = new HyperLink();
                    //btn2.ID = c.IdCategory.ToString();
                    btn2.CssClass = "btn btn-default btn-sm";
                    btn2.NavigateUrl = "UserPage.aspx?del=" + c.IdCategory;
                    HtmlGenericControl span = new HtmlGenericControl("span");
                    span.Attributes["class"] = "glyphicon glyphicon-trash";
                    btn2.Controls.Add(span);
                    newdiv.Controls.Add(btn);
                    newdiv.Controls.Add(btn2);
                    btnCat.Controls.Add(newdiv);
                    btnCat.Controls.Add(new LiteralControl("<br />"));
                }
            }
        }

    }


    protected void button_Click(object sender)
    {
        Button b = (Button)sender;
        /*labelKontrola.Text = b.ID.ToString();*/
        Response.Redirect("UserPage.aspx?category=" + b.ID+ "&del=" + b.ID);

    }
    protected void linkOdhlas_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        FormsAuthentication.RedirectToLoginPage();
    }
    
    protected void addText_Click(object sender, EventArgs e)
    {
        string cat = Request.QueryString["category"];
        try
        {
            using (ListDbLinqDataContext db = new ListDbLinqDataContext())
            {
                if (novyUkol.Text != "")
                {
                    var idUser = userId();
                    Text todo = new Text();
                    todo.IdUser = idUser;
                    todo._Task = novyUkol.Text;
                    todo.Completed = false;
                    todo.Date = DateTime.Now; //.ToString("yyyy-MM-dd");
                    if (cat != null)
                    {
                        todo.IdCategory = Convert.ToInt32(cat);
                    }
                    db.Texts.InsertOnSubmit(todo);
                    db.SubmitChanges();
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }
                
            }
        }
        catch (Exception er)
        {
            labelKontrola.Text = er.ToString();
        }
    }

    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int value;
        foreach (ListItem li in CheckBoxList1.Items)
        {
            if (li.Selected == true)
            {
                value = Convert.ToInt32(li.Value);
                try
                {
                    using (ListDbLinqDataContext db = new ListDbLinqDataContext())
                    {
                        var query = from q in db.Texts
                                     where q.IdText == value
                                     select q;
                        
                        foreach (var checkbox in query)
                        {
                            checkbox.Completed = true;
                            db.SubmitChanges();
                        }
                        Page.Response.Redirect(Page.Request.Url.ToString(), true);
                    }
                }
                catch (Exception er)
                {
                    labelKontrola.Text += er.ToString();
                } 
            }
        }
    }

    protected int userId()
    {
        using (ListDbLinqDataContext db = new ListDbLinqDataContext())
        {
            var query = (from q in db.Users
                         where q.UserName == Context.User.Identity.Name
                         select q).Single();
            int idU = query.IdUser;
            return idU;
        }
    }
    protected void checkboxListCompleted_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (ListItem li in checkboxListCompleted.Items)
        {
            if (li.Selected == false)
            {
                try
                {
                    using (ListDbLinqDataContext db = new ListDbLinqDataContext())
                    {
                        var value = Convert.ToInt32(li.Value);
                        var query = from q in db.Texts
                                    where q.IdText == value
                                    select q;
                        foreach (var checkbox in query)
                        {
                            checkbox.Completed = false;
                            db.SubmitChanges();
                        }
                        Page.Response.Redirect(Page.Request.Url.ToString(), true);
                    }
                }
                catch (Exception er)
                {
                    labelKontrola.Text += er.ToString();
                }
            }
        }
    }
    protected void smazatVse_Click(object sender, EventArgs e)
    {
        string par = Request.QueryString["category"];
        var idUser = userId();
        if (par == null)
        {
            try
            {
                using (ListDbLinqDataContext db = new ListDbLinqDataContext())
                {
                    var query = from q in db.Texts
                                where q.IdUser == idUser
                                select q;
                    foreach (var rm in query)
                    {
                        db.Texts.DeleteOnSubmit(rm);
                        db.SubmitChanges();
                    }
                }
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            catch (Exception er)
            {
                labelKontrola.Text = er.ToString();
            }
        }
        else { 
            using (ListDbLinqDataContext db = new ListDbLinqDataContext())
            {
                var query = from q in db.Texts
                            where q.IdCategory == Convert.ToInt32(par) && q.IdUser == idUser
                            select q;
                //delete from db
                foreach (var row in query)
                {
                    db.Texts.DeleteOnSubmit(row);
                    db.SubmitChanges();
                }
            }
        }
        Page.Response.Redirect(Page.Request.Url.ToString(), true);
    }
    protected void SmazSplnene_Click(object sender, EventArgs e)
    {
        string par = Request.QueryString["category"];
        var idUser = userId();
        if (par == null)
        {
            try
            {
                using (ListDbLinqDataContext db = new ListDbLinqDataContext())
                {
                    //var idUser = userId();
                    var query = from q in db.Texts
                                where q.IdUser == idUser && q.Completed == true
                                select q;
                    foreach (var rm in query)
                    {
                        db.Texts.DeleteOnSubmit(rm);
                        db.SubmitChanges();
                    }
                    //smazSplnene.Visible = false;
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }
            }
            catch
            {

            }
        }
        else
        {
            using (ListDbLinqDataContext db = new ListDbLinqDataContext())
            {
                var query = from q in db.Texts
                            where q.IdCategory == Convert.ToInt32(par) && q.IdUser == idUser && q.Completed == true
                            select q;
                //delete from db
                foreach (var row in query)
                {
                    db.Texts.DeleteOnSubmit(row);
                    db.SubmitChanges();
                }
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
        }
    }
   
    protected void newCat_Click(object sender, EventArgs e)
    {
        //labelKontrola.Text = "btn";
        if (catName.Text != "")
        {
            try
            {
                using (ListDbLinqDataContext db = new ListDbLinqDataContext())
                {
                    Category cat = new Category();
                    cat.CategoryName = catName.Text;
                    var id = userId();
                    cat.IdUser = id;
                    db.Categories.InsertOnSubmit(cat);
                    db.SubmitChanges();
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }
            }
            catch { }
        }
        else Page.Response.Redirect(Page.Request.Url.ToString(), true);
    }
   
}

