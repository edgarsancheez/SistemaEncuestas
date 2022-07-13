<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="S_EncuestaFin.aspx.vb" Inherits="EncuestaVirtualOficina.S_EncuestaFin" %>

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
            background-color: #464646;
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

    <title>Fin</title>
</head>

<body runat="server">
    <form id="form1" runat="server">
        <br />
        <br />
        <div class="container">
            <div class="row">
                <div class="card border-dark text-center">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-12">
                                <img src="https://www.lemancore.mx/wpv2/wp-content/uploads/lc-logo-horiz.png" class="img-fluid" alt="Responsive image"  />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12 mb-4">
                                <asp:Label ID="LTitulo" runat="server" Font-Bold="False" Font-Italic="False" Font-Names="Arial" Font-Size="20pt" ForeColor="Black" Style="font-family: Arial"></asp:Label>
                            </div>
                            <div class="col-md-12 mb-4">
                                <asp:Label ID="LInstruccion1" runat="server" Font-Names="Arial" Font-Size="11pt"></asp:Label>
                                <asp:Label ID="LInstruccion2" runat="server" Font-Names="Arial" Font-Size="11pt"></asp:Label>
                                <asp:Label ID="LInstruccion3" runat="server" Font-Names="Arial" Font-Size="11pt"></asp:Label>
                                <asp:Label ID="LInstruccion4" runat="server" Font-Names="Arial" Font-Size="11pt"></asp:Label>
                                <asp:Label ID="LInstruccion5" runat="server" Font-Names="Arial" Font-Size="11pt"></asp:Label>
                            </div>
                            <div class="col-md-12 mb-4">
                                <asp:Label ID="Lerror" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="10pt" ForeColor="Maroon"></asp:Label>
                                <telerik:RadButton ID="BCerrar" runat="server" Text="Salir" Skin="Bootstrap">
                                    <Icon PrimaryIconUrl="Imagenes/Iconos/logout.png" />
                                </telerik:RadButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div>
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
            <telerik:RadWindowManager ID="RadWindowManager1" runat="server" AutoSize="True" Skin="Bootstrap" VisibleStatusbar="False" VisibleTitlebar="False">
                <Windows>
                    <telerik:RadWindow ID="RadWindow1" runat="server">
                        <ContentTemplate>
                            <telerik:RadButton ID="RadButton1" runat="server" AutoPostBack="false" OnClientClicked="OnClientClicked"></telerik:RadButton>
                        </ContentTemplate>
                    </telerik:RadWindow>
                </Windows>
            </telerik:RadWindowManager>
        </div>
    </form>
</body>
<script type="text/javascript">
    function OnClientClicked(sender, args) {
        var window = $find('<%=RadWindow1.ClientID %>');
        window.close();
    }
</script>
</html>

