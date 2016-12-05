<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

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
    <nav class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
          <p class="navbar-brand"><a href="Default.aspx">ToDo List</a></p>  
          <ul id="ulmenu" class="nav navbar-nav navbar-right">
            
            <li><a href="Default.aspx">Home</a></li>
            <li><a href="Login.aspx">Prihlaseni</a></li>
          </ul>         
        </div>
        </nav>
    <div class="row">
        <form id="prihlaseni" runat="server" class="form-horizontal">
            <div id="prvni" class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                <h3 class="nazev">Prihlaseni: </h3>
                <div class="form-group">
                    <label class="control-label col-sm-2" for="uzjmenoP">Uzivatelske jmeno:</label>
                    <div class="col-sm-6">
                        <asp:TextBox type="text" class="form-control" id="uzjmenoP" placeholder="Zadejte uzivatelske jmeno" runat="server"/>
                    </div>
                </div>
           
            <div class="form-group">
                <label class="control-label col-sm-2" for="hesloP" runat="server">Heslo:</label>
                <div class="col-sm-6"> 
                    <asp:TextBox TextMode="Password" class="form-control" id="hesloP" placeholder="Zadejte heslo" runat="server"/>
                </div>
            </div>

            <div class="form-group"> 
                <div class="col-sm-offset-2 col-sm-10">
                    <asp:Button type="submit" class="btn btn-success" Text="Prihlasit se" ID="prihl" runat="server" OnClick="prihl_Click" />
                </div> 
             </div>
                <asp:label ID="Label1" runat="server"></asp:label>
               
            </div>
            <div id="druhy" class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                <h3 class="nazev">Registrace: </h3>
                
                    <div class="form-group">
                            <label class="control-label col-sm-2" for="uzjmenoR">Uzivatelske jmeno:</label>
                        <div class="col-sm-6">
                            <asp:Textbox runat="server" type="text" class="form-control" id="uzjmenoR" placeholder="Zadejte uzivatelske jmeno" />
                            <asp:Label runat="server" ID="uzjmenoExistuje"></asp:Label>
                        </div>
                    </div>


                    <div class="form-group">
                            <label class="control-label col-sm-2" for="hesloR">Heslo:</label>
                        <div class="col-sm-6"> 
                            <asp:TextBox TextMode="Password" class="form-control" id="hesloR" placeholder="Zadejte heslo" runat="server"/>
                            <asp:Label runat="server" ID="potvrzeniH"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                            <label class="control-label col-sm-2" for="phesloR">Potvrzeni hesla:</label>
                        <div class="col-sm-6"> 
                            <asp:TextBox TextMode="Password" class="form-control" id="phesloR" placeholder="Zadejte heslo" runat="server"/>
                        </div>
                    </div>

                    <div class="form-group">
                            <label class="control-label col-sm-2" for="emailR">Email:</label>
                        <div class="col-sm-6">
                            <asp:TextBox type="email" class="form-control" id="emailR" placeholder="Zadejte email" runat="server"/>
                        </div>
                    </div>

                    <div class="form-group"> 
                        <div class="col-sm-offset-2 col-sm-10">
                            <asp:Button type="submit" class="btn btn-success" id="registr" runat="server" Text="Zaregistrovat se" OnClick="registr_Click"/>
               
                        </div>
                    </div>
                   
            </div>
        </form>
    </div>
</body>
</html>
