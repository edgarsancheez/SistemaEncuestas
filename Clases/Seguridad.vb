Imports System.Security.Cryptography

Public Class Seguridad
    Public Shared Function Encrypt(ByVal toEncrypt As String, ByVal KeyEncode As String) As String
        Dim keyArray As Byte()
        ' ByVal useHashing As Boolean,
        Dim toEncryptArray As Byte() = UTF8Encoding.UTF8.GetBytes(toEncrypt)

        Dim settingsReader As System.Configuration.AppSettingsReader = New AppSettingsReader()
        ' Get the key from config file 

        Dim key As String = KeyEncode  'DirectCast(settingsReader.GetValue("SecurityKey", "Seguridad"), String)
        'System.Windows.Forms.MessageBox.Show(key); 
        'If hashing use get hashcode regards to your key 
        'If useHashing Then
        Dim hashmd5 As New MD5CryptoServiceProvider()
        keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key))
        'Always release the resources and flush data 
        ' of the Cryptographic service provide. Best Practice 

        hashmd5.Clear()
        'Else
        'keyArray = UTF8Encoding.UTF8.GetBytes(key)
        'End If

        Dim tdes As New TripleDESCryptoServiceProvider()
        'set the secret key for the tripleDES algorithm 
        tdes.Key = keyArray
        'mode of operation. there are other 4 modes. 
        'We choose ECB(Electronic code Book) 
        tdes.Mode = CipherMode.ECB
        'padding mode(if any extra byte added) 

        tdes.Padding = PaddingMode.PKCS7

        Dim cTransform As ICryptoTransform = tdes.CreateEncryptor()
        'transform the specified region of bytes array to resultArray 
        Dim resultArray As Byte() = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length)
        'Release resources held by TripleDes Encryptor 
        tdes.Clear()
        'Return the encrypted data into unreadable string format 
        Return Convert.ToBase64String(resultArray, 0, resultArray.Length)
    End Function


    Public Shared Function Decrypt(ByVal cipherString As String, ByVal KeyEncode As String) As String
        Dim keyArray As Byte()
        'ByVal useHashing As Boolean,
        'get the byte code of the string 

        Dim toEncryptArray As Byte() = Convert.FromBase64String(cipherString)

        Dim settingsReader As System.Configuration.AppSettingsReader = New AppSettingsReader()
        'Get your key from config file to open the lock! 
        Dim key As String = KeyEncode 'DirectCast(settingsReader.GetValue("SecurityKey", GetType([String])), String)

        ' If useHashing Then
        'if hashing was used get the hash code with regards to your key 
        Dim hashmd5 As New MD5CryptoServiceProvider()
        keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key))
        'release any resource held by the MD5CryptoServiceProvider 

        hashmd5.Clear()
        'Else
        'if hashing was not implemented get the byte code of the key 
        ' keyArray = UTF8Encoding.UTF8.GetBytes(key)
        'End If

        Dim tdes As New TripleDESCryptoServiceProvider()
        'set the secret key for the tripleDES algorithm 
        tdes.Key = keyArray
        'mode of operation. there are other 4 modes. 
        'We choose ECB(Electronic code Book) 

        tdes.Mode = CipherMode.ECB
        'padding mode(if any extra byte added) 
        tdes.Padding = PaddingMode.PKCS7

        Dim cTransform As ICryptoTransform = tdes.CreateDecryptor()
        Dim resultArray As Byte() = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length)
        'Release resources held by TripleDes Encryptor 
        tdes.Clear()
        'return the Clear decrypted TEXT 
        Return UTF8Encoding.UTF8.GetString(resultArray)
    End Function

    Public Shared Function EncriptarHAS5(ByVal strToEncrypt As String, ByVal strKey As String) As String
        Try
            Dim objDESCrypto As New TripleDESCryptoServiceProvider()
            Dim objHashMD5 As New MD5CryptoServiceProvider()

            Dim byteHash As Byte(), byteBuff As Byte()
            Dim strTempKey As String = strKey

            byteHash = objHashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strTempKey))
            objHashMD5 = Nothing
            objDESCrypto.Key = byteHash
            objDESCrypto.Mode = CipherMode.ECB
            'CBC, CFB 
            byteBuff = ASCIIEncoding.ASCII.GetBytes(strToEncrypt)
            Return Convert.ToBase64String(objDESCrypto.CreateEncryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length))
        Catch ex As Exception
            Return "Dato Incorrecto" & ex.Message
        End Try
    End Function

    Public Shared Function DecriptarHAS5(ByVal strEncrypted As String, ByVal strKey As String) As String
        Try
            Dim objDESCrypto As New TripleDESCryptoServiceProvider()
            Dim objHashMD5 As New MD5CryptoServiceProvider()

            Dim byteHash As Byte(), byteBuff As Byte()
            Dim strTempKey As String = strKey

            byteHash = objHashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strTempKey))
            objHashMD5 = Nothing
            objDESCrypto.Key = byteHash
            objDESCrypto.Mode = CipherMode.ECB
            'CBC, CFB 
            byteBuff = Convert.FromBase64String(strEncrypted)
            Dim strDecrypted As String = ASCIIEncoding.ASCII.GetString(objDESCrypto.CreateDecryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length))
            objDESCrypto = Nothing

            Return strDecrypted
        Catch ex As Exception
            Return "Dato Incorrecto" & ex.Message
        End Try
    End Function

    Public Shared Function Encriptar(ByVal EncryptText As String, ByVal KeyEncode As String) As String
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

    Public Shared Function Decriptar(ByVal DecryptText As String, ByVal KeyEncode As String) As String
        Crypto.EncryptionAlgorithm = 7 'Model DAS
        Crypto.Encoding = Crypto.EncodingType.HEX
        Crypto.Key = KeyEncode
        Crypto.Content = DecryptText
        Dim Valor As String
        If Crypto.DecryptString Then
            Valor = Crypto.Content
        Else
            Valor = Crypto.CryptoException.Message
        End If
        Crypto.Clear()
        Return Valor
    End Function
End Class



