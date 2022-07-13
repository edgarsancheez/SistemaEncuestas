<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Inicio.aspx.vb" Inherits="EncuestaVirtualOficina.Inicio" %>
<%@ OutputCache Duration="30" VaryByParam="None" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />


    <style>
        h1, h2, h3, h4, h5 {
            font-family: 'Segoe UI';
        }

        body {
            background-image: url("Imagenes/Background/black.jpg" );
            background-position: center center;
            background-repeat: no-repeat;
            background-attachment: fixed;
            background-size: cover;
        }

        PanelCT {
            text-align: center;
        }

        .h1 {
            font-size: 26px;
        }

        .h2 {
            font-size: 16px;
        }
    </style>
    <title>Encuesta</title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <br />
        <div class="container">
            <div class="row">
                <div class="card border-dark text-center">
                    <div class="card-body">
                        <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-12 mb-3">
                                    <img src="https://www.lemancore.mx/wpv2/wp-content/uploads/lc-logo-horiz.png" class="img-fluid" alt="Responsive image" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                </div>
                                <div class="col-md-6">
                                    <telerik:RadLabel ID="lblTitulo" runat="server" Text="" Font-Size="Larger" Font-Bold="true" ForeColor="ControlDarkDark"></telerik:RadLabel>
                                </div>
                                <div class="col-md-3">
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-2">
                                </div>
                                <div class="col-md-8 text-start" id="psico1" runat="server">
                                    <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="11pt" Text=""></asp:Label><br /><br />
                                    <asp:Label ID="Label2" runat="server" Font-Names="Arial" Font-Size="11pt" Text=""></asp:Label>
                                    <asp:Label ID="Label3" runat="server" Font-Names="Arial" Font-Size="11pt" Text=""></asp:Label>
                                    <asp:Label ID="Label4" runat="server" Font-Names="Arial" Font-Size="11pt" Text=""></asp:Label>
                                    <asp:Label ID="Label5" runat="server" Font-Names="Arial" Font-Size="11pt" Text=""></asp:Label>
                                    <asp:Label ID="Label6" runat="server" Font-Names="Arial" Font-Size="11pt" Text=""></asp:Label>
                                    <asp:Label ID="Label7" runat="server" Font-Names="Arial" Font-Size="8pt" Text=""></asp:Label>
                                </div>
                                <div class="col-md-2">
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:Label ID="Lnota" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="11pt">Encuestas asignadas:</asp:Label>
                                    <br />
                                    <telerik:RadListBox ID="RadListBox1" runat="server" AutoPostBack="True" CssClass="leftAlign" Width="30%" Skin="Black">
                                        <ButtonSettings TransferButtons="All" />
                                    </telerik:RadListBox>
                                    <br />
                                    <br />
                                    <telerik:RadButton ID="BCerrar" runat="server" Text="Salir" Skin="Black" Width="10%">
                                    </telerik:RadButton>
                                    <br />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <asp:Label ID="Lerror" runat="server" Font-Size="10pt" Style="font-family: Arial; font-size: 10pt" ForeColor="Maroon"></asp:Label>
        </div>
        <div class="container section">
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            </telerik:RadAjaxManager>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <telerik:RadWindowManager RenderMode="Lightweight" ID="RadWindowManager1" runat="server" EnableShadow="true" Skin="Bootstrap" Modal="true" Animation="Fade">
            </telerik:RadWindowManager>
        </div>
    </form>
</body>

<script src="js/bootstrap.bundle.min.js"></script>
</html>

