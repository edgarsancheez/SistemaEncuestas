<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Encuesta.aspx.vb" Inherits="EncuestaVirtualOficina.Encuesta" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet" />
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
<body id="PageBody" runat="server">
    <form id="form1" runat="server">
        <br />
        <br />
        <div class="container">
            <div class="row">
                <div class="card border-dark text-center">
                    <div class="card-body">
                        <div class="col-md-12 ">
                            <div class="row">
                                <div class="col-md-12">
                                    <img src="https://www.lemancore.mx/wpv2/wp-content/uploads/lc-logo-horiz.png"  class="img-fluid" alt="Responsive image" />
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-4 mb-3">
                                    <asp:Label ID="LCuestionario1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="14pt" Style="font-family: Arial" ForeColor="White"></asp:Label>
                                </div>
                                <div class="col-md-4 mb-3">
                                    <asp:Label ID="LFolio" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="10pt" Style="font-family: Arial" Visible="False"></asp:Label>
                                </div>
                                <div class="col-md-4 mb-3">
                                    <asp:Label ID="LCount" runat="server" Font-Size="10pt" Visible="False" Font-Names="Arial"></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12 mb-2">
                                    <asp:Label ID="LTexto" runat="server" Font-Size="12pt" Font-Names="Arial"></asp:Label>
                                </div>
                                <div class="col-md-12 mb-2">
                                    <telerik:RadTextBox runat="server" ID="txtNumero" Width="50%" Skin="Black"></telerik:RadTextBox>
                                </div>
                                <div class="col-md-12 mb-2">
                                    <button runat="server" id="Btn_Buscar" class="btn btn-dark">Siguiente</button>
                                </div>
                                <div class="col-md-12 mb-2">
                                    <asp:Label ID="Lerror" runat="server" Font-Size="10pt" Style="font-family: Arial; font-size: 10pt" ForeColor="Maroon"></asp:Label>
                                    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Behavior="Default" InitialBehavior="None" Left="" meta:resourcekey="RadWindowManager1Resource1" Skin="Default" Top="">
                                    </telerik:RadWindowManager>
                                    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
                                    <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Names="Arial" Font-Overline="False" Font-Size="11pt" ForeColor="#333333" Width="90%"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>

    </form>
</body>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js"></script>
</html>
