Imports System.Data.SqlClient
Imports System.Globalization
Imports Telerik.Web.UI

Partial Public Class S_EncuestaAll
    Inherits System.Web.UI.Page
    Dim respuesta As Integer
    Dim RespuestaTexto As String
    Dim RespuestaOp As New Integer
    Dim RespuestaAd As New Integer
    Dim NoContesto As Integer = 0

    Public Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("UserConect") = 1 Then
                form1.Attributes.Add("background", Session("Background"))
                Try
                    LlenarGrid()
                Catch ex As Exception
                    Lerror.Text = "Problema: " & ex.Message & " Error: " & Err.Description & " Ubicacion: " & ex.StackTrace
                    Err.Clear()
                End Try
            Else
                Response.Redirect("Inicio.aspx?XXXX=" & CStr(Request.Params("XXXX")) & "&ZZZZ=" & CStr(Request.Params("ZZZZ")), False)
            End If
        End If

    End Sub

    Sub Cargar_datos()
        Dim DsGeneral As New DataSet
        Dim P(2) As SqlParameter
        P(0) = New SqlParameter("@TIPO", 15)
        P(1) = New SqlParameter("@IDESTUDIO", Session("IDESTUDIO"))
        P(2) = New SqlParameter("@IDENCUESTA", Session("IDENCUESTA"))
        DsGeneral = DatosBD.FuncionConPar("SP_Encuestas", P, Lerror.Text)

        If Not DsGeneral Is Nothing Then
            Label1.Text = DsGeneral.Tables(0).Rows(0).Item(0)
            Label2.Text = DsGeneral.Tables(0).Rows(1).Item(0)
            Label3.Text = DsGeneral.Tables(0).Rows(2).Item(0)
            Label4.Text = DsGeneral.Tables(0).Rows(3).Item(0)
            Label5.Text = DsGeneral.Tables(0).Rows(4).Item(0)
            Label6.Text = DsGeneral.Tables(0).Rows(5).Item(0)
            Label7.Text = DsGeneral.Tables(0).Rows(6).Item(0)
        Else
            Lerror.Text = "No existe informacion disponible."
            Cargar.UserMsgBox(Lerror.Text, Me.Page)
        End If
    End Sub

    Sub LlenarGrid()
        DgDatos.DataSource = Nothing
        DgDatos.DataBind()

        Dim P(1) As SqlParameter
        P(0) = New SqlParameter("@TIPO", 19)
        P(1) = New SqlParameter("@IDENCUESTA", Session("IdEncuesta"))
        Dim ds As New DataSet
        ds = DatosBD.FuncionConPar("SP_Encuestas", P, Lerror.Text)
        DgDatos.DataSource = ds.Tables(0)
        DgDatos.DataBind()

        If Session("NT1") = "-1" Then
            DgDatos.Visible = False
            RadWindowManager1.RadAlert("Esta información ya fué respondida", 330, 180, "Aviso", "", "null")
            BConfirmar1.Visible = False
        Else
            DgDatos.Visible = True
            Lerror.Text = ""
            BConfirmar1.Visible = True
        End If
        DgDatos.DataBind()
    End Sub

    Private Sub DgDatos_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles DgDatos.ItemDataBound
        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item OrElse e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
            If e.Item.Cells(5).Text = "999" Then 'Cuales son las respuestas
                e.Item.FindControl("Radio1").Visible = False
                e.Item.FindControl("Check1").Visible = False
                e.Item.FindControl("Combo1").Visible = False
                e.Item.FindControl("Texto1").Visible = True
            Else
                If e.Item.Cells(7).Text = "1" Then
                    e.Item.FindControl("Radio1").Visible = True
                    e.Item.FindControl("Check1").Visible = False
                    e.Item.FindControl("Combo1").Visible = False
                    e.Item.FindControl("Texto1").Visible = False

                    Dim Radio1 As RadioButtonList = e.Item.FindControl("Radio1")

                    Dim P1(2) As SqlParameter
                    P1(0) = New SqlParameter("@TIPO", 20)
                    P1(1) = New SqlParameter("@IdEncuesta", Session("IdEncuesta"))
                    P1(2) = New SqlParameter("@IdPregunta", e.Item.Cells(2).Text)
                    Dim ds As New DataSet
                    ds = DatosBD.FuncionConPar("SP_Encuestas", P1, Lerror.Text)
                    Radio1.DataSource = ds.Tables(0)
                    Radio1.DataTextField = "DescRespuesta"
                    Radio1.DataValueField = "OrdenRespuesta"
                    Radio1.DataBind()

                ElseIf e.Item.Cells(7).Text = "2" Then
                    'Cargamos las respuestas en los radiobutton
                    e.Item.FindControl("Radio1").Visible = False
                    e.Item.FindControl("Check1").Visible = True
                    e.Item.FindControl("Combo1").Visible = False
                    e.Item.FindControl("Texto1").Visible = False

                    Dim CheckBox As CheckBoxList = e.Item.FindControl("Check1")
                    CheckBox.Items.Clear()

                    Dim P1(2) As SqlParameter
                    P1(0) = New SqlParameter("@TIPO", 20)
                    P1(1) = New SqlParameter("@IdEncuesta", Session("IdEncuesta"))
                    P1(2) = New SqlParameter("@IdPregunta", e.Item.Cells(2).Text)
                    Dim ds As New DataSet
                    ds = DatosBD.FuncionConPar("SP_Encuestas", P1, Lerror.Text)
                    CheckBox.DataSource = ds.Tables(0)
                    CheckBox.DataTextField = "DescRespuesta"
                    CheckBox.DataValueField = "OrdenRespuesta"
                    CheckBox.DataBind()
                ElseIf e.Item.Cells(7).Text = "3" Then
                    'Cargamos las respuestas en los radiobutton
                    e.Item.FindControl("Radio1").Visible = False
                    e.Item.FindControl("Check1").Visible = False
                    e.Item.FindControl("Combo1").Visible = True
                    e.Item.FindControl("Texto1").Visible = False

                    Dim Combo As DropDownList = e.Item.FindControl("Combo1")
                    Combo.Items.Clear()

                    Dim P1(2) As SqlParameter
                    P1(0) = New SqlParameter("@TIPO", 20)
                    P1(1) = New SqlParameter("@IdEncuesta", Session("IdEncuesta"))
                    P1(2) = New SqlParameter("@IdPregunta", e.Item.Cells(2).Text)
                    Dim ds As New DataSet
                    ds = DatosBD.FuncionConPar("SP_Encuestas", P1, Lerror.Text)
                    Combo.DataSource = ds.Tables(0)
                    Combo.DataTextField = "DescRespuesta"
                    Combo.DataValueField = "OrdenRespuesta"
                    Combo.DataBind()

                End If
                'If e.Item.Cells(6).Text = "0" Then
                '    e.Item.FindControl("Radio1").Visible = False
                '    e.Item.FindControl("Check1").Visible = False
                '    e.Item.FindControl("Combo1").Visible = False
                '    e.Item.FindControl("Texto1").Visible = False
                'End If
            End If

        End If
    End Sub

    Protected Sub Bfinalizar1_Click(sender As Object, e As EventArgs) Handles Bfinalizar1.Click
        'Validamos que haya guardado la encuesta
        For Col As Integer = 4 To CInt(Session("ColVis")) + 3
            For Reg As Integer = 0 To DgDatos.MasterTableView.Items.Count - 1
                Dim Combo As RadComboBox = CType(DgDatos.Items(Reg).Cells(Col).Controls(1), RadComboBox)
                If Combo.SelectedValue <> "-1" Then
                    'Guarde la encuesta
                    RadWindowManager1.RadAlert("Favor de guardar la información con el botón &quot;Guardar&quot; antes de finalizar y salir.", 330, 180, "Aviso", "", "null")
                    Exit Sub
                End If
            Next
        Next
        Response.Redirect("Inicio.aspx?XXXX=" & CStr(Request.Params("XXXX")) & "&ZZZZ=" & CStr(Request.Params("ZZZZ")), False)
    End Sub

    Protected Sub BConfirmar1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BConfirmar1.Click
        Dim TblMesj As New DataTable
        Dim Cont0 As Boolean = True
        Dim Cont1 As Boolean = True
        Dim Cont2 As Boolean = True
        Dim ConNT As Integer = 0
        Dim RI As Integer = 0 'Registro Inicial del Grid (si tiene NA General o no)
        Try
            Session("ColVis") = 1
            If Session("ColVis") <> 0 Then
                TblMesj = CType(Session("TablaMensaje"), DataTable)
                If TblMesj Is Nothing Then
                    Cont0 = False
                End If

                RI = 0
                For Col As Integer = 4 To CInt(Session("ColVis")) + 3
                    For Reg As Integer = RI To DgDatos.MasterTableView.Items.Count - 1
                        Dim Combo As DropDownList = CType(DgDatos.Items(Reg).Cells(Col).Controls(1), DropDownList)
                        Dim Check As CheckBoxList = CType(DgDatos.Items(Reg).Cells(Col).Controls(1), CheckBoxList)
                        Dim Radio As RadioButtonList = CType(DgDatos.Items(Reg).Cells(Col).Controls(1), RadioButtonList)
                        Dim Textbox As RadTextBox = CType(DgDatos.Items(Reg).Cells(Col).FindControl("RadTexbox1"), RadTextBox)
                        If Textbox.Visible = False Then
                            If Combo.SelectedValue = "-1" Or Radio.SelectedValue = "-1" Or Check.SelectedValue = "-1" Then
                                DgDatos.Items(Reg).Cells(Col).BackColor = Drawing.Color.Yellow
                                Cont1 = False
                            Else
                                DgDatos.Items(Reg).Cells(Col).BackColor = Drawing.Color.Transparent
                            End If
                        Else
                            If Textbox.Text = "" Then
                                DgDatos.Items(Reg).Cells(Col).BackColor = Drawing.Color.Yellow
                                Cont1 = False
                            Else
                                DgDatos.Items(Reg).Cells(Col).BackColor = Drawing.Color.Transparent
                            End If
                        End If
                    Next
                Next
                If Cont1 = True Then
                    For Col As Integer = 4 To CInt(Session("ColVis")) + 3
                        ConNT = ConNT + 1
                        For Reg As Integer = RI To DgDatos.MasterTableView.Items.Count - 1
                            Dim Check As CheckBoxList = CType(DgDatos.Items(Reg).Cells(Col).Controls(1), CheckBoxList)
                            'ENTRA SI ES CHECKBOXS
                            'If Check.Visible = True Then
                            '    Dim collectiontest As IList(Of Check.items) = Check.Items
                            '    If collectiontest.Count > 0 Then

                            '        For Each item As RadComboBoxItem In collectiontest
                            '            Combo.SelectedValue = item.Value

                            '            If (CInt(Combo.SelectedValue) >= 4 And CInt(Combo.SelectedValue) <> 7 And DgDatos.Items(Reg).Cells(8).Text = 1) Or DgDatos.Items(Reg).Cells(5).Text = 999 Then
                            '                If Cont0 = True Then
                            '                    Dim dv As DataView = TblMesj.DefaultView
                            '                    dv.RowFilter = ("Registro=" & (Reg * 2) + 2 & " and columna=" & Col - 1 & " and numtrabajador='" & Session("NT" & ConNT) & "' and idencuesta=" & Session("idencuesta"))
                            '                    If dv.ToTable.Rows.Count >= 1 AndAlso Len(CStr(dv.ToTable.Rows(0).Item(5))) > 0 Then
                            '                        'Comentario requerido
                            '                        DgDatos.Items(Reg).Cells(Col).BackColor = Drawing.Color.Transparent
                            '                    Else
                            '                        '  DgDatos.Items(Reg).Cells(Col).BackColor = Drawing.Color.Red
                            '                        ' Cont2 = False
                            '                    End If
                            '                Else
                            '                    'Comentario requerido
                            '                    ' DgDatos.Items(Reg).Cells(Col).BackColor = Drawing.Color.Red
                            '                    'Cont2 = False
                            '                End If
                            '            Else
                            '                DgDatos.Items(Reg).Cells(Col).BackColor = Drawing.Color.Transparent
                            '            End If

                            '        Next

                            '    End If
                            'Else 'SI ENTRA AQUI POR QUE ES COMBOBOX
                            '    If Combo.SelectedValue = "-1" And Textbox.Text = "" Then
                            '        If Cont0 = True Then
                            '            Dim dv As DataView = TblMesj.DefaultView
                            '            dv.RowFilter = ("Registro=" & (Reg * 2) + 2 & " and columna=" & Col - 1 & " and numtrabajador='" & Session("NT" & ConNT) & "' and idencuesta=" & Session("idencuesta"))
                            '            If dv.ToTable.Rows.Count >= 1 AndAlso Len(CStr(dv.ToTable.Rows(0).Item(5))) > 0 Then
                            '                'Comentario requerido
                            '                DgDatos.Items(Reg).Cells(Col).BackColor = Drawing.Color.Transparent
                            '            Else
                            '                DgDatos.Items(Reg).Cells(Col).BackColor = Drawing.Color.Red
                            '                Cont2 = False
                            '            End If
                            '        Else
                            '            'Comentario requerido
                            '            DgDatos.Items(Reg).Cells(Col).BackColor = Drawing.Color.Red
                            '            Cont2 = False
                            '        End If
                            '    Else
                            '        DgDatos.Items(Reg).Cells(Col).BackColor = Drawing.Color.Transparent
                            '    End If
                            'End If

                        Next
                    Next
                End If

                If Cont2 = True And Cont1 = True Then
                    ConNT = 0
                    For Col As Integer = 4 To CInt(Session("ColVis")) + 3
                        ConNT = ConNT + 1
                        For Reg As Integer = RI To DgDatos.MasterTableView.Items.Count - 1

                            Dim Combo As RadComboBox = CType(DgDatos.Items(Reg).Cells(Col).Controls(1), RadComboBox)
                            Dim Textbox As RadTextBox = CType(DgDatos.Items(Reg).Cells(Col).FindControl("RadTexbox1"), RadTextBox)
                            Dim NumEvaluado As String = Session("NT" & ConNT)

                            Dim ValMsj As String
                            If Cont0 = True Then
                                Dim dv As DataView = TblMesj.DefaultView
                                dv.RowFilter = ("Registro=" & (Reg * 2) + 2 & " and columna=" & Col - 1 & " and numtrabajador='" & NumEvaluado & "' and idencuesta=" & Session("idencuesta"))
                                If dv.ToTable.Rows.Count >= 1 AndAlso Len(CStr(dv.ToTable.Rows(0).Item(5))) > 0 Then
                                    ValMsj = CStr(dv.ToTable.Rows(0).Item(5))
                                Else
                                    ValMsj = CStr("NO APLICA")
                                End If
                            Else
                                ValMsj = Textbox.Text
                            End If

                            Dim NumTrabajador As String = Session("UserValue")
                            Dim ValCbo As Integer = Combo.SelectedValue

                            If Combo.CheckBoxes = False Then
                                Dim P(6) As SqlParameter
                                P(0) = New SqlParameter("@TIPO", 21)
                                P(1) = New SqlParameter("@IdEstudio", Session("IdEstudio"))
                                P(2) = New SqlParameter("@IdEncuesta", Session("IdEncuesta"))
                                P(3) = New SqlParameter("@NumTrabajador", Session("CveUsuario"))
                                P(4) = New SqlParameter("@IdPregunta", DgDatos.Items(Reg).Cells(2).Text)
                                P(5) = New SqlParameter("@RESPUESTA", ValCbo)
                                P(6) = New SqlParameter("@COMENTARIO", ValMsj)
                                DatosBD.ProcedimientoConPar("SP_Encuestas", P, Lerror.Text)
                            Else
                                Dim collection As IList(Of RadComboBoxItem) = Combo.CheckedItems
                                If collection.Count > 0 Then
                                    For Each item As RadComboBoxItem In collection
                                        Dim P(6) As SqlParameter
                                        P(0) = New SqlParameter("@TIPO", 21)
                                        P(1) = New SqlParameter("@IdEstudio", Session("IdEstudio"))
                                        P(2) = New SqlParameter("@IdEncuesta", Session("IdEncuesta"))
                                        P(3) = New SqlParameter("@NumTrabajador", Session("CveUsuario"))
                                        P(4) = New SqlParameter("@IdPregunta", DgDatos.Items(Reg).Cells(2).Text)
                                        P(5) = New SqlParameter("@RESPUESTA", item.Value)
                                        P(6) = New SqlParameter("@COMENTARIO", ValMsj)
                                        DatosBD.ProcedimientoConPar("SP_Encuestas", P, Lerror.Text)
                                    Next
                                End If
                            End If
                        Next
                    Next
                    DgDatos.DataSource = Nothing
                    DgDatos.DataBind()
                    BConfirmar1.Visible = False
                    LlenarGrid()
                    Dim MensajeFin As String
                    RadWindowManager1.RadAlert(MensajeFin, 330, 180, "Aviso", "", "null")
                ElseIf Cont2 = False Then
                    RadWindowManager1.RadAlert("Según el tipo de respuesta seleccionada y en las preguntas abiertas, se requiere de un comentario obligatorio, favor de completar los campos marcados en rojo.", 330, 180, "Aviso", "", "null")
                ElseIf Cont1 = False Then
                    RadWindowManager1.RadAlert("La información requiere de una respuesta seleccionada para poder ser consideradas válidas, seleccionar los campos marcados en amarillo.", 330, 180, "Aviso", "", "null")
                End If
            Else
                RadWindowManager1.RadAlert("No hay datos visibles", 330, 180, "Aviso", "", "null")
            End If
        Catch ex As Exception
            RadWindowManager1.RadAlert(ex.Message, 330, 180, "Aviso", "", "null")
        Finally
            Cont0 = True
            Cont1 = True
            Cont2 = True
            ConNT = 0
        End Try
    End Sub

End Class