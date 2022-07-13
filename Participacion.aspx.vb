Imports System.Data.SqlClient
Imports System.IO
Imports Telerik.Web.UI

Partial Public Class Participacion
    Inherits System.Web.UI.Page

    Dim CON, EVAL As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then
                If Not Request.Params("XXXX") Is Nothing Then

                    Session("IdEstudio") = Seguridad.Decriptar(CStr(Request.Params("XXXX")), "DICOYES")

                    Dim pload(1) As SqlParameter
                    pload(0) = New SqlParameter("@TIPO", 1)
                    pload(1) = New SqlParameter("@IDESTUDIO", Session("IdEstudio"))
                    Dim Dset As DataSet = DatosBD.FuncionConPar("SP_Participacion", pload, Lerror.Text)

                    Dim tabla As DataTable
                    tabla = Dset.Tables(0)
                    Session("Encuestados") = Dset.Tables(0)

                    GridParticipacion.DataSource = tabla
                    GridParticipacion.DataBind()

                    textEstudio_1.InnerText = Dset.Tables(1).Rows(0).Item(0)
                End If

            Else

            End If
        Catch ex As Exception
            Lerror.Text = ex.Message
        End Try
        Session.Abandon()
        GC.Collect()
        LiberarRAM()
    End Sub

    Protected Sub BCerrar_Click(sender As Object, e As EventArgs) Handles BCerrar.Click
        Session.Abandon()
        GC.Collect()
        LiberarRAM()
        Response.Redirect("Inicio.aspx", False)
    End Sub

    Private Declare Auto Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal procHandle As IntPtr, ByVal min As Int32, ByVal max As Int32) As Boolean

    Public Sub LiberarRAM()
        Try
            Dim MiProceso As Process
            MiProceso = Process.GetCurrentProcess()
            SetProcessWorkingSetSize(MiProceso.Handle, -1, -1)
        Catch ex As Exception
            Lerror.Text = ex.Message
        End Try
    End Sub

    Private Sub GridParticipacion_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles GridParticipacion.ItemCommand
        Try
            If e.CommandName = "Editar" Then

            ElseIf e.CommandName = "Excel" Then
                GridParticipacion.ExportSettings.ExportOnlyData = True
                GridParticipacion.ExportSettings.OpenInNewWindow = True
                GridParticipacion.MasterTableView.ExportToExcel()

            End If
        Catch ex As Exception
            Lerror.Text = ex.Message
        End Try
    End Sub

    Private Sub GridParticipacion_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles GridParticipacion.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem OrElse e.Item.ItemType = GridItemType.Item Then
            CON = CON + e.Item.Cells(4).Text
            EVAL = EVAL + e.Item.Cells(5).Text
        ElseIf e.Item.ItemType = GridItemType.Footer Then
            e.Item.Cells(3).Text = "Total: "
            e.Item.Cells(4).Text = CON
            e.Item.Cells(5).Text = EVAL
        End If
    End Sub
End Class