Imports System.Data.SqlClient
Imports System.Globalization
Imports Telerik.Web.UI
Imports System.Net.Mail
Imports System.IO
Imports System.Net
Imports System
Imports System.Web.UI.WebControls
Partial Public Class S_EncuestaSeccion
    Inherits System.Web.UI.Page
    Dim respuesta As Integer
    Dim RespuestaTexto As String
    Dim RespuestaOp As New Integer
    Dim RespuestaAd As New Integer
    Dim NoContesto As Integer = 0

    Public Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            form1.Attributes.Add("background", Session("Background"))
            BTNSIGUIENTE.Focus()
            Session("ContPreg") = 1
            Session("ContTema") = 1

            If Session("UserConect") = 1 Then
                Try
                    'Session("IdEncuesta") = 7
                    Dim Par(3) As SqlParameter
                    Par(0) = New SqlParameter("@TIPO", 11)
                    Par(1) = New SqlParameter("@IDESTUDIO", Session("IDESTUDIO"))
                    Par(2) = New SqlParameter("@IDENCUESTA", Session("IDENCUESTA"))
                    Par(3) = New SqlParameter("@NUMTRABAJADOR", Session("CveUsuario"))

                    Dim DS As DataSet
                    DS = DatosBD.FuncionConPar("SP_Encuestas", Par, Lerror.Text)
                    Session("IdNivel3") = DS.Tables(0).Rows(0).Item(0)
                    Session("NUMEROTRABAJADOR") = DateTime.Now.ToString("dMyyhms", CultureInfo.InvariantCulture)

                    Session("TblRespuestaPreguntas") = Nothing

                    Dim DsGeneral As New DataSet
                    Dim P(2) As SqlParameter
                    P(0) = New SqlParameter("@TIPO", 5)
                    P(1) = New SqlParameter("@IDESTUDIO", Session("IDESTUDIO"))
                    P(2) = New SqlParameter("@IDENCUESTA", Session("IDENCUESTA"))
                    DsGeneral = DatosBD.FuncionConPar("SP_Encuestas", P, Lerror.Text)

                    If Not DsGeneral Is Nothing Then
                        Session("DSGeneral") = DsGeneral
                        Dim dv As DataView = DsGeneral.Tables(0).DefaultView
                        Dim TblPReg As DataTable
                        dv.Sort = "IdPregunta Asc"
                        TblPReg = dv.ToTable()
                        'obtiene las  preguntas del tema actual
                        Session("PreguntasPorTema") = TblPReg
                        Session("ContPreg") = TblPReg.Rows(0).Item(0)
                        Session("TotalPreguntas") = DsGeneral.Tables(0).Rows.Count
                        Session("CuentaPreguntas") = TblPReg.Rows(0).Item(6) - 1
                        LCount.Text = "Pregunta " & Session("CuentaPreguntas") + 1 & " - " & Session("CuentaPreguntas") + 4 & " de " & Session("TotalPreguntas")
                        Dim cont As Integer = 0

                        For n As Integer = 0 To 4
                            cont = cont + 1
                            If cont <= TblPReg.Rows.Count Then
                                Session("ContPreg") = TblPReg.Rows(n).Item(0)
                                If cont = 1 Then
                                    CargarPregunta(TblPReg.Rows(n).Item(0), cont)
                                    LCount.Text = Session("ContPreg")
                                ElseIf cont = 2 Then
                                    CargarPregunta(TblPReg.Rows(n).Item(0), cont)
                                    LCount.Text = Session("ContPreg")
                                ElseIf cont = 3 Then
                                    CargarPregunta(TblPReg.Rows(n).Item(0), cont)
                                    LCount.Text = Session("ContPreg")
                                ElseIf cont = 4 Then
                                    CargarPregunta(TblPReg.Rows(n).Item(0), cont)
                                    LCount.Text = Session("ContPreg")
                                ElseIf cont = 5 Then
                                    CargarPregunta(TblPReg.Rows(n).Item(0), cont)
                                    LCount.Text = Session("ContPreg")
                                End If
                            End If
                        Next

                        BtnAnterior.Enabled = False

                    Else
                        Lerror.Text = "No existe informacion disponible."
                        Cargar.UserMsgBox(Lerror.Text, Me.Page)
                    End If

                Catch ex As Exception
                    Lerror.Text = "Problema: " & ex.Message & " Error: " & Err.Description & " Ubicacion: " & ex.StackTrace
                    Err.Clear()
                End Try
            Else
                Response.Redirect("Inicio.aspx?XXXX=" & CStr(Request.Params("XXXX")) & "&ZZZZ=" & CStr(Request.Params("ZZZZ")), False)
            End If
        End If

    End Sub

    Sub CargarPregunta(ByVal IdexPreg As Integer, ByVal cont As Integer)
        Try
            Dim Tabla As DataTable = CType(Session("PreguntasPorTema"), DataTable)
            If cont = 1 Then
                LblPregunta1.Text = Tabla.Rows(IdexPreg - 1).Item(3)
                lblid1.Text = IdexPreg
            ElseIf cont = 2 Then
                LblPregunta2.Text = Tabla.Rows(IdexPreg - 1).Item(3)
                lblid2.Text = IdexPreg
            ElseIf cont = 3 Then
                LblPregunta3.Text = Tabla.Rows(IdexPreg - 1).Item(3)
                lblid3.Text = IdexPreg
            ElseIf cont = 4 Then
                LblPregunta4.Text = Tabla.Rows(IdexPreg - 1).Item(3)
                lblid4.Text = IdexPreg
            ElseIf cont = 5 Then
                LblPregunta5.Text = Tabla.Rows(IdexPreg - 1).Item(3)
                lblid5.Text = IdexPreg
            End If

            LTema1.Text = Tabla.Rows(IdexPreg - 1).Item(2)
            LMideSatisfaccion.Text = Tabla.Rows(IdexPreg - 1).Item(5) 'MideSatisfaccion
            LIndicadorRespuesta.Text = Tabla.Rows(IdexPreg - 1).Item(6) 'IndicadorRespuestaDada
            LComplemento.Text = Tabla.Rows(IdexPreg - 1).Item(9) 'Complemento
            LPilaPregunta.Text = Tabla.Rows(IdexPreg - 1).Item(10) 'PILAPREGUNTA

            CargarRespuesta(Tabla.Rows(IdexPreg - 1).Item(4), LIndicadorRespuesta.Text, cont) 'TIPO DE RESPUESTA

            LCount.Text = Tabla.Rows.Count
            LCuestionario1.Text = "Pregunta : " & (Session("ContTema") - 1) & " de " & (LCount.Text - 1)

        Catch ex As Exception
            Lerror.Text = "Problema: " & ex.Message & "Error: " & Err.Description & "Ubicacion: " & ex.StackTrace
        End Try

    End Sub

    Sub CargarRespuesta(ByVal CveRespuesta As Integer, ByVal IndicadorRespuesta As Integer, ByVal Cont As Integer)
        Try
            Lerror.Text = ""
            Dim combo As New RadComboBox
            Dim radio As New RadioButtonList
            Dim check As New CheckBoxList

            Dim DSRespuestas As DataSet
            Dim PLoad(1) As SqlParameter
            PLoad(0) = New SqlParameter("@TIPO", 6)
            PLoad(1) = New SqlParameter("@IDRESPUESTA", CveRespuesta)
            DSRespuestas = DatosBD.FuncionConPar("SP_Encuestas", PLoad, Lerror.Text)

            If Lerror.Text.Length = 0 Then
                If Not DSRespuestas Is Nothing Then

                    If IndicadorRespuesta = 1 Then 'radiobutton
                        If Cont = 1 Then
                            Radio1.DataSource = DSRespuestas.Tables(0)
                            Radio1.DataTextField = "DescRespuesta"
                            Radio1.DataValueField = "OrdenRespuesta"
                            Radio1.DataBind()
                            Radio1.Visible = True
                        ElseIf Cont = 2 Then
                            Radio2.DataSource = DSRespuestas.Tables(0)
                            Radio2.DataTextField = "DescRespuesta"
                            Radio2.DataValueField = "OrdenRespuesta"
                            Radio2.DataBind()
                            Radio2.Visible = True
                        ElseIf Cont = 3 Then
                            Radio3.DataSource = DSRespuestas.Tables(0)
                            Radio3.DataTextField = "DescRespuesta"
                            Radio3.DataValueField = "OrdenRespuesta"
                            Radio3.DataBind()
                            Radio3.Visible = True
                        ElseIf Cont = 4 Then
                            Radio4.DataSource = DSRespuestas.Tables(0)
                            Radio4.DataTextField = "DescRespuesta"
                            Radio4.DataValueField = "OrdenRespuesta"
                            Radio4.DataBind()
                            Radio4.Visible = True
                        ElseIf Cont = 5 Then
                            Radio5.DataSource = DSRespuestas.Tables(0)
                            Radio5.DataTextField = "DescRespuesta"
                            Radio5.DataValueField = "OrdenRespuesta"
                            Radio5.DataBind()
                            Radio5.Visible = True
                        End If

                        'IndicadorRespuesta = 2 Then 'combobox
                        'combo.DataSource = DSRespuestas.Tables(0)
                        'combo.DataTextField = "DescRespuesta"
                        'combo.DataValueField = "OrdenRespuesta"
                        'combo.DataBind()
                        'combo.Visible = True

                        'If Cont = 1 Then
                        '    Combobox1 = combo
                        'ElseIf Cont = 2 Then
                        '    Combobox2 = combo
                        'ElseIf Cont = 3 Then
                        '    Combobox3 = combo
                        'ElseIf Cont = 4 Then
                        '    Combobox4 = combo
                        'ElseIf Cont = 5 Then
                        '    Combobox5 = combo
                        'End If
                        'ElseIf IndicadorRespuesta = 0 Then 'checkbox
                        '    check.DataSource = DSRespuestas.Tables(0)
                        '    check.DataTextField = "DescRespuesta"
                        '    check.DataValueField = "OrdenRespuesta"
                        '    check.DataBind()
                        '    check.Visible = True

                        '    If Cont = 1 Then
                        '        Checkbox1 = check
                        '    ElseIf Cont = 2 Then
                        '        Checkbox2 = check
                        '    ElseIf Cont = 3 Then
                        '        Checkbox3 = check
                        '    ElseIf Cont = 4 Then
                        '        Checkbox4 = check
                        '    ElseIf Cont = 5 Then
                        '        Checkbox5 = check
                        '    End If
                    End If
                End If
            Else
                Cargar.UserMsgBox(Lerror.Text, Me)
            End If

        Catch ex As Exception
            Lerror.Text = "Problema: " & ex.Message & "Error: " & Err.Description & "Ubicacion: " & ex.StackTrace
        End Try
    End Sub

    Public Sub BTNSIGUIENTE_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTNSIGUIENTE.Click
        Try
            Dim RowId = Session("ContPreg")
            Dim DsGeneral As DataSet = Session("DsGeneral")
            Dim Tabla As DataTable = CType(Session("PreguntasPorTema"), DataTable)
            Dim NumPreg As Integer = Tabla.Rows(RowId - 1).Item(0)

            If LblPregunta1.Visible = True Then
                If LIndicadorRespuesta.Text = 1 Then
                    If Radio1.SelectedValue = "" Then
                        Lerror.Text = "Es necesario responder las preguntas para continuar el cuestionario."
                        Exit Sub
                    Else
                        CrearDS(Session("IDESTUDIO"), Session("IDENCUESTA"), Session("NUMEROTRABAJADOR"),
                                    Session("IdNivel3"), lblid1.Text, Radio1.SelectedValue, "NA", True)
                    End If
                    'ElseIf LIndicadorRespuesta.Text = 2 Then
                    '    If Radio1.SelectedValue = "" Then
                    '            Lerror.Text = "Es necesario responder las preguntas para continuar el cuestionario."
                    '            Exit Sub
                    '        Else
                    '            CrearDS(Session("IDESTUDIO"), Session("IDENCUESTA"), Session("NUMEROTRABAJADOR"),
                    '            Session("IdNivel3"), NumPreg, Radio1.SelectedValue, "NA", True)
                    '        End If
                    'ElseIf LIndicadorRespuesta.Text = 0 Then
                    '    Dim CheckedItems As Integer = 0
                    '    For Each li As ListItem In Checkbox1.Items
                    '        If li.Selected Then
                    '            CheckedItems = CheckedItems + 1
                    '        End If
                    '    Next
                    '    If CheckedItems = 0 Then
                    '        Lerror.Text = "Es necesario responder las preguntas para continuar el cuestionario."
                    '        Exit Sub
                    '    End If
                End If
            End If
            If LblPregunta2.Visible = True Then
                If LIndicadorRespuesta.Text = 1 Then
                    If Radio2.SelectedValue = "" Then
                        Lerror.Text = "Es necesario responder las preguntas para continuar el cuestionario."
                        Exit Sub
                    Else
                        CrearDS(Session("IDESTUDIO"), Session("IDENCUESTA"), Session("NUMEROTRABAJADOR"),
                                    Session("IdNivel3"), lblid2.Text, Radio2.SelectedValue, "NA", True)
                    End If
                    'ElseIf LIndicadorRespuesta.Text = 2 Then
                    '    If Radio2.SelectedValue = "" Then
                    '            Lerror.Text = "Es necesario responder las preguntas para continuar el cuestionario."
                    '            Exit Sub
                    '        Else
                    '            CrearDS(Session("IDESTUDIO"), Session("IDENCUESTA"), Session("NUMEROTRABAJADOR"),
                    '            Session("IdNivel3"), NumPreg, Radio2.SelectedValue, "NA", True)
                    '        End If
                End If
                'ElseIf LIndicadorRespuesta.Text = 0 Then
                '    Dim CheckedItems As Integer = 0
                '    For Each li As ListItem In Checkbox1.Items
                '        If li.Selected Then
                '            CheckedItems = CheckedItems + 1
                '        End If
                '    Next
                '    If CheckedItems = 0 Then
                '        Lerror.Text = "Es necesario responder las preguntas para continuar el cuestionario."
                '        Exit Sub
                '    End If
            End If
            If LblPregunta3.Visible = True Then
                If LIndicadorRespuesta.Text = 1 Then
                    If Radio3.SelectedValue = "" Then
                        Lerror.Text = "Es necesario responder las preguntas para continuar el cuestionario."
                        Exit Sub
                    Else
                        CrearDS(Session("IDESTUDIO"), Session("IDENCUESTA"), Session("NUMEROTRABAJADOR"),
                                    Session("IdNivel3"), lblid3.Text, Radio3.SelectedValue, "NA", True)
                    End If
                    'ElseIf LIndicadorRespuesta.Text = 2 Then
                    '    If Radio3.SelectedValue = "" Then
                    '            Lerror.Text = "Es necesario responder las preguntas para continuar el cuestionario."
                    '            Exit Sub
                    '        Else
                    '            CrearDS(Session("IDESTUDIO"), Session("IDENCUESTA"), Session("NUMEROTRABAJADOR"),
                    '                    Session("IdNivel3"), NumPreg, Radio3.SelectedValue, "NA", True)
                    '        End If
                    'ElseIf LIndicadorRespuesta.Text = 0 Then
                    '    Dim CheckedItems As Integer = 0
                    '    For Each li As ListItem In Checkbox1.Items
                    '        If li.Selected Then
                    '            CheckedItems = CheckedItems + 1
                    '        End If
                    '    Next
                    '    If CheckedItems = 0 Then
                    '        Lerror.Text = "Es necesario responder las preguntas para continuar el cuestionario."
                    '        Exit Sub
                    '    End If
                    'End If
                End If

            End If
            If LblPregunta4.Visible = True Then
                If LIndicadorRespuesta.Text = 1 Then
                    If Radio4.SelectedValue = "" Then
                        Lerror.Text = "Es necesario responder las preguntas para continuar el cuestionario."
                        Exit Sub
                    Else
                        CrearDS(Session("IDESTUDIO"), Session("IDENCUESTA"), Session("NUMEROTRABAJADOR"),
                                Session("IdNivel3"), lblid4.Text, Radio4.SelectedValue, "NA", True)
                    End If
                    'ElseIf LIndicadorRespuesta.Text = 2 Then
                    '    If Radio4.SelectedValue = "" Then
                    '            Lerror.Text = "Es necesario responder las preguntas para continuar el cuestionario."
                    '            Exit Sub
                    '        Else
                    '            CrearDS(Session("IDESTUDIO"), Session("IDENCUESTA"), Session("NUMEROTRABAJADOR"),
                    '                    Session("IdNivel3"), NumPreg, Radio4.SelectedValue, "NA", True)
                    '        End If
                    'ElseIf LIndicadorRespuesta.Text = 0 Then
                    '    Dim CheckedItems As Integer = 0
                    '    For Each li As ListItem In Checkbox1.Items
                    '        If li.Selected Then
                    '            CheckedItems = CheckedItems + 1
                    '        End If
                    '    Next
                    '    If CheckedItems = 0 Then
                    '        Lerror.Text = "Es necesario responder las preguntas para continuar el cuestionario."
                    '        Exit Sub
                    '    End If
                End If
            End If
            If LblPregunta5.Visible = True Then
                If LIndicadorRespuesta.Text = 1 Then
                    If Radio5.SelectedValue = "" Then
                        Lerror.Text = "Es necesario responder las preguntas para continuar el cuestionario."
                        Exit Sub
                    Else
                        CrearDS(Session("IDESTUDIO"), Session("IDENCUESTA"), Session("NUMEROTRABAJADOR"),
                                Session("IdNivel3"), lblid5.Text, Radio5.SelectedValue, "NA", True)
                    End If
                    'ElseIf LIndicadorRespuesta.Text = 2 Then
                    '    If Radio5.SelectedValue = "" Then
                    '            Lerror.Text = "Es necesario responder las preguntas para continuar el cuestionario."
                    '            Exit Sub
                    '        Else
                    '            CrearDS(Session("IDESTUDIO"), Session("IDENCUESTA"), Session("NUMEROTRABAJADOR"),
                    '                    Session("IdNivel3"), NumPreg, Radio5.SelectedValue, "NA", True)
                    '        End If
                    'ElseIf LIndicadorRespuesta.Text = 0 Then
                    '    Dim CheckedItems As Integer = 0
                    '    For Each li As ListItem In Checkbox1.Items
                    '        If li.Selected Then
                    '            CheckedItems = CheckedItems + 1
                    '        End If
                    '    Next
                    '    If CheckedItems = 0 Then
                    '        Lerror.Text = "Es necesario responder las preguntas para continuar el cuestionario."
                    '        Exit Sub
                    '    End If
                End If
            End If

            If (Session("ContPreg") = CType(Session("PreguntasPorTema"), DataTable).Rows.Count) Then
                SaveData(Session("TblRespuestaPreguntas"), Session("IdTema"))
                Response.Redirect("S_EncuestaFin.aspx?XXXX=" & CStr(Request.Params("XXXX")) & "&ZZZZ=" & CStr(Request.Params("ZZZZ")) & "&Nivel=" & Session("IdNivel3"), False)
                Session("Abandono") = 1
            Else
                Session("Anterior") = 0
                Session("ContPreg") = CInt(Session("ContPreg")) + 1
                Session("ContTema") = CInt(Session("ContTema")) + 1
                BtnAnterior.Enabled = True
            End If

            Dim dv As DataView = DsGeneral.Tables(0).DefaultView
            Dim tblpreguntas As DataTable
            'Incremento de pregunta
            dv.RowFilter = "IdPregunta>" & Session("ContPreg")
            dv.Sort = "IdPregunta Asc"
            tblpreguntas = dv.ToTable()
            Session("PreguntasPorTema") = tblpreguntas
            Session("ContPreg") = tblpreguntas.Rows(0).Item(0)
            Session("CuentaPreguntas") = tblpreguntas.Rows(0).Item(6) - 1
            Dim TblPreg As DataTable = CType(Session("PreguntasPorTema"), DataTable)
            Dim cont As Integer = 0

            LimpiarPreguntas()

            For n As Integer = 0 To 4
                cont = cont + 1
                If cont <= TblPReg.Rows.Count Then
                    Session("ContPreg") = TblPReg.Rows(n).Item(0)
                    If cont = 1 Then
                        CargarPregunta(TblPReg.Rows(n).Item(0), cont)
                        LCount.Text = Session("ContPreg")
                    ElseIf cont = 2 Then
                        CargarPregunta(TblPReg.Rows(n).Item(0), cont)
                        LCount.Text = Session("ContPreg")
                    ElseIf cont = 3 Then
                        CargarPregunta(TblPReg.Rows(n).Item(0), cont)
                        LCount.Text = Session("ContPreg")
                    ElseIf cont = 4 Then
                        CargarPregunta(TblPReg.Rows(n).Item(0), cont)
                        LCount.Text = Session("ContPreg")
                    ElseIf cont = 5 Then
                        CargarPregunta(TblPReg.Rows(n).Item(0), cont)
                        LCount.Text = Session("ContPreg")
                    End If
                End If
            Next

        Catch ex As Exception
            Lerror.Text = "Problema: " & ex.Message & " Error: " & Err.Description & " Ubicacion: " & ex.StackTrace
        End Try
    End Sub

    Sub LimpiarPreguntas()
        LblPregunta1.Visible = False
        LblPregunta2.Visible = False
        LblPregunta3.Visible = False
        LblPregunta4.Visible = False
        LblPregunta5.Visible = False
        Radio1.Visible = False
        Radio2.Visible = False
        Radio3.Visible = False
        Radio4.Visible = False
        Radio5.Visible = False

    End Sub

    Protected Sub BTNANTERIOR_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnAnterior.Click
        Try
            'RbRespuesta2.Focus()
            Session("Anterior") = 1
            Session("ContTema") = CInt(Session("ContTema")) - 1
            Session("ContPreg") = CInt(Session("ContPreg")) - 1
            'CargarPregunta(CInt(Session("ContPreg")))
            Session("PregCont") = CInt((Session("PregCont")) - 1)

            If Session("ContPreg") = 2 Then
                If Session("NumeroTrabajadorValido") = "" Then
                Else
                    BtnAnterior.Enabled = False
                End If
            End If

            If Not Session("TblRespuestaPreguntas") Is Nothing Then
                Dim TablaTempo As New DataTable
                TablaTempo = Session("TblRespuestaPreguntas")
                respuesta = TablaTempo.Rows(TablaTempo.Rows.Count - 1)(5).ToString()
                TablaTempo.Rows.RemoveAt(TablaTempo.Rows.Count - 1)
            End If

        Catch ex As Exception
            Lerror.Text = "Problema: " & ex.Message & "Error: " & Err.Description & "Ubicacion: " & ex.StackTrace
            Lerror.Text = "Es necesario responder las preguntas para continuar con el cuestionario."
        End Try
    End Sub

    Sub CrearDS(ByVal CveEmpresa As Integer, ByVal CveEncuesta As Integer, ByVal NumEvaluador As String, ByVal NumEvaluado As Integer, ByVal CvePregunta As Integer, ByVal CveRespuesta As Integer, ByVal Comentario As String, ByVal Add As Boolean)

        Dim TablaTempo As New DataTable
        If Not Session("TblRespuestaPreguntas") Is Nothing Then
            TablaTempo = Session("TblRespuestaPreguntas")
        End If
        Dim RNew As DataRow
        RNew = TablaTempo.NewRow()
        If TablaTempo.Columns.Count = 0 Then
            TablaTempo.Columns.Add("IDESTUDIO")
            TablaTempo.Columns.Add("IDENCUESTA")
            TablaTempo.Columns.Add("NumEvaluador")
            TablaTempo.Columns.Add("IdNivel3")
            TablaTempo.Columns.Add("IDPREGUNTA")
            TablaTempo.Columns.Add("Respuesta")
            TablaTempo.Columns.Add("Comentario")
        End If

        RNew.Item(0) = CveEmpresa
        RNew.Item(1) = CveEncuesta
        RNew.Item(2) = NumEvaluador
        RNew.Item(3) = NumEvaluado
        RNew.Item(4) = CvePregunta
        RNew.Item(5) = CveRespuesta
        RNew.Item(6) = Comentario

        If Add = True Then
            TablaTempo.Rows.Add(RNew)
        Else
            If TablaTempo.Rows.Count > 0 Then
                TablaTempo.Rows.RemoveAt(TablaTempo.Rows.Count - 1)
            End If
        End If

        Session("TblRespuestaPreguntas") = Nothing
        Session("TblRespuestaPreguntas") = TablaTempo
    End Sub

    Sub SaveData(ByVal DT As DataTable, ByVal TemaActual As Integer)
        Try
            For i As Integer = 0 To DT.Rows.Count - 1
                With DT.Rows(i)
                    Dim P(7) As SqlParameter
                    P(0) = New SqlParameter("@TIPO", 12)
                    P(1) = New SqlParameter("@IDESTUDIO", Session("IDESTUDIO"))
                    P(2) = New SqlParameter("@IDENCUESTA", Session("IDENCUESTA"))
                    P(3) = New SqlParameter("@NUMTRABAJADOR", Session("NumeroTrabajadorValido"))
                    P(4) = New SqlParameter("@IDNIVEL3", Session("IDNIVEL3"))
                    P(5) = New SqlParameter("@IDPREGUNTA", .Item(4))
                    P(6) = New SqlParameter("@RESPUESTA", .Item(5))
                    P(7) = New SqlParameter("@COMENTARIO", .Item(6))
                    DatosBD.FuncionConPar("SP_Encuestas", P, Lerror.Text)
                End With
            Next
        Catch ex As Exception
            Lerror.Text = "Problema: " & ex.Message & " Ubicacion: " & ex.StackTrace
        End Try
    End Sub

End Class