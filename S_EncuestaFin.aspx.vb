Imports System.Data.SqlClient
Imports System.IO

Partial Public Class S_EncuestaFin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("UserConect") = 1 Then
                'Image1.ImageUrl = Session("Banner")
                form1.Attributes.Add("background", Session("Background"))
                BCerrar.Attributes.Add("onclick", "window.close()")

                Dim DS As New DataSet
                Dim P(1) As SqlParameter
                P(0) = New SqlParameter("@TIPO", 16)
                P(1) = New SqlParameter("@IDESTUDIO", Session("IDESTUDIO"))
                DS = DatosBD.FuncionConPar("SP_Encuestas", P, Lerror.Text)

                LTitulo.Text = DS.Tables(0).Rows(0).Item(0)
                LInstruccion1.Text = DS.Tables(0).Rows(1).Item(0)
                LInstruccion2.Text = DS.Tables(0).Rows(2).Item(0)
                LInstruccion3.Text = DS.Tables(0).Rows(3).Item(0)
                LInstruccion4.Text = DS.Tables(0).Rows(4).Item(0)
                LInstruccion5.Text = DS.Tables(0).Rows(5).Item(0)
            End If

        Else
            Session.Abandon()
            GC.Collect()
            LiberarRAM()
            'Response.Redirect("Inicio.aspx?XXXX=CF6EA552B4632E34&YYYY=AC1EBBE69AA27714&ZZZZ=CF6EA552B4632E34")

        End If
    End Sub

    Protected Sub BCerrar_Click(sender As Object, e As EventArgs) Handles BCerrar.Click
        Session.Abandon()
        GC.Collect()
        LiberarRAM()

        Response.Redirect("Inicio.aspx?XXXX=" & CStr(Request.Params("XXXX")) & "&YYYY=" & CStr(Request.Params("YYYY")) & "&ZZZZ=" & CStr(Request.Params("ZZZZ")), False)

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

End Class