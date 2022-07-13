<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Politicas.aspx.vb" Inherits="EncuestaVirtualOficina.Politicas" %>

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
                                    <asp:Label ID="Label8" runat="server" Visible="true" Font-Bold="True" Font-Size="16pt" ForeColor="Black">Política de Prevención de Riesgos Psicosociales</asp:Label>
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
                                <div class="col-md-1"></div>
                                <div class="col-md-10">
                                    <asp:Label ID="LBLPREGUNTA" runat="server" Font-Size="13pt" ToolTip="Pregunta actual" Font-Bold="true"></asp:Label>
                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-1"></div>
                                <div class="col-md-10">
                                    <asp:RadioButtonList ID="RbRespuesta2" runat="server" Visible="False" RepeatDirection="Vertical" RepeatLayout="Table" CssClass="radiobuttonlist" Width="60%">
                                    </asp:RadioButtonList>
                                    <asp:CheckBoxList ID="ChkRespuesta" runat="server" Font-Names="Arial" Font-Size="10pt" ForeColor="#333333" Visible="False" RepeatDirection="Horizontal">
                                    </asp:CheckBoxList>
                                    <telerik:RadComboBox runat="server" ID="RComboRespuesta1" Skin="Black" Visible="false"></telerik:RadComboBox>
                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-1"></div>
                                <div class="col-md-10">
                                    <telerik:RadTextBox ID="TexPreguntaAbierta" runat="server" EmptyMessage="Ingresa tu Nombre completo:" Visible="FALSE" Rows="3" TextMode="MultiLine" Width="90%" EnableAriaSupport="True"
                                        DisplayText="Ingresa tu Nombre completo:" Skin="Bootstrap">
                                    </telerik:RadTextBox>
                                    <telerik:RadNumericTextBox ID="RadNumericTextBox1" Visible="False" runat="server" Culture="en-US" DbValueFactor="1" LabelWidth="64px" Skin="Black" Height="40px" Width="160px" MinValue="0">
                                        <NegativeStyle Resize="None"></NegativeStyle>
                                        <NumberFormat ZeroPattern="n"></NumberFormat>
                                        <EmptyMessageStyle Resize="None"></EmptyMessageStyle>
                                        <ReadOnlyStyle Resize="None"></ReadOnlyStyle>
                                        <FocusedStyle Resize="None"></FocusedStyle>
                                        <DisabledStyle Resize="None"></DisabledStyle>
                                        <InvalidStyle Resize="None"></InvalidStyle>
                                        <HoveredStyle Resize="None"></HoveredStyle>
                                        <EnabledStyle Resize="None"></EnabledStyle>
                                    </telerik:RadNumericTextBox>
                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-1"></div>
                                <div class="col-md-10">
                                    <telerik:RadButton ID="BTNSIGUIENTE" runat="server" Font-Bold="True" Text="Guardar" Skin="Metro"></telerik:RadButton>
                                    <br /><br />
                                    <asp:Label ID="Lerror" runat="server" Font-Size="10pt" Style="font-family: Arial; font-size: 10pt" ForeColor="Maroon"></asp:Label>
                                </div>
                                <div class="col-md-1"></div>
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
