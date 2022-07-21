Imports System.Data.SqlClient

Public Class Inicio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then
                If Not Request.Params("XXXX") Is Nothing Then
                    Session("IDESTUDIO") = Seguridad.Decriptar(CStr(Request.Params("XXXX")), "DICOYES")
                    Session("IDEncuesta") = Seguridad.Decriptar(CStr(Request.Params("YYYY")), "DICOYES")
                    Session("CveUsuario") = Seguridad.Decriptar(CStr(Request.Params("ZZZZ")), "DICOYES")

                    Try
                        Dim DS As New DataSet
                        Dim P(2) As SqlParameter
                        P(0) = New SqlParameter("@TIPO", 9)
                        P(1) = New SqlParameter("@IDESTUDIO", Session("IDESTUDIO"))
                        P(2) = New SqlParameter("@NUMTRABAJADOR", Session("CveUsuario"))
                        DS = DatosBD.FuncionConPar("SP_Encuestas", P, Lerror.Text)
                        Session("TIPO_ENCUESTAS") = DS.Tables(2).Rows(0).Item(0)

                        If Not DS Is Nothing Then
                            If DS.Tables(0).Rows.Count > 0 Then
                                If DS.Tables(0).Rows(0).Item(0) < 1 Then
                                    'error de datos
                                    RadWindowManager1.RadAlert(DS.Tables(0).Rows(0).Item(1), 330, 180, "Aviso", "", "null")
                                Else
                                    'NUMERO DE USUARIO
                                    Session("NumEvaluador") = DS.Tables(0).Rows(0).Item("NumTrabajador")
                                    Session("UserConect") = 1
                                    'CARGAR COMBO BOX
                                    RadListBox1.DataSource = DS.Tables(3)
                                    RadListBox1.DataTextField = "NomEncuesta"
                                    RadListBox1.DataValueField = "IDENCUESTA"
                                    RadListBox1.DataBind()

                                    For n As Integer = 0 To DS.Tables(4).Rows.Count - 1
                                        If DS.Tables(4).Rows(n).Item(3) = 1 Then 'Estatus 1
                                            RadListBox1.FindItemByValue(DS.Tables(4).Rows(n).Item(2)).Enabled = False
                                        End If
                                    Next

                                    'CARGAR TITULOS
                                    lblTitulo.Text = DS.Tables(5).Rows(0).Item(1)
                                    Label1.Text = DS.Tables(5).Rows(1).Item(1)
                                    Label2.Text = DS.Tables(5).Rows(2).Item(1)
                                    Label3.Text = DS.Tables(5).Rows(3).Item(1)
                                    Label4.Text = DS.Tables(5).Rows(4).Item(1)
                                    Label5.Text = DS.Tables(5).Rows(5).Item(1)
                                    Label6.Text = DS.Tables(5).Rows(6).Item(1)
                                    Label7.Text = DS.Tables(5).Rows(7).Item(1)
                                End If
                            Else
                                RadWindowManager1.RadAlert("No existe Información para continuar.", 330, 180, "Aviso", "", "null")
                            End If
                        End If
                    Catch ex As Exception
                        RadWindowManager1.RadAlert(ex.Message, 330, 180, "Aviso", "", "null")
                    End Try
                Else
                    RadWindowManager1.RadAlert("No existe Información para continuar.", 330, 180, "Aviso", "", "null")
                End If
            End If
        Catch ex As Exception
            Lerror.Text = ex.Message
        End Try

        GC.Collect()
        LiberarRAM()
    End Sub

    Protected Sub BCERRAR_Click(sender As Object, e As EventArgs) Handles BCerrar.Click
        Session.Abandon()
    End Sub

    Protected Sub RadListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadListBox1.SelectedIndexChanged
        Session("IDENCUESTA") = RadListBox1.SelectedValue
        Response.Redirect("Encuesta.aspx?XXXX=" & CStr(Request.Params("XXXX")) & "&YYYY=" & RadListBox1.SelectedValue & "&ZZZZ=" & CStr(Request.Params("ZZZZ")), False)
    End Sub

    Sub Mensajes()
        Dim ds As DataSet = CType(Session("DSMensajes"), DataSet)
        lblTitulo.Text = ds.Tables(0).Rows(0).Item(1)
        Label1.Text = ds.Tables(0).Rows(1).Item(1)
        Label2.Text = ds.Tables(0).Rows(2).Item(1)
        Label3.Text = ds.Tables(0).Rows(4).Item(1)
        Label4.Text = ds.Tables(0).Rows(5).Item(1)
        Label5.Text = ds.Tables(0).Rows(6).Item(1)
        Label6.Text = ds.Tables(0).Rows(7).Item(1)
        Label7.Text = ds.Tables(0).Rows(8).Item(1)
    End Sub

    Sub CargarMenu()
        Dim DS As DataSet
        Dim Par(2) As SqlParameter
        Par(0) = New SqlParameter("@TIPO", 1)
        Par(1) = New SqlParameter("@IDESTUDIO", Session("IDESTUDIO"))
        Par(2) = New SqlParameter("@NUMTRABAJADOR", Session("CveUsuario"))
        DS = DatosBD.FuncionConPar("SP_Encuestas", Par, Lerror.Text)

        RadListBox1.DataSource = DS.Tables(2)
        RadListBox1.DataTextField = "NomEncuesta"
        RadListBox1.DataValueField = "IDENCUESTA"
        RadListBox1.DataBind()

        For n As Integer = 0 To DS.Tables(3).Rows.Count - 1
            If DS.Tables(1).Rows(n).Item(4) = 1 Then 'Estatus 1
                RadListBox1.FindItemByValue(DS.Tables(1).Rows(n).Item(2)).Enabled = False
            End If
        Next
    End Sub

    Private Declare Auto Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal procHandle As IntPtr, ByVal min As Int32, ByVal max As Int32) As Boolean

    Public Sub LiberarRAM()

        Try
            Dim MiProceso As Process
            MiProceso = Process.GetCurrentProcess()
            SetProcessWorkingSetSize(MiProceso.Handle, -1, -1)

        Catch ex As Exception

        End Try

    End Sub

End Class