<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserPage.aspx.cs" Inherits="UserPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="//code.jquery.com/jquery-1.11.3.min.js"></script>
    <script src="//code.jquery.com/jquery-migrate-1.2.1.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap-theme.min.css" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
    <link type="text/css" href="style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" defaultbutton="addText">
     <nav class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
          <p class="navbar-brand"><asp:HyperLink NavigateUrl="Default.aspx" Text="ToDo List" runat="server"/></p>  
          <ul id="ulmenu" class="nav navbar-nav navbar-right">
            
            
            <li><asp:HyperLink ID="linkName" NavigateUrl="UserPage.aspx" runat="server" /></li>
            <li><asp:LinkButton ID="linkOdhlas" Text="Odhlaseni" runat="server" OnClick="linkOdhlas_Click" /></li>
           
          </ul>         
        </div>
        </nav>
    <div class="row">
        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3"  id="lists" runat="server">
            <asp:Label ID="labelKontrola" runat="server"></asp:Label> 
            <asp:Label runat="server" ID="myLabel"></asp:Label>
            <br /><br />
            <asp:TextBox runat="server" ID="catName" placeholder="Nova kategorie"></asp:TextBox>
            <asp:Button runat="server" ID="newCat" Text="Pridat kategorie" CssClass="btn btn-default btn-xs" OnClick="newCat_Click"/>
            
            <br /><br />
            
            <div runat="server" class="container" id="btnCat">
                <asp:HyperLink runat="server" NavigateUrl="~/UserPage.aspx" CssClass="btn btn-default btn-sm">Vsechny ukoly</asp:HyperLink> <br />
            </div>
        </div>
        <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9 form-group" id="formGroup"> 
            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                <asp:TextBox type="text" class="form-control" id="novyUkol" placeholder="Novy ukol" runat="server" />
                <br />
                <asp:Label runat="server" ID="labelCategName"></asp:Label>
                <asp:CheckBoxList ID="CheckBoxList1" AutoPostBack="true" runat="server" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged">
                                   
                </asp:CheckBoxList>
            <hr id="hrLine" runat="server" visible="false"/>
            <asp:CheckBoxList runat="server" AutoPostBack="true" ID="checkboxListCompleted" OnSelectedIndexChanged="checkboxListCompleted_SelectedIndexChanged">

            </asp:CheckBoxList>
            <asp:Button class="btn btn-default btn-xs" runat="server" OnClick="SmazSplnene_Click" Visible="false" Text="Smazat splnene ukoly" ID="smazSplnene"/>
            
            </div>
            <div class  ="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                <asp:Button type="submit" class="btn btn-success" Text="Novy ukol" ID="addText" runat="server" OnClick="addText_Click"/>
                <asp:Button type="submit" class="btn btn-danger" Text="Smazat vse" ID="smazatVse" runat="server" OnClick="smazatVse_Click"/>
           </div>
            
        </div>
    </div>

    </form>
</body>
</html>
