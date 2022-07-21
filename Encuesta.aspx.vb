Imports System.Data.SqlClient

Partial Public Class Encuesta
    Inherits System.Web.UI.Page
    Dim respuesta As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            PageBody.Attributes.Add("background", Session("Background"))
            Try
                If Not Request.Params("XXXX") Is Nothing Then
                    Session("IDESTUDIO") = Seguridad.Decriptar(CStr(Request.Params("XXXX")), "DICOYES")
                    'Session("IdEncuesta") = Seguridad.Decriptar(CStr(Request.Params("YYYY")), "DICOYES")
                    Session("CveUsuario") = Seguridad.Decriptar(CStr(Request.Params("ZZZZ")), "DICOYES")
                Else
                    RadWindowManager1.RadAlert("No existe Información para continuar.", 330, 180, "Aviso", "", "null")
                End If

                LTexto.Text = "Ingresa tu número o ID de empleado(a):"
            Catch ex As Exception
                Lerror.Text = "Problema: " & ex.Message & " Error: " & Err.Description & " Ubicacion: " & ex.StackTrace
                Err.Clear()
            End Try
        End If
    End Sub

    Private Sub Btn_Buscar_ServerClick(sender As Object, e As EventArgs) Handles Btn_Buscar.ServerClick
        If txtNumero.Text = "" Then
            RadWindowManager1.RadAlert("Favor de escribir su numero de empleado", 330, 180, "Aviso", "", "null")
        Else
            Try
                Dim P(2) As SqlParameter
                P(0) = New SqlParameter("@TIPO", 10)
                P(1) = New SqlParameter("@IDESTUDIO", Session("IDESTUDIO"))
                P(2) = New SqlParameter("@NUMTRABAJADOR", txtNumero.Text)
                Dim DS As DataSet
                DS = DatosBD.FuncionConPar("SP_Encuestas", P, Lerror.Text)

                If DS.Tables(0).Rows(0).Item(0) = "OK" Then
                    If Session("TIPO_ENCUESTAS") = 1 Then
                        Session("NUMEROPERSONAL") = txtNumero.Text
                        Response.Redirect("S_EncuestaSeccion.aspx?XXXX=" & CStr(Request.Params("XXXX")) & "&YYYY=" & Session("IdEncuesta") & "&ZZZZ=" & CStr(Request.Params("ZZZZ")), False)
                    ElseIf Session("TIPO_ENCUESTAS") = 2 Then
                        Session("NUMEROPERSONAL") = txtNumero.Text
                        Response.Redirect("Politicas.aspx?XXXX=" & CStr(Request.Params("XXXX")) & "&YYYY=" & Session("IdEncuesta") & "&ZZZZ=" & CStr(Request.Params("ZZZZ")), False)
                    ElseIf Session("TIPO_ENCUESTAS") = 3 Then
                        Session("NUMEROPERSONAL") = txtNumero.Text
                        Response.Redirect("Nom030.aspx?XXXX=" & CStr(Request.Params("XXXX")) & "&YYYY=" & Session("IdEncuesta") & "&ZZZZ=" & CStr(Request.Params("ZZZZ")), False)
                    ElseIf Session("TIPO_ENCUESTAS") = 4 Then
                        Session("NUMEROPERSONAL") = txtNumero.Text
                        Response.Redirect("S_EncuestaALL.aspx?XXXX=" & CStr(Request.Params("XXXX")) & "&YYYY=" & Session("IdEncuesta") & "&ZZZZ=" & CStr(Request.Params("ZZZZ")), False)
                    End If
                    Session("NumeroTrabajadorValido") = txtNumero.Text
                ElseIf DS.Tables(0).Rows(0).Item(0) = "YA" Then
                    RadWindowManager1.RadAlert("El número de empleado que capturaste, ya realizó la encuesta", 330, 180, "Aviso", "", "null")
                ElseIf DS.Tables(0).Rows(0).Item(0) = "NODATA" Then
                    RadWindowManager1.RadAlert("Revisa que estés ingresando correctamente tu ID o Número de empleado (a)", 330, 180, "Aviso", "", "null")
                Else
                    RadWindowManager1.RadAlert("No existe información para continuar.", 330, 180, "Aviso", "", "null")
                End If

            Catch ex As Exception
                Lerror.Text = "Favor de contactar al administrador"
            End Try
        End If

    End Sub
End Class