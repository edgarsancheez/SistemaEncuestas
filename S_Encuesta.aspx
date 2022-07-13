<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="S_Encuesta.aspx.vb" Inherits="EncuestaVirtualOficina.S_Encuesta" %>

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
    <form id="form1" class="mb-4" runat="server">
        <div class="container">
            <div class="row">
                <div class="card border-dark mb-4">
                    <div class="card-body">
                        <div class="col-md-12 ">
                            <div class="row">
                                <div class="col-md-1"></div>
                                <div class="col-md-10 mb-3 text-center">
                                    <img src="https://www.lemancore.mx/wpv2/wp-content/uploads/lc-logo-horiz.png" class="img-fluid" alt="Responsive image"  />
                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-4 text-center">
                                    <asp:Label ID="LCuestionario1" runat="server" Visible="true" Font-Bold="True" Font-Size="14pt" ForeColor="Black">Pregunta : 0 de 0</asp:Label>
                                </div>
                                <div class="col-md-4 text-center mb-3">
                                    <asp:Label ID="LTema1" runat="server" Visible="true" Font-Bold="True" Font-Size="14pt" ForeColor="Black"></asp:Label>
                                </div>
                                <div class="col-md-4 text-center">
                                    <asp:Label ID="LFolio" runat="server" Font-Bold="True" Font-Size="14pt" Visible="False" ForeColor="Black"></asp:Label>
                                    <asp:Label ID="LCount" runat="server" Font-Size="10pt" Visible="false" Font-Names="Arial"></asp:Label>
                                    <asp:Label ID="ResOp" runat="server" Font-Size="10pt" Visible="False" Font-Names="Arial"></asp:Label>
                                    <asp:Label ID="LMideSatisfaccion" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="LIndicadorRespuesta" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="LComplemento" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="LValor" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="LTexto" runat="server" Font-Size="10pt" Visible="False"></asp:Label>
                                    <asp:Label ID="LPilaPregunta" runat="server" Font-Size="10pt" Visible="False"></asp:Label>
                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-10 mb-3">
                                    <asp:Label ID="LBLPREGUNTA" runat="server" Font-Size="13pt" ToolTip="Pregunta actual" ></asp:Label>
                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-1"></div>
                                <div class="col-md-10 mb-3">
                                    <asp:RadioButtonList ID="RbRespuesta2" runat="server" Visible="False" RepeatDirection="Vertical" RepeatLayout="Table" CssClass="radiobuttonlist" Width="60%">
                                    </asp:RadioButtonList>
                                    <asp:CheckBoxList ID="ChkRespuesta" runat="server" Font-Names="Arial" Font-Size="10pt" ForeColor="#333333" Visible="False" RepeatDirection="Horizontal">
                                    </asp:CheckBoxList>
                                    <telerik:RadComboBox runat="server" ID="RComboRespuesta1" Skin="Black" Visible="false"></telerik:RadComboBox>
                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-1"></div>
                                <div class="col-md-10 mb-3">
                                    <telerik:RadTextBox ID="TexPreguntaAbierta" runat="server" EmptyMessage="Ingrese un comentario acerca de este punto." Visible="FALSE" Rows="3" TextMode="MultiLine" Width="90%" EnableAriaSupport="True"
                                        DisplayText="Ingrese un comentario acerca de este punto." Skin="Bootstrap">
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
                                    <telerik:RadButton ID="BtnAnterior" runat="server" Font-Bold="True" Text="Anterior" Skin="Metro"></telerik:RadButton>
                                    <telerik:RadButton ID="BTNSIGUIENTE" runat="server" Font-Bold="True" Text="Siguiente" Skin="Metro"></telerik:RadButton>
                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-1"></div>
                                <div class="col-md-10">
                                    <asp:Label ID="Lerror" runat="server" Font-Size="10pt" Style="font-family: Arial; font-size: 10pt" ForeColor="Maroon"></asp:Label>
                                    <div class="container section center-align" runat="server">
                                        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
                                        <telerik:RadWindowManager ID="RadWindowManager1" runat="server" AutoSize="True" Skin="Bootstrap" VisibleStatusbar="False" VisibleTitlebar="False"></telerik:RadWindowManager>
                                    </div>
                                </div>
                                <div class="col-md-1"></div>
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
