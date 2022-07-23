<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="S_EncuestaSeccion.aspx.vb" Inherits="EncuestaVirtualOficina.S_EncuestaSeccion" %>

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
                        <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-1"></div>
                                <div class="col-md-10 mb-3 text-center">
                                    <img src="https://www.lemancore.mx/wpv2/wp-content/uploads/lc-logo-horiz.png" class="img-fluid" alt="Responsive image"  />
                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-4 text-center">
                                    <asp:Label ID="LCuestionario1" runat="server" Visible="true" Font-Bold="True" Font-Size="14pt" ForeColor="Black"></asp:Label>
                                </div>
                                <div class="col-md-4 text-center mb-3">
                                    <asp:Label ID="LTema1" runat="server" Visible="true" Font-Bold="True" Font-Size="14pt" ForeColor="Black"></asp:Label>
                                </div>
                                <div class="col-md-4 text-center">
                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12pt" ForeColor="White"></asp:Label>
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

                                    <div class="row">
                                        <div class="col-md-1"> </div>
                                        <div class="col-md-10 mb-3">
                                                <asp:Label ID="LblPregunta1" runat="server" Font-Size="13pt" ToolTip="Pregunta actual" ></asp:Label>
                                              <asp:Label ID="lblid1" runat="server" Font-Size="7pt" Visible="False"></asp:Label>
                                        </div>
                                        <div class="col-md-1"></div>
                                        <div class="col-md-1"> </div>
                                        <div class="col-md-10 mb-3">
                                        <asp:RadioButtonList ID="Radio1" runat="server" Visible="False" RepeatDirection="Horizontal" RepeatLayout="Table" CssClass="radiobuttonlist" Width="60%">
                                        </asp:RadioButtonList>
                                        <asp:CheckBoxList ID="Checkbox1" runat="server" Font-Names="Arial" Font-Size="10pt" ForeColor="#333333" Visible="False" RepeatDirection="Horizontal">
                                        </asp:CheckBoxList>
                                            
                                        <telerik:RadComboBox runat="server" ID="Combobox1" Skin="Black" Visible="false"></telerik:RadComboBox>
                                        <telerik:RadTextBox runat="server" ID="txt1" Visible="false"  Width="80%"></telerik:RadTextBox>
                                        </div>
                                        <div class="col-md-1"></div>
                                        <div class="col-md-1"></div>
                                        <div class="col-md-10 mb-3">
                                            <asp:Label ID="LblPregunta2" runat="server" Font-Size="13pt" ToolTip="Pregunta actual" ></asp:Label>
                                            <asp:Label ID="lblid2" runat="server" Font-Size="7pt" Visible="False"></asp:Label>
                                        </div>
                                        <div class="col-md-1"></div>
                                        <div class="col-md-1"></div>
                                        <div class="col-md-10 mb-3">
                                            <asp:RadioButtonList ID="Radio2" runat="server" Visible="False" RepeatDirection="Horizontal" RepeatLayout="Table" CssClass="radiobuttonlist" Width="60%">
                                            </asp:RadioButtonList>
                                            <asp:CheckBoxList ID="Checkbox2" runat="server" Font-Names="Arial" Font-Size="10pt" ForeColor="#333333" Visible="False" RepeatDirection="Horizontal">
                                            </asp:CheckBoxList>
                                            <telerik:RadComboBox runat="server" ID="Combobox2" Skin="Black" Visible="false"></telerik:RadComboBox>
                                            <telerik:RadTextBox runat="server" Visible="false"  ID="txt2" Width="80%"></telerik:RadTextBox>
                                        </div>
                                        <div class="col-md-1"></div>
                                    <div class="col-md-1"></div>
                                    <div class="col-md-10 mb-3">
                                        <asp:Label ID="LblPregunta3" runat="server" Font-Size="13pt" ToolTip="Pregunta actual" ></asp:Label>
                                        <asp:Label ID="lblid3" runat="server" Font-Size="7pt" Visible="False"></asp:Label>
                                    </div>
                                    <div class="col-md-1"></div>
                                    <div class="col-md-1"></div>
                                    <div class="col-md-10 mb-3">
                                        <asp:RadioButtonList ID="Radio3" runat="server" Visible="False" RepeatDirection="Horizontal" RepeatLayout="Table" CssClass="radiobuttonlist" Width="60%">
                                        </asp:RadioButtonList>
                                        <asp:CheckBoxList ID="Checkbox3" runat="server" Font-Names="Arial" Font-Size="10pt" ForeColor="#333333" Visible="False" RepeatDirection="Horizontal">
                                        </asp:CheckBoxList>
                                        <telerik:RadComboBox runat="server" ID="Combobox3" Skin="Black" Visible="false"></telerik:RadComboBox>
                                        <telerik:RadTextBox runat="server" Visible="false"  ID="txt3" Width="80%"></telerik:RadTextBox>
                                    </div>
                                    <div class="col-md-1"></div>
                                    <div class="col-md-1"></div>
                                    <div class="col-md-10 mb-3">
                                        <asp:Label ID="LblPregunta4" runat="server" Font-Size="13pt" ToolTip="Pregunta actual" ></asp:Label>
                                        <asp:Label ID="lblid4" runat="server" Font-Size="7pt" Visible="False"></asp:Label>
                                    </div>
                                    <div class="col-md-1"></div>
                                    <div class="col-md-1"></div>
                                    <div class="col-md-10 mb-3">
                                        <asp:RadioButtonList ID="Radio4" runat="server" Visible="False" RepeatDirection="Horizontal" RepeatLayout="Table" CssClass="radiobuttonlist" Width="60%">
                                        </asp:RadioButtonList>
                                        <asp:CheckBoxList ID="Checkbox4" runat="server" Font-Names="Arial" Font-Size="10pt" ForeColor="#333333" Visible="False" RepeatDirection="Horizontal">
                                        </asp:CheckBoxList>
                                        <telerik:RadComboBox runat="server" ID="Combobox4" Skin="Black" Visible="false"></telerik:RadComboBox>
                                        <telerik:RadTextBox runat="server" ID="txt4" Visible="false"  Width="80%"></telerik:RadTextBox>
                                    </div>
                                    <div class="col-md-1"></div>
                                    <div class="col-md-1"></div>
                                    <div class="col-md-10 mb-3">
                                        <asp:Label ID="LblPregunta5" runat="server" Font-Size="13pt" ToolTip="Pregunta actual" ></asp:Label>
                                        <asp:Label ID="lblid5" runat="server" Font-Size="7pt" Visible="False"></asp:Label>
                                    </div>
                                    <div class="col-md-1"></div>
                                    <div class="col-md-1"></div>
                                    <div class="col-md-10 mb-3">
                                        <asp:RadioButtonList ID="Radio5" runat="server" Visible="False" RepeatDirection="Horizontal" RepeatLayout="Table" CssClass="radiobuttonlist" Width="60%">
                                        </asp:RadioButtonList>
                                        <asp:CheckBoxList ID="Checkbox5" runat="server" Font-Names="Arial" Font-Size="10pt" ForeColor="#333333" Visible="False" RepeatDirection="Horizontal">
                                        </asp:CheckBoxList>
                                        <telerik:RadComboBox runat="server" ID="Combobox5" Skin="Black" Visible="false"></telerik:RadComboBox>
                                        <telerik:RadTextBox runat="server" ID="txt5" Visible="false" Width="80%"></telerik:RadTextBox>
                                    </div>
                                    <div class="col-md-1"></div>
                                    </div>

<%--                                BOTONES ANTERIOR Y SIGUIENTE--%>
                                <div class="ROW">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-10">
                                        <telerik:RadButton ID="BtnAnterior" runat="server" Font-Bold="True" Text="Anterior" Skin="Metro"></telerik:RadButton>
                                        <telerik:RadButton ID="BTNSIGUIENTE" runat="server" Font-Bold="True" Text="Siguiente" Skin="Metro"></telerik:RadButton>
                                    </div>
                                    <div class="col-md-1"></div>
                                </div>

                                <%--ERROR--%>
                                <div class="row">
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
            </div>
    </form>
</body>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js"></script>
</html>
