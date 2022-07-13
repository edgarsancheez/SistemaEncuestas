'Imports Telerik.WebControls
Imports System.Data.SqlClient
Imports Telerik.Web.UI

Public Class Cargar
    'llenar un RadGrid, con una sentencia rad
    Public Shared Sub GridSentenciaTxt(ByVal grid As RadGrid, ByVal sentencia As String)
        Dim datos As New DataTable
        Dim M As String = ""
        datos = DatosBD.FuncionTXT(sentencia, M).Tables(0)
        If M.Length <> 0 Then
            Throw New Exception(M)
        Else
            grid.DataSource = datos
            grid.DataBind()
        End If
    End Sub
    'llenar un RadGrid, com procedure rad
    Public Shared Sub GridProcedure(ByVal grid As RadGrid, ByVal sentencia As String, ByVal param() As SqlParameter)
        Dim datos As New DataTable
        Dim M As String = ""
        datos = DatosBD.FuncionConPar(sentencia, param, M).Tables(0)
        If M.Length <> 0 Then
            Throw New Exception(M)
        Else
            grid.DataSource = datos
            grid.DataBind()
        End If
    End Sub
    'llena el combo con  todos los  datos, con  sentencia rad
    Public Shared Sub ComboSentenciaTxt(ByVal combo As RadComboBox, ByVal sentencia As String, ByVal CampoDisplay As String, ByVal CampoValue As String, Optional ByVal tipo As String = "", Optional ByVal Mayuscula As Boolean = True)
        Dim datos As New DataTable
        Dim M As String = ""
        datos = DatosBD.FuncionTXT(sentencia, M).Tables(0)
        If M.Length <> 0 Then
            Throw New Exception(M)
        Else
            Dim ren As DataRow
            If tipo = "" Then

                If Mayuscula = False Then

                End If

            ElseIf tipo = "1" Then
                ren = datos.NewRow
                ren.Item(0) = "-1"
                If Mayuscula = True Then
                    ren.Item(1) = "[TODOS]"
                Else
                    ren.Item(1) = "[Todos]"
                End If
                datos.Rows.InsertAt(ren, 0)
            ElseIf tipo = "2" Then
                ren = datos.NewRow
                ren.Item(0) = "-1"
                If Mayuscula = True Then
                    ren.Item(1) = "[SELECCIONAR]"
                Else
                    ren.Item(1) = "[Seleccionar]"
                End If

                datos.Rows.InsertAt(ren, 0)
            End If

            combo.DataSource = datos
            combo.DataTextField = CampoDisplay
            combo.DataValueField = CampoValue
            combo.DataBind()

            If combo.Items.Count = 2 Then
                combo.Enabled = False
                combo.SelectedIndex = 1
            Else
                combo.Enabled = True
                combo.SelectedIndex = 0
            End If

        End If
    End Sub
    'llena el combo con  todos los  datos, con procedure rad
    Public Shared Sub ComboParametros(ByVal combo As RadComboBox, ByVal sentencia As String, ByVal param() As SqlParameter, ByVal CampoDisplay As String, ByVal CampoValue As String, Optional ByVal tipo As String = "", Optional ByVal Mayuscula As Boolean = True)
        Dim datos As New DataTable
        Dim M As String = ""
        datos = DatosBD.FuncionConPar(sentencia, param, M).Tables(0)
        If M.Length <> 0 Then
            Throw New Exception(M)
        Else
            Dim ren As DataRow
            If tipo = "" Then

            ElseIf tipo = "1" Then
                ren = datos.NewRow
                ren.Item(0) = "-1"
                If Mayuscula = True Then
                    ren.Item(1) = "[TODOS]"
                Else
                    ren.Item(1) = "[Todos]"
                End If
                datos.Rows.InsertAt(ren, 0)
            ElseIf tipo = "2" Then
                ren = datos.NewRow
                ren.Item(0) = "-1"
                If Mayuscula = True Then
                    ren.Item(1) = "[SELECCIONAR]"
                Else
                    ren.Item(1) = "[Seleccionar]"
                End If

                datos.Rows.InsertAt(ren, 0)
            End If

            combo.DataSource = datos
            combo.DataTextField = CampoDisplay.ToUpper
            combo.DataValueField = CampoValue
            combo.DataBind()
        End If
    End Sub

    'llenar un DataGrid, con una sentencia normal
    'Public Shared Sub GridSentenciaTxt(ByVal grid As DataGrid, ByVal sentencia As String)
    '    Dim datos As New DataTable
    '    Dim M As String = ""
    '    datos = DatosBD.FuncionTXT(sentencia, M).Tables(0)
    '    If M.Length <> 0 Then
    '        Throw New Exception(M)
    '    Else
    '        grid.DataSource = datos
    '        grid.DataBind()
    '    End If
    'End Sub
    ''llenar un DataGrid, com procedure  normal
    'Public Shared Sub GridProcedure(ByVal grid As DataGrid, ByVal sentencia As String, ByVal param() As SqlParameter)
    '    Dim datos As New DataTable
    '    Dim M As String = ""
    '    datos = DatosBD.FuncionConPar(sentencia, param, M).Tables(0)
    '    If M.Length <> 0 Then
    '        Throw New Exception(M)
    '    Else
    '        grid.DataSource = datos
    '        grid.DataBind()
    '    End If
    'End Sub
    ''llena el DropDownList con  todos los  datos, con  sentencia normal
    'Public Shared Sub ComboSentenciaTxt(ByVal combo As DropDownList, ByVal sentencia As String, ByVal CampoDisplay As String, ByVal CampoValue As String, Optional ByVal tipo As String = "")
    '    Dim datos As New DataTable
    '    Dim M As String = ""
    '    datos = DatosBD.FuncionTXT(sentencia, M).Tables(0)
    '    If M.Length <> 0 Then
    '        Throw New Exception(M)
    '    Else
    '        Dim ren As DataRow
    '        If tipo = "1" Then
    '            ren = datos.NewRow
    '            ren.Item(0) = "-1"
    '            ren.Item(1) = "[TODOS]"
    '            datos.Rows.InsertAt(ren, 0)
    '        ElseIf tipo = "2" Then
    '            ren = datos.NewRow
    '            ren.Item(0) = "-1"
    '            ren.Item(1) = "[SELECCIONAR]"
    '            datos.Rows.InsertAt(ren, 0)
    '        End If

    '        combo.DataSource = datos
    '        combo.DataTextField = CampoDisplay.ToUpper
    '        combo.DataValueField = CampoValue
    '        combo.DataBind()
    '    End If
    'End Sub
    ''llena el DropDownList con  todos los  datos, con procedure normal
    'Public Shared Sub ComboParametros(ByVal combo As DropDownList, ByVal sentencia As String, ByVal param() As SqlParameter, ByVal CampoDisplay As String, ByVal CampoValue As String, Optional ByVal tipo As String = "")
    '    Dim datos As New DataTable
    '    Dim M As String = ""
    '    datos = DatosBD.FuncionConPar(sentencia, param, M).Tables(0)
    '    If M.Length <> 0 Then
    '        Throw New Exception(M)
    '    Else
    '        Dim ren As DataRow
    '        If tipo = "1" Then
    '            ren = datos.NewRow
    '            ren.Item(0) = "-1"
    '            ren.Item(1) = "[TODOS]"
    '            datos.Rows.InsertAt(ren, 0)
    '        ElseIf tipo = "2" Then
    '            ren = datos.NewRow
    '            ren.Item(0) = "-1"
    '            ren.Item(1) = "[SELECCIONAR]"
    '            datos.Rows.InsertAt(ren, 0)
    '        End If

    '        combo.DataSource = datos
    '        combo.DataTextField = CampoDisplay.ToUpper
    '        combo.DataValueField = CampoValue
    '        combo.DataBind()
    '    End If
    'End Sub
    'llena el CheckListBox con  todos los  datos, con  sentencia normal
    Public Shared Sub ChekListSentenciaTxt(ByVal ChkLis As CheckBoxList, ByVal sentencia As String, ByVal CampoDisplay As String, ByVal CampoValue As String)
        Dim datos As New DataTable
        Dim M As String = ""
        datos = DatosBD.FuncionTXT(sentencia, M).Tables(0)
        If M.Length <> 0 Then
            Throw New Exception(M)
        Else
            ChkLis.DataSource = datos
            ChkLis.DataTextField = CampoDisplay.ToUpper
            ChkLis.DataValueField = CampoValue
            ChkLis.DataBind()
        End If
    End Sub
    ''llena el CheckListBox con  todos los  datos, con procedure normal
    'Public Shared Sub ChekListParametros(ByVal ChkLis As CheckBoxList, ByVal sentencia As String, ByVal param() As SqlParameter, ByVal CampoDisplay As String, ByVal CampoValue As String)
    '    Dim datos As New DataTable
    '    Dim M As String = ""
    '    datos = DatosBD.FuncionConPar(sentencia, param, M).Tables(0)
    '    If M.Length <> 0 Then
    '        Throw New Exception(M)
    '    Else
    '        ChkLis.DataSource = datos
    '        ChkLis.DataTextField = CampoDisplay.ToUpper
    '        ChkLis.DataValueField = CampoValue
    '        ChkLis.DataBind()
    '    End If
    'End Sub
    ''Contar el resultado de ua sentencia
    'Public Shared Function ContarDatos(ByVal sentencia As String) As Integer
    '    Dim datos As New DataTable
    '    Dim M As String = ""
    '    datos = DatosBD.FuncionTXT(sentencia, M).Tables(0)
    '    If M.Length <> 0 Then
    '        Throw New Exception(M)
    '    Else
    '        Return datos.Rows.Count
    '    End If
    'End Function

    Public Shared Sub UserMsgBox(ByVal sMsg As String, ByVal pa As System.Web.UI.Page)

        Dim sb As New StringBuilder()
        Dim oFormObject As System.Web.UI.Control
        sMsg = sMsg.Replace("'", "\'")
        sMsg = sMsg.Replace(Chr(34), "\" & Chr(34))
        sMsg = sMsg.Replace(vbCrLf, "\n")
        sMsg = "<script language=javascript>alert(""" & sMsg & """)</script>"
        sb = New StringBuilder()
        sb.Append(sMsg)
        For Each oFormObject In pa.Controls
            If TypeOf oFormObject Is HtmlForm Then
                Exit For
            End If
        Next
        ' Add the javascript after the form object so that the 
        ' message doesn't appear on a blank screen.
        oFormObject.Controls.AddAt(oFormObject.Controls.Count, New LiteralControl(sb.ToString()))
    End Sub

    Public Shared Sub Mensaje(ByVal RaM As RadAjaxManager, ByVal Mensaje As String, Optional ByVal Encabezado As String = "Información")
        'si funciona
        'RadAjaxManager1.ResponseScripts.Add("Sys.Application.add_load(function()    " & vbCr & vbLf & "        {radalert('Welcome to RadWindow for <b>ASP.NET AJAX</b>!', 330, 210,'Rad alert');})")
        If Mensaje.Length > 0 Then
            RaM.ResponseScripts.Add("Sys.Application.add_load(function(){radalert('" & Mensaje & "', 330, 210,'" & Encabezado & "');})")
        End If

    End Sub

    'llena el combo con  todos los  datos, con procedure rad
    Public Shared Sub ComboParametrosPor(ByVal combo As RadComboBox, ByVal sentencia As String, ByVal param() As SqlParameter, ByVal CampoDisplay As String, ByVal CampoValue As String, Optional ByVal tipo As String = "", Optional ByVal Mayuscula As Boolean = True)
        Dim datos As New DataTable
        Dim M As String = ""
        datos = DatosBD.FuncionConPar(sentencia, param, M).Tables(0)
        If M.Length <> 0 Then
            Throw New Exception(M)
        Else
            Dim ren As DataRow
            If tipo = "" Then

            ElseIf tipo = "1" Then
                ren = datos.NewRow
                ren.Item(0) = "-1"
                If Mayuscula = True Then
                    ren.Item(1) = "[TODOS]"
                Else
                    ren.Item(1) = "[Todos]"
                End If
                datos.Rows.InsertAt(ren, 0)
            ElseIf tipo = "2" Then
                ren = datos.NewRow
                ren.Item(0) = "-1"
                If Mayuscula = True Then
                    ren.Item(1) = "[SELECIONAR]"
                Else
                    ren.Item(1) = "[Selecionar]"
                End If

                datos.Rows.InsertAt(ren, 0)
            End If

            combo.DataSource = datos
            combo.DataTextField = CampoDisplay.ToUpper
            combo.DataValueField = CampoValue
            combo.DataBind()
        End If
    End Sub

End Class
