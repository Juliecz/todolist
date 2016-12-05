<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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
    <form id="form1" runat="server">
    <nav class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
          <p class="navbar-brand"><a href="Default.aspx">ToDo List</a></p>  
          <ul id="ulmenu" class="nav navbar-nav navbar-right">
            
              <li><asp:HyperLink runat="server" ID="Prihl"/></li>
              <li><asp:LinkButton runat="server" id="PrOdhl" OnClick="PrOdhl_Click"/></li>
       
          </ul>         
        </div>
        </nav>
    
    <div id="popis">
        
    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6" id="imageD"> <asp:Image runat="server" ImageUrl="~/images/check_on.png"/></div>
    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6" id="textD"><asp:Label runat="server"> Webova aplikace ToDo List slouzi pro organizace naplanovanych ukolu, <br />ktere je nutno udelat. ToDo List je mozne pouzivat po prihlaseni nebo registraci. <br />V teto aplikaci je mozne vytvaret kategorie a pridavat ukoly do vybrane kategorie. <br />Pokud ukol je splnen staci ho zaskrtnout a ukol se presune do splnenych. <br />Je mozne mazat ukoly v celem seznamu nebo v dane kategorie.</asp:Label></div>
    </div>
        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3"></div>
        <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4" id="btnD"><br /><asp:Hyperlink runat="server" Text="Pokracovat" type="button" class="btn btn-success btn-lg btn-block"  id="blockbtn"></asp:Hyperlink></div>
        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3"></div> 
    </form>
</body>
</html>
