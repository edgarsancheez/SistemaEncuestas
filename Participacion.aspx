<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Participacion.aspx.vb" Inherits="EncuestaVirtualOficina.Participacion" %>

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

    <title>Participación</title>
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
                                <div class="col-md-12">
                                    <telerik:RadGrid runat="server" ShowFooter="true" ID="GridParticipacion" Skin="Metro">
                                 <MasterTableView AutoGenerateColumns="False" CommandItemDisplay="Top">
                                    <CommandItemTemplate>
                                        <div class="text-lg-end">  
                                            <telerik:RadImageButton runat="server" ID="Excel" Width="24px" Height="24px" CommandName="Excel" Image-Url="~/Imagenes/Iconos/excel.png"></telerik:RadImageButton>
                                        </div>
                                    </CommandItemTemplate>
                                    <Columns>
                                            <telerik:GridBoundColumn HeaderText="Unidad" Visible="true" ItemStyle-Font-Bold="true" DataField="Unidad_Negocio" UniqueName="Unidad_Negocio">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="Área" Visible="true" ItemStyle-Font-Bold="true" DataField="Area" UniqueName="Area">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="Conteo" ItemStyle-Font-Bold="true" DataField="Conteo" UniqueName="Conteo">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="Total" ItemStyle-Font-Bold="true" DataField="total" UniqueName="total">
                                            </telerik:GridBoundColumn>
                                    </Columns>
                                    </MasterTableView>
                                    </telerik:RadGrid>
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

