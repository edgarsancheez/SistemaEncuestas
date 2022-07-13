<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="S_EncuestaAll.aspx.vb" Inherits="EncuestaVirtualOficina.S_EncuestaAll" %>

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
        .radiobuttonlist {
        }
        .radiobuttonlist td{
            /*border:1px solid green;
            height:40px;*/
            vertical-align:central;
        }
    </style>
    <title>Encuesta</title>
</head>

<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="card border-dark">
                    <div class="card-body">
                        <div class="col-md-12 ">
                            <div class="row">
                                <div class="col-md-1">  </div>
                                <div class="col-md-10 text-center mb-3">
                                    <div class="">
                                        <img src="https://www.lemancore.mx/wpv2/wp-content/uploads/lc-logo-horiz.png" class="img-fluid" alt="Responsive image"  />
                                    </div>

                                    <asp:Label ID="LTema1" runat="server" Visible="true" Font-Bold="True" Font-Size="14pt" ForeColor="Black"></asp:Label>
                                    <asp:Label ID="LCuestionario1" runat="server" Visible="false" Font-Bold="True" Font-Size="16pt" ForeColor="Black"></asp:Label>
                                    <asp:Label ID="Label8" runat="server" Visible="true" Font-Bold="True" Font-Size="16pt" ForeColor="Black">Encuesta</asp:Label>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="LFolio" runat="server" Font-Bold="True" Font-Size="14pt" Visible="False" ForeColor="Black"></asp:Label>
                                    <asp:Label ID="LCount" runat="server" Font-Size="10pt" Visible="false" Font-Names="Arial"></asp:Label>
                                    <asp:Label ID="ResOp" runat="server" Font-Size="10pt" Visible="False" Font-Names="Arial"></asp:Label>
                                    <asp:Label ID="LMideSatisfaccion" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="LIndicadorRespuesta" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="LComplemento" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="LValor" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="LTexto" runat="server" Font-Size="10pt" Visible="False"></asp:Label>
                                </div>
                                <div class="col-md-1"> </div>
                                <div class="col-md-10 mb-3 justify-content-center">
                                    <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="10pt" Text=""></asp:Label>
                                    <asp:Label ID="Label2" runat="server" Font-Names="Arial" Font-Size="10pt" Text=""></asp:Label>
                                    <asp:Label ID="Label3" runat="server" Font-Names="Arial" Font-Size="10pt" Text=""></asp:Label>
                                    <asp:Label ID="Label4" runat="server" Font-Names="Arial" Font-Size="10pt" Text=""></asp:Label>
                                    <asp:Label ID="Label5" runat="server" Font-Names="Arial" Font-Size="10pt" Text=""></asp:Label>
                                    <asp:Label ID="Label6" runat="server" Font-Names="Arial" Font-Size="10pt" Text=""></asp:Label>
                                    <asp:Label ID="Label7" runat="server" Font-Names="Arial" Font-Size="10pt" Text=""></asp:Label>
                                </div>
                                <div class="col-md-1"> </div>
                                <div class="col-md-12 mb-3 justify-content-center">
                                    <telerik:RadGrid ID="DgDatos" runat="server" AutoGenerateColumns="False" Width="100%" Skin="Metro">
                                        <HeaderContextMenu EnableEmbeddedSkins="False">
                                            <WebServiceSettings>
                                                <ODataSettings InitialContainerName="">
                                                </ODataSettings>
                                            </WebServiceSettings>
                                        </HeaderContextMenu>
                                        <MasterTableView width="100%">
                                            <EditItemTemplate>
                                            </EditItemTemplate>
                                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">  </RowIndicatorColumn>
                                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True"> </ExpandCollapseColumn>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="IdPregunta" Display="False" HeaderText="Id" UniqueName="IdPregunta">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="DescPregunta" ItemStyle-Width="50%" HeaderText="Pregunta" UniqueName="DescPregunta">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn HeaderText="Columna1" UniqueName="Columna1" Visible="true">
                                                    <ItemTemplate>
                                                        <div class="container">
                                                            <div class="row">
                                                                <div class="col-md-12">
                                                                    <asp:RadioButtonList RepeatDirection="Horizontal"  runat="server" ID="Radio1" Width="50%"></asp:RadioButtonList>
                                                                    <asp:CheckBoxList runat="server" id="Check1" Width="50%"></asp:CheckBoxList>
                                                                    <asp:DropDownList runat="server" ID="Combo1" Width="50%"></asp:DropDownList>
                                                                    <asp:TextBox runat="server" ID="Texto1" Width="50%" Height="50"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="IdTipoRespuesta" Display="False" HeaderText="IdTipoRespuesta" UniqueName="IdTipoRespuesta">
                                                    <HeaderStyle Width="0px" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Complemento" Display="False" HeaderText="Complemento" UniqueName="Complemento">
                                                    <HeaderStyle Width="0px" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="IndicadorRespuestaDada" Display="False" HeaderText="IndicadorRespuestaDada" UniqueName="IndicadorRespuestaDada">
                                                    <HeaderStyle Width="0px" />
                                                </telerik:GridBoundColumn>
                                            </Columns>
                                            <EditFormSettings>
                                                <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif" InsertImageUrl="Update.gif" UpdateImageUrl="Update.gif">
                                                </EditColumn>
                                            </EditFormSettings>
                                            <HeaderStyle Font-Bold="True" Font-Italic="False" />
                                        </MasterTableView>
<GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>

                                        <ClientSettings EnableRowHoverStyle="True">
                                        </ClientSettings>
                                        <FilterMenu EnableEmbeddedSkins="False">
                                            <WebServiceSettings>
                                                <ODataSettings InitialContainerName="">
                                                </ODataSettings>
                                            </WebServiceSettings>
                                        </FilterMenu>
                                    </telerik:RadGrid>

                                </div>
                                <div class="col-md-12 align-content-center">
                                    <telerik:RadButton runat="server" ID="BConfirmar1" Skin="Metro" Text="Confirmar"></telerik:RadButton>
                                    <telerik:RadButton runat="server" ID="Bfinalizar1" Skin="Metro" Text="Finalizar"></telerik:RadButton>
                                    <telerik:RadLabel runat="server" ID="Lerror"></telerik:RadLabel>
                                </div>
                                </div>
                            </div>
                            <br />
                            </div>
                            </div>
                             <%--FINALIZACIÓN--%>
                            <div class="row">
                                <div>
                                    
                                    <div class="container section center-align" runat="server">

                                        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
                                        <telerik:RadWindowManager ID="RadWindowManager1" runat="server" AutoSize="True" Skin="Bootstrap" VisibleStatusbar="False" VisibleTitlebar="False"></telerik:RadWindowManager>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
    </form>
</body>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js"></script>
</html>
