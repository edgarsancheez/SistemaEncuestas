Imports System.IO
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports NativeExcel
Imports System.Configuration.ConfigurationManager
Imports System.Configuration
Imports Telerik.Web.UI

Public Class DatosBD
    Public Shared Function FuncionSinPar(ByVal sentencia As String, ByRef msjerr As String) As Data.DataSet
        Dim con As New SqlConnection
        Try
            'funbcion sin parametros
            Dim comando As New SqlCommand
            Dim adap As New SqlDataAdapter
            Dim dset As New DataSet
            con.ConnectionString = AppSettings("CONN") ' ConfigurationManager.ConnectionStrings("CONN").ConnectionString '"Data Source=MTYSQLVS02\SQL2;Initial Catalog=Procoli;Persist Security Info=True;User ID=csprocoli;Password=csprocoli"
            con.Open()
            comando.Connection = con
            comando.CommandType = CommandType.StoredProcedure
            comando.CommandText = sentencia
            adap.SelectCommand = comando
            adap.Fill(dset)
            Return dset
        Catch ex As Exception
            msjerr = ex.Message
        Finally
            con.Close()
        End Try
    End Function
    Public Shared Function FuncionConPar(ByVal sentencia As String, ByVal param() As SqlParameter, ByRef msjerr As String, ByVal NomTabla As String) As Data.DataSet
        Dim con As New SqlConnection
        Try
            'funcion conparametros
            Dim comando As New SqlCommand
            Dim adap As New SqlDataAdapter
            Dim dset As New DataSet
            con.ConnectionString = AppSettings("CONN") 'ConfigurationManager.ConnectionStrings("CONN").ConnectionString
            con.Open()
            ' con.ConnectionTimeout = 0
            comando.Connection = con
            comando.CommandType = CommandType.StoredProcedure
            comando.CommandText = sentencia

            For i As Integer = 0 To param.Length - 1
                comando.Parameters.Add(param(i))
            Next
            adap.SelectCommand = comando
            adap.Fill(dset, NomTabla)
            Return dset
        Catch ex As SqlException
            msjerr = ex.Message
        Catch ex As Exception
            msjerr = ex.Message
        Finally
            con.Close()
        End Try

    End Function
    Public Shared Function FuncionConPar(ByVal sentencia As String, ByVal param() As SqlParameter, ByRef msjerr As String) As Data.DataSet
        Dim con As New SqlConnection
        Try
            'funcion conparametros
            Dim comando As New SqlCommand
            Dim adap As New SqlDataAdapter
            Dim dset As New DataSet
            con.ConnectionString = AppSettings("CONN") 'ConfigurationManager.ConnectionStrings("CONN").ConnectionString
            con.Open()
            comando.CommandTimeout = 0
            comando.Connection = con
            comando.CommandType = CommandType.StoredProcedure
            comando.CommandText = sentencia
            For i As Integer = 0 To param.Length - 1
                comando.Parameters.Add(param(i))
            Next
            adap.SelectCommand = comando
            adap.Fill(dset)
            Return dset
        Catch ex As SqlException
            msjerr = ex.Message
        Catch ex As Exception
            msjerr = ex.Message
        Finally
            con.Close()
        End Try

    End Function

    Public Shared Function FuncionConPar2(ByVal sentencia As String, ByVal param() As SqlParameter, ByRef msjerr As String) As SqlDataAdapter
        Dim con As New SqlConnection
        Try
            'funcion conparametros
            Dim comando As New SqlCommand
            Dim adap As New SqlDataAdapter
            Dim dset As New DataSet
            con.ConnectionString = AppSettings("CONN") 'ConfigurationManager.ConnectionStrings("CONN").ConnectionString
            con.Open()
            comando.Connection = con
            comando.CommandType = CommandType.StoredProcedure
            comando.CommandText = sentencia
            For i As Integer = 0 To param.Length - 1
                comando.Parameters.Add(param(i))
            Next
            adap.SelectCommand = comando
            adap.Fill(dset)
            Return adap
        Catch ex As SqlException
            msjerr = ex.Message
        Catch ex As Exception
            msjerr = ex.Message
        Finally
            con.Close()
        End Try

    End Function
    Public Shared Function FuncionTXT(ByVal sentencia As String, ByRef msjerr As String) As Data.DataSet
        Dim con As New SqlConnection
        Try
            'funbcion sin parametros
            Dim comando As New SqlCommand
            Dim adap As New SqlDataAdapter
            Dim dset As New DataSet
            con.ConnectionString = AppSettings("CONN") 'ConfigurationManager.ConnectionStrings("CONN").ConnectionString
            con.Open()
            comando.Connection = con
            comando.CommandType = CommandType.Text
            comando.CommandText = sentencia
            adap.SelectCommand = comando
            adap.Fill(dset)
            Return dset
        Catch ex As Exception
            msjerr = ex.Message
        Finally
            con.Close()
        End Try
    End Function
    Public Shared Sub ProcedimientoConPar(ByVal sentencia As String, ByVal param() As SqlParameter, ByRef msjerr As String)
        Dim con As New SqlConnection
        Try
            'procedimiento con parametros
            Dim comando As New SqlCommand
            con.ConnectionString = AppSettings("CONN") 'ConfigurationManager.ConnectionStrings("CONN").ConnectionString
            con.Open()
            comando.Connection = con
            comando.CommandType = CommandType.StoredProcedure
            comando.CommandText = sentencia
            If param.Length = 0 Then
                comando.Parameters.Add(param(0))
            Else
                For i As Integer = 0 To param.Length - 1
                    comando.Parameters.Add(param(i))
                Next
            End If
            comando.ExecuteNonQuery()
        Catch ex As Exception
            msjerr = ex.Message
        Finally
            con.Close()
        End Try
    End Sub
    Public Shared Sub ProcedimientoSinPar(ByVal sentencia As String, ByRef msjerr As String)
        Dim con As New SqlConnection
        Try
            'procedimiento sin parametros
            Dim comando As New SqlCommand
            con.ConnectionString = AppSettings("CONN") 'ConfigurationManager.ConnectionStrings("CONN").ConnectionString
            con.Open()
            comando.Connection = con
            comando.CommandType = CommandType.StoredProcedure
            comando.CommandText = sentencia
            comando.ExecuteNonQuery()
        Catch ex As Exception
            msjerr = ex.Message
        Finally
            con.Close()
        End Try
    End Sub
    Public Shared Sub ProcedimientoTXT(ByVal sentencia As String, ByRef msjerr As String)
        Dim con As New SqlConnection
        Try
            'procedimiento sin parametros
            Dim comando As New SqlCommand
            con.ConnectionString = AppSettings("CONN") 'ConfigurationManager.ConnectionStrings("CONN").ConnectionString
            con.Open()
            comando.Connection = con
            comando.CommandType = CommandType.Text
            comando.CommandText = sentencia
            comando.ExecuteNonQuery()
        Catch ex As Exception
            msjerr = ex.Message
        Finally
            con.Close()
        End Try
    End Sub
    'Public Shared Function SendMail(ByVal MailTo As String, ByVal MailFrom As String, ByVal MailMensaje As String, ByVal MailAsunto As String, Optional ByVal RUTA As String = "") As Boolean
    '    Try
    '        Dim msg As New MailMessage()
    '        msg.From = New MailAddress(MailFrom)
    '        msg.To.Add(New MailAddress(MailTo))
    '        msg.Subject = MailAsunto.ToUpperInvariant
    '        msg.Body = MailMensaje.ToUpperInvariant

    '        If RUTA <> "" Then
    '            msg.Attachments.Add(New Attachment(RUTA))
    '        End If
    '        Dim client As SmtpClient = Nothing
    '        client = New SmtpClient()
    '        client.Host = "MTYCORREOFVE02"
    '        client.Send(msg)
    '        Return True

    '    Catch ex As SmtpException
    '        Return False
    '    End Try
    'End Function

    Public Shared Function SendMail(ByVal MailTo As String, ByVal MailFrom As String, ByVal MailMensaje As String, ByVal MailAsunto As String, Optional ByVal RUTA As String = "") As Boolean
        Try
            Dim msg As New MailMessage()
            msg.From = New MailAddress(MailFrom)
            msg.To.Add(New MailAddress(MailTo))
            msg.Subject = MailAsunto.ToUpperInvariant
            msg.Body = MailMensaje.ToUpperInvariant

            If RUTA <> "" Then
                msg.Attachments.Add(New Attachment(RUTA))
            End If
            Dim SMTP As New SmtpClient("MTYCORREOFVE02_-", 25)
            SMTP.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis
            SMTP.Credentials = New Net.NetworkCredential("CZAMADA", "Esthela2014")
            SMTP.DeliveryMethod = SmtpDeliveryMethod.Network

            SMTP.Send(msg)

            'Dim client As SmtpClient = Nothing
            'client = New SmtpClient()
            'client.Host = "MTYCORREOFVE02"
            'client.Send(msg)
            'Return True

        Catch ex As SmtpException
            Return False
        End Try
    End Function

    Public Shared Function ValidarFecha(ByVal CveEmpresa As Integer, ByVal CveEncuesta As Integer) As String
        Dim Valor As String = ""
        Try
            Dim Consulta As String = "SET DATEFORMAT DMY; DECLARE @FI AS SMALLDATETIME; DECLARE @FF AS SMALLDATETIME; SELECT @FI=FECHAINICIAL,@FF=FECHAFINAL FROM TBLEMPRESAENCUESTA WHERE CVEEMPRESA=" & CveEmpresa & " AND CVEENCUESTA= " & CveEncuesta & " IF GETDATE() BETWEEN @FI AND @FF BEGIN SELECT  'OK' AS TIPO END  ELSE IF GETDATE()<@FI BEGIN SELECT 'In' AS TIPO END  ELSE IF GETDATE()>@FF BEGIN SELECT 'Ex' AS TIPO END ELSE BEGIN  SELECT 'No' AS TIPO END"
            Dim Ds As DataSet = FuncionTXT(Consulta, "")
            If Not Ds Is Nothing Then
                If Ds.Tables(0).Rows.Count <> 0 Then
                    Valor = Ds.Tables(0).Rows(0).Item("TIPO")
                Else
                    Valor = "WR"
                End If
            Else
                Valor = "WR"
            End If
            Return Valor
        Catch ex As SmtpException
        Finally

        End Try
    End Function


    Public Shared Function DsFunConPar(ByVal sentencia As String, ByVal param() As SqlParameter, ByRef msjerr As String) As Data.DataSet
        Dim con As New SqlConnection
        Dim dset As New DataSet
        msjerr = Nothing

        Try
            'Funcion con parametros
            Dim comando As New SqlCommand
            Dim adap As New SqlDataAdapter

            con.ConnectionString = AppSettings("CONN")

            con.Open()
            comando.CommandTimeout = 0
            comando.Connection = con
            comando.CommandType = CommandType.StoredProcedure
            comando.CommandText = sentencia
            For i As Integer = 0 To param.Length - 1
                comando.Parameters.Add(param(i))
            Next
            adap.SelectCommand = comando
            adap.Fill(dset)

        Catch ex As SqlException
            msjerr = ex.Message
        Catch ex As Exception
            msjerr = ex.Message
        Finally
            con.Close()
        End Try
        Return dset
    End Function


    'llenar un RadGrid, com procedure rad
    Public Shared Sub GridProcedure(ByVal grid As RadGrid, ByVal sentencia As String, ByVal param() As SqlParameter)
        Dim datos As New DataTable
        Dim M As String = String.Empty
        datos = DatosBD.DsFunConPar(sentencia, param, M).Tables(0)
        If IsNothing(M) Then

            grid.DataSource = datos
            grid.DataBind()
        Else
            Throw New Exception(M)
        End If
    End Sub
End Class
