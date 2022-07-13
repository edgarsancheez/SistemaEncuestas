Imports System.Data.SqlClient
Imports System.IO
Imports Telerik.Web.UI

Partial Public Class Admin
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then
                Dim DS As New DataSet
                Dim P(0) As SqlParameter
                P(0) = New SqlParameter("@TIPO", 17)
                DS = DatosBD.FuncionConPar("SP_Encuestas", P, Lerror.Text)
                RcbEstudio.DataSource = DS.Tables(0)
                RcbEstudio.DataTextField = "NomEstudio"
                RcbEstudio.DataValueField = "IdEstudio"
                RcbEstudio.DataBind()

                RcbEncuesta.DataSource = DS.Tables(1)
                RcbEncuesta.DataTextField = "NomEncuesta"
                RcbEncuesta.DataValueField = "IDENCUESTA"
                RcbEncuesta.DataBind()
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
    Protected Sub Btn_Crear_Click(sender As Object, e As EventArgs) Handles Btn_Crear.Click
        Try
            Dim Link As String
            Dim SecEstudio As String
            Dim SecEncuesta As String
            Dim Numtrabajador As String

            SecEstudio = Encriptar(RcbEstudio.SelectedValue, "DICOYES") 'Se encripta la empresa
            SecEncuesta = Encriptar(RcbEncuesta.SelectedValue, "DICOYES") 'Se encripta la encuesta
            Numtrabajador = Encriptar(Textbox1.Text, "DICOYES") 'Se encripta EL NUMERO DE TRABAJADOR

            Link = "https://evasurvey.com/Inicio.aspx?XXXX=" & SecEstudio & "&YYYY=" & SecEncuesta & "&ZZZZ=" & Numtrabajador

            textlink.Text = Link
        Catch ex As Exception
            Lerror.Text = ex.Message
        End Try
    End Sub

    Public Function Encriptar(ByVal EncryptText As String, ByVal KeyEncode As String) As String
        Crypto.EncryptionAlgorithm = 7 'Model DAS
        Crypto.Encoding = Crypto.EncodingType.HEX
        Crypto.Key = KeyEncode
        Dim Valor As String
        If Crypto.EncryptString(EncryptText) Then
            Valor = Crypto.Content
        Else
            Valor = Crypto.CryptoException.Message
        End If
        Crypto.Clear()
        Return Valor
    End Function
End Class