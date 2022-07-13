Imports System.Data.SqlClient
Imports System.Globalization
Partial Public Class S_Encuesta
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

                BTNSIGUIENTE.Focus()
                'Cuenta el numero de pregunta en la que se esta trabajando.
                Session("ContPreg") = 1
                Session("ContTema") = 1

                Try
                    Session("IdEncuesta") = 7
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
                        Dim dv As DataView = DsGeneral.Tables(0).DefaultView

                        Dim TblPReg As DataTable
                        Session("IdTema") = 1
                        dv.Sort = "IdPregunta Asc"
                        TblPReg = dv.ToTable()
                        Session("PreguntasPorTema") = TblPReg 'obtiene las  preguntas del tema actual

                        CargarPregunta(1)
                        Session("ContPreg") = 1
                        dv.RowFilter = "IdTema<=" & Session("IdTema") - 1
                        dv.Sort = "IdPregunta Asc"
                        TblPReg = dv.ToTable()
                        Session("PregCont") = TblPReg.Rows.Count
                        TblPReg.Dispose()

                        If Session("ContPreg") = 1 Then
                            If Session("NumeroTrabajadorValido") = "" Then

                            Else
                                CrearDS(Session("IDESTUDIO"), Session("IDENCUESTA"), Session("NUMEROTRABAJADOR"), Session("IdNivel3"), 1, 0,
                                        Session("NumeroTrabajadorValido"), True)
                                Session("ContPreg") = CInt(Session("ContPreg")) + 1
                                Session("ContTema") = CInt(Session("ContTema")) + 1
                                CargarPregunta(CInt(Session("ContPreg")))
                                TexPreguntaAbierta.Text = ""
                                Session("Regresar") = 0
                            End If
                        End If

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

    Sub CargarPregunta(ByVal IdexPreg As Integer)

        Try
            Dim Tabla As DataTable = CType(Session("PreguntasPorTema"), DataTable)

            LTema1.Text = Tabla.Rows(IdexPreg - 1).Item(2)
            LBLPREGUNTA.Text = Tabla.Rows(IdexPreg - 1).Item(3)
            LMideSatisfaccion.Text = Tabla.Rows(IdexPreg - 1).Item(5) 'MideSatisfaccion
            LIndicadorRespuesta.Text = Tabla.Rows(IdexPreg - 1).Item(6) 'IndicadorRespuestaDada
            LComplemento.Text = Tabla.Rows(IdexPreg - 1).Item(9) 'Complemento
            LPilaPregunta.Text = Tabla.Rows(IdexPreg - 1).Item(10) 'PILAPREGUNTA
            RbRespuesta2.Visible = False
            ChkRespuesta.Visible = False
            RComboRespuesta1.Visible = False
            TexPreguntaAbierta.Visible = False

            If LPilaPregunta.Text = "-2" Then
                If Session("Anterior") = 1 Then
                    If Session("AtencionClientes") = "Si" Then
                    Else
                        Session("ContPreg") = CInt(Session("ContPreg")) - 1
                        Session("ContTema") = CInt(Session("ContTema")) - 1
                        IdexPreg = Session("ContPreg")
                        CargarPregunta(CInt(Session("ContPreg")))
                    End If
                Else
                    If Session("AtencionClientes") = "No" Then
                        Session("ContPreg") = CInt(Session("ContPreg")) + 1
                        Session("ContTema") = CInt(Session("ContTema")) + 1
                        IdexPreg = Session("ContPreg")
                        CargarPregunta(CInt(Session("ContPreg")))
                        Exit Sub
                    End If
                End If
            ElseIf LPilaPregunta.Text = "-3" Then
                If Session("Anterior") = 1 Then
                    If Session("Jefe") = "Si" Then
                    Else
                        Session("ContPreg") = CInt(Session("ContPreg")) - 1
                        Session("ContTema") = CInt(Session("ContTema")) - 1
                        IdexPreg = Session("ContPreg")
                        CargarPregunta(CInt(Session("ContPreg")))
                    End If
                Else
                    If Session("Jefe") = "No" Then
                        If (Session("ContPreg") = CType(Session("PreguntasPorTema"), DataTable).Rows.Count) Then
                            SaveData(Session("TblRespuestaPreguntas"), Session("IdTema"))
                            Response.Redirect("S_EncuestaFin.aspx?XXXX=" & CStr(Request.Params("XXXX")) & "&ZZZZ=" & CStr(Request.Params("ZZZZ")) & "&Nivel=" & Session("IdNivel3"), False)
                            Session("Abandono") = 1
                        Else
                            Session("ContPreg") = CInt(Session("ContPreg")) + 1
                            Session("ContTema") = CInt(Session("ContTema")) + 1
                            IdexPreg = Session("ContPreg")
                            CargarPregunta(CInt(Session("ContPreg")))
                            Exit Sub
                        End If
                    End If
                End If
            ElseIf LPilaPregunta.Text = "-4" Then
                If Session("Anterior") = 1 Then
                    If Session("REGLA1") = "Si" Then
                    Else
                        Session("ContPreg") = CInt(Session("ContPreg")) - 1
                        Session("ContTema") = CInt(Session("ContTema")) - 1
                        IdexPreg = Session("ContPreg")
                        CargarPregunta(CInt(Session("ContPreg")))
                    End If
                Else
                    If Session("REGLA1") = "No" Then
                        Session("ContPreg") = CInt(Session("ContPreg")) + 1
                        Session("ContTema") = CInt(Session("ContTema")) + 1
                        IdexPreg = Session("ContPreg")
                        CargarPregunta(CInt(Session("ContPreg")))
                        Exit Sub
                    End If
                End If
            End If

            If Tabla.Rows(IdexPreg - 1).Item(4) = 999 Then 'RESPUESTA ABIERTA
                TexPreguntaAbierta.Text = ""
                TexPreguntaAbierta.Visible = True
                TexPreguntaAbierta.Focus()
            ElseIf Tabla.Rows(IdexPreg - 1).Item(4) = 998 Then 'RESPUESTA ABIERTA NUMERO
                RadNumericTextBox1.Text = ""
                RadNumericTextBox1.Visible = True
                RadNumericTextBox1.Focus()
            Else
                CargarRespuesta(Tabla.Rows(IdexPreg - 1).Item(4)) 'TIPO DE RESPUESTA
                If LComplemento.Text = 1 Then
                    TexPreguntaAbierta.Text = ""
                    TexPreguntaAbierta.Visible = True
                    TexPreguntaAbierta.Focus()
                End If
            End If

            LCount.Text = Tabla.Rows.Count
            LCuestionario1.Text = "Pregunta : " & (Session("ContTema") - 1) & " de " & (LCount.Text - 1)

            If Tabla.Rows(IdexPreg - 1).Item(7) <> "" Then
                LTexto.Text = Tabla.Rows(IdexPreg - 1).Item(7)
                LTexto.Visible = True
            Else
                LTexto.Text = ""
                LTexto.Visible = False
            End If

        Catch ex As Exception
            Lerror.Text = "Problema: " & ex.Message & "Error: " & Err.Description & "Ubicacion: " & ex.StackTrace
        End Try

    End Sub

    Sub CargarRespuesta(ByVal CveRespuesta As Integer)
        Try
            Lerror.Text = ""

            Dim DSRespuestas As DataSet
            Dim PLoad(1) As SqlParameter
            PLoad(0) = New SqlParameter("@TIPO", 6)
            PLoad(1) = New SqlParameter("@IDRESPUESTA", CveRespuesta)
            DSRespuestas = DatosBD.FuncionConPar("SP_Encuestas", PLoad, Lerror.Text)

            RbRespuesta2.Items.Clear()
            ChkRespuesta.Items.Clear()
            RComboRespuesta1.Items.Clear()

            If Lerror.Text.Length = 0 Then
                    If Not DSRespuestas Is Nothing Then
                    If LIndicadorRespuesta.Text = 2 Then 'combobox
                        RComboRespuesta1.DataSource = DSRespuestas.Tables(0)
                        RComboRespuesta1.DataTextField = "DescRespuesta"
                        RComboRespuesta1.DataValueField = "OrdenRespuesta"
                        RComboRespuesta1.DataBind()
                        RComboRespuesta1.Visible = True
                    ElseIf LIndicadorRespuesta.Text = 1 Then 'radiobutton
                        RbRespuesta2.DataSource = DSRespuestas.Tables(0)
                        RbRespuesta2.DataTextField = "DescRespuesta"
                        RbRespuesta2.DataValueField = "OrdenRespuesta"
                        RbRespuesta2.DataBind()
                        RbRespuesta2.Visible = True
                    ElseIf LIndicadorRespuesta.Text = 0 Then 'checkbox
                        ChkRespuesta.DataSource = DSRespuestas.Tables(0)
                        ChkRespuesta.DataTextField = "DescRespuesta"
                        ChkRespuesta.DataValueField = "OrdenRespuesta"
                        ChkRespuesta.DataBind()
                        ChkRespuesta.Visible = True
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

            If LIndicadorRespuesta.Text = 0 Then
                If ChkRespuesta.Visible = False Then
                    respuesta = 0

                    If TexPreguntaAbierta.Text.Trim = "" Then
                        Lerror.Text = "Es necesario responder las preguntas para continuar el cuestionario."
                        Exit Sub
                    End If
                Else
                    Dim CheckedItems As Integer = 0
                    For Each li As ListItem In ChkRespuesta.Items
                        If li.Selected Then
                            CheckedItems = CheckedItems + 1
                        End If
                    Next

                    If CheckedItems = 0 Then
                        If Session("IdiomaIngles") = "Y" Then
                            Lerror.Text = "Es necesario responder las preguntas para continuar el cuestionario."
                        End If
                        Exit Sub
                    End If
                End If

                If TexPreguntaAbierta.Text = "" Then
                    TexPreguntaAbierta.Text = "NO APLICA"
                End If

                If ChkRespuesta.Visible = True Then
                    ChkRespuesta.Focus()
                Else
                    TexPreguntaAbierta.Focus()
                End If

                'GRABADO TEMPORAL DE LA  RESPUESTA
                Dim RowId = Session("ContPreg")
                Dim Tabla As DataTable = CType(Session("PreguntasPorTema"), DataTable)
                Dim NumPreg As Integer = Tabla.Rows(RowId - 1).Item(0)

                For Each li As ListItem In ChkRespuesta.Items
                    If li.Selected Then
                        CrearDS(Session("IDESTUDIO"), Session("IDENCUESTA"), Session("NUMEROTRABAJADOR"), Session("IdNivel3"), NumPreg, li.Value,
                                TexPreguntaAbierta.Text.ToUpper, True)
                    End If
                Next
            Else
                If RComboRespuesta1.Visible = True Then
                    respuesta = RComboRespuesta1.SelectedValue
                    LValor.Text = RComboRespuesta1.SelectedValue
                    RComboRespuesta1.Visible = False

                ElseIf RbRespuesta2.Visible = False Then
                    respuesta = 0

                    If TexPreguntaAbierta.Text.Trim = "" Then
                        Lerror.Text = "Es necesario responder las preguntas para continuar el cuestionario."
                        Exit Sub
                    End If

                Else
                    If RbRespuesta2.SelectedValue = "" Then
                        Lerror.Text = "Es necesario responder las preguntas para continuar con el cuestionario."
                        Exit Sub
                    Else
                        respuesta = RbRespuesta2.SelectedValue
                        LValor.Text = RbRespuesta2.SelectedValue
                    End If
                End If

                If LPilaPregunta.Text = "2" Then
                    If RbRespuesta2.SelectedValue = 1 Then
                        Session("AtencionClientes") = "Si"
                    Else
                        Session("AtencionClientes") = "No"
                    End If
                ElseIf LPilaPregunta.Text = "3" Then
                    If RbRespuesta2.SelectedValue = 1 Then
                        Session("Jefe") = "Si"
                    Else
                        Session("Jefe") = "No"
                    End If
                ElseIf LPilaPregunta.Text = "4" Then
                    If RbRespuesta2.SelectedValue = 1 Then
                        Session("REGLA1") = "Si"
                    Else
                        Session("REGLA1") = "No"
                    End If
                End If

                'GRABADO TEMPORAL DE LA  RESPUESTA
                Dim RowId = Session("ContPreg")
                Dim Tabla As DataTable = CType(Session("PreguntasPorTema"), DataTable)
                Dim NumPreg As Integer = Tabla.Rows(RowId - 1).Item(0)

                CrearDS(Session("IDESTUDIO"), Session("IDENCUESTA"), Session("NUMEROTRABAJADOR"), Session("IdNivel3"), NumPreg, respuesta, TexPreguntaAbierta.Text.ToUpper, True)

            End If

            If (Session("ContPreg") = CType(Session("PreguntasPorTema"), DataTable).Rows.Count) Then
                SaveData(Session("TblRespuestaPreguntas"), Session("IdTema"))
                Response.Redirect("S_EncuestaFin.aspx?XXXX=" & CStr(Request.Params("XXXX")) & "&ZZZZ=" & CStr(Request.Params("ZZZZ")) & "&Nivel=" & Session("IdNivel3"), False)
                Session("Abandono") = 1
            Else
                Session("Anterior") = 0
                Session("ContPreg") = CInt(Session("ContPreg")) + 1
                Session("ContTema") = CInt(Session("ContTema")) + 1
                CargarPregunta(CInt(Session("ContPreg")))
                TexPreguntaAbierta.Text = ""
                BtnAnterior.Enabled = True
            End If

        Catch ex As Exception
            Lerror.Text = "Problema: " & ex.Message & " Error: " & Err.Description & " Ubicacion: " & ex.StackTrace
        End Try
    End Sub

    Protected Sub BTNANTERIOR_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnAnterior.Click

        Try
            RbRespuesta2.Focus()

            Session("Anterior") = 1
            Session("ContTema") = CInt(Session("ContTema")) - 1
            Session("ContPreg") = CInt(Session("ContPreg")) - 1
            CargarPregunta(CInt(Session("ContPreg")))
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
                RbRespuesta2.SelectedValue = respuesta
                TablaTempo.Rows.RemoveAt(TablaTempo.Rows.Count - 1)
            End If

            'PERMITE HABILITAR/DESHABILITAR EL BOTON ANTERIOR
            If CInt(Session("ContTema")) = 1 Then
                BtnAnterior.Enabled = False
            ElseIf Session("ContPreg") = 2 Then
                If Session("NumeroTrabajadorValido") = "" Then
                Else
                    BtnAnterior.Enabled = False
                End If
            ElseIf Session("ContTema") = LCount.Text - 1 Then
            Else
                BtnAnterior.Enabled = True
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