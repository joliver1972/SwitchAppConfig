Imports System
Imports System.Data.SqlClient
Imports System.IO
Imports System.Linq
Imports System.Windows.Forms
Imports System.Xml.Linq

Public Class MainForm
    Private Const ServidorDom As String = "DOM"
    Private Const ServidorCliente As String = "app01\vectorerp"

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtRutaConfig.Text = My.Settings.LastConfigPath
        txtServidor.Text = If(String.IsNullOrWhiteSpace(My.Settings.LastCustomServer), ServidorDom, My.Settings.LastCustomServer)
    End Sub

    Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
        Using dialogo As New OpenFileDialog()
            dialogo.Title = "Seleccionar archivo de configuración"
            dialogo.Filter = "Archivos config (*.config)|*.config|Todos los archivos (*.*)|*.*"
            dialogo.CheckFileExists = True
            dialogo.Multiselect = False

            If dialogo.ShowDialog(Me) = DialogResult.OK Then
                txtRutaConfig.Text = dialogo.FileName
                My.Settings.LastConfigPath = dialogo.FileName
                My.Settings.Save()
                AgregarLog("Archivo seleccionado: " & dialogo.FileName)
            End If
        End Using
    End Sub

    Private Sub btnDom_Click(sender As Object, e As EventArgs) Handles btnDom.Click
        CambiarConexiones(ServidorDom)
    End Sub

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        CambiarConexiones(ServidorCliente)
    End Sub

    Private Sub btnAplicarPersonalizado_Click(sender As Object, e As EventArgs) Handles btnAplicarPersonalizado.Click
        Dim servidor As String = txtServidor.Text.Trim()
        If String.IsNullOrWhiteSpace(servidor) Then
            MessageBox.Show(Me, "Debes indicar un servidor personalizado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtServidor.Focus()
            Return
        End If

        My.Settings.LastCustomServer = servidor
        My.Settings.Save()

        CambiarConexiones(servidor)
    End Sub

    Private Sub btnRestaurarBackup_Click(sender As Object, e As EventArgs) Handles btnRestaurarBackup.Click
        lstLog.Items.Clear()

        Dim rutaConfig As String = txtRutaConfig.Text.Trim()
        If Not ValidarRutaConfig(rutaConfig) Then
            Return
        End If

        Dim rutaBackup As String = rutaConfig & ".bak"
        If Not File.Exists(rutaBackup) Then
            MessageBox.Show(Me, "No existe archivo de backup para restaurar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            File.Copy(rutaBackup, rutaConfig, True)
            AgregarLog("Backup restaurado correctamente: " & rutaBackup)
            MessageBox.Show(Me, "Archivo restaurado correctamente desde el backup.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(Me, "No se pudo restaurar el backup: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidarRutaConfig(rutaConfig As String) As Boolean
        If String.IsNullOrWhiteSpace(rutaConfig) Then
            MessageBox.Show(Me, "Selecciona un archivo .config.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If Not File.Exists(rutaConfig) Then
            MessageBox.Show(Me, "El archivo indicado no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        Return True
    End Function

    Private Sub CambiarConexiones(nuevoServidor As String)
        lstLog.Items.Clear()

        Dim rutaConfig As String = txtRutaConfig.Text.Trim()
        If Not ValidarRutaConfig(rutaConfig) Then
            Return
        End If

        Try
            Dim rutaBackup As String = rutaConfig & ".bak"
            File.Copy(rutaConfig, rutaBackup, True)
            AgregarLog("Backup creado: " & rutaBackup)

            Dim documento As XDocument = XDocument.Load(rutaConfig)
            Dim connectionStringsElement As XElement = documento.<configuration>.<connectionStrings>.FirstOrDefault()

            If connectionStringsElement Is Nothing Then
                MessageBox.Show(Me, "No se encontró la sección <connectionStrings> en el archivo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim nodos = connectionStringsElement.<add>.Where(Function(x) x.Attribute("connectionString") IsNot Nothing).ToList()
            If nodos.Count = 0 Then
                MessageBox.Show(Me, "No se encontraron cadenas de conexión para modificar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim actualizadas As Integer = 0

            For Each nodo As XElement In nodos
                Dim nombre As String = ObtenerAtributo(nodo, "name", "(sin nombre)")
                Dim cadenaOriginal As String = ObtenerAtributo(nodo, "connectionString", String.Empty)

                If String.IsNullOrWhiteSpace(cadenaOriginal) Then
                    AgregarLog(String.Format("Conexión '{0}': sin cadena, omitida.", nombre))
                    Continue For
                End If

                Try
                    Dim builder As New SqlConnectionStringBuilder(cadenaOriginal)
                    Dim servidorAnterior As String = builder.DataSource
                    builder.DataSource = nuevoServidor
                    nodo.SetAttributeValue("connectionString", builder.ConnectionString)
                    actualizadas += 1
                    AgregarLog(String.Format("Conexión '{0}': {1} -> {2}", nombre, If(String.IsNullOrWhiteSpace(servidorAnterior), "(vacío)", servidorAnterior), nuevoServidor))
                Catch ex As Exception
                    AgregarLog(String.Format("Conexión '{0}': no se pudo modificar. Motivo: {1}", nombre, ex.Message))
                End Try
            Next

            documento.Save(rutaConfig)
            My.Settings.LastConfigPath = rutaConfig
            My.Settings.Save()

            AgregarLog(String.Format("Total de conexiones actualizadas: {0}", actualizadas))
            MessageBox.Show(Me, "Conexiones actualizadas correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(Me, "Error al actualizar conexiones: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Shared Function ObtenerAtributo(nodo As XElement, nombreAtributo As String, valorPorDefecto As String) As String
        Dim atributo As XAttribute = nodo.Attribute(nombreAtributo)
        If atributo Is Nothing Then
            Return valorPorDefecto
        End If

        Return atributo.Value
    End Function

    Private Sub AgregarLog(mensaje As String)
        lstLog.Items.Add(String.Format("{0:HH:mm:ss} - {1}", DateTime.Now, mensaje))
        lstLog.TopIndex = lstLog.Items.Count - 1
    End Sub
End Class
