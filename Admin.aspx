<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Admin.aspx.vb" Inherits="EncuestaVirtualOficina.Admin" %>

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

    <title>Administración</title>
</head>

<body class="mb-3" runat="server">
    <form id="form1" class="mb-3" runat="server">
        <div class="container mb-3" id="card12">
            <div class="row">
                <div class="col-md-12">
                    <div class="card border-dark text-center">
                        <div class="card-body">
                            <div class="row"> 
                                <div class="col-md-12 mb-3">
                                    <h3 runat="server" id="textEstudio_1"></h3>
                                </div>
                                <div class="col-md-4 mb-3">
                                    <label>Seleccionar Estudio</label>
                                    <telerik:RadComboBox runat="server" ID="RcbEstudio" Width="100%"></telerik:RadComboBox>
                                </div>
                                <div class="col-md-4">
                                    <label>Seleccionar Encuesta</label>
                                    <telerik:RadComboBox runat="server" ID="RcbEncuesta" Width="100%"></telerik:RadComboBox>
                                </div>
                                <div class="col-md-4">
                                    <telerik:RadButton id="Btn_Crear" Text="Crear Link" runat="server"></telerik:RadButton>
                                    <telerik:RadTextBox runat="server" ID="Textbox1"></telerik:RadTextBox>
                                </div>
                                <div class="col-md-12 mb-4">
                                    <label>Link</label>
                                    <telerik:RadLabel runat="server" ID="textlink"></telerik:RadLabel>
                                </div>
                                 <div class="col-md-12 mb-4">
                                  <div class="container">
                                    <telerik:RadButton runat="server" ID="BCerrar" Text="Salir"></telerik:RadButton>
                                    <telerik:RadLabel runat="server" ID="Lerror"></telerik:RadLabel>
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
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
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

