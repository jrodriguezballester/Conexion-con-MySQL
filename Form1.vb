Imports MySql.Data.MySqlClient

Public Class Form1


    ''' <summary>
    ''' Hace o comprueba que exista un ConexionBD.conexion 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BtnConexion_Click(sender As Object, e As EventArgs) Handles BtnConexion.Click
        If IsNothing(ConexionBD.conexion) Then
            Comprobar_conexion()
        Else
            MsgBox("Ya has comprobado la conexion, Se conecta bien ")
        End If
    End Sub


    ''' <summary>
    ''' Muestra la consulta SQL que hay en el metodo Consulta()
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param> 
    Private Sub BtnConsulta_Click(sender As Object, e As EventArgs) Handles btnConsulta.Click
        ListaDepartamentos.Visible = True
        DataGridView1.Visible = False
        If IsNothing(conexion) Then
            Comprobar_conexion()
            ' MsgBox("Debes comprobar conexion")
        End If
        Dim dataReader As MySqlDataReader = Consulta()
        Mostrar(dataReader)
    End Sub


    ''' <summary>
    ''' Ejecuta el insert SQL que hay en el metodo Insert()
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BtnInsercion_Click(sender As Object, e As EventArgs) Handles BtnInsercion.Click
        If IsNothing(conexion) Then
            Comprobar_conexion()
        End If
        Insert()
    End Sub


    ''' <summary>
    ''' Muestra el resultado de la consulta SQL del metodo ConsultaEscalar()
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BtnConsultaEsc_Click(sender As Object, e As EventArgs) Handles BtnConsultaEsc.Click
        If IsNothing(conexion) Then
            Comprobar_conexion()
        End If
        Dim resultado As Integer = ConsultaEscalar()
            MessageBox.Show("Hay " & resultado & " departamentos.")


    End Sub


    ''' <summary>
    ''' Muestra los resultados de una consulta SQL una vez cerrada la conexion
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BtnConsultaDesc_Click(sender As Object, e As EventArgs) Handles BtnConsultaDesc.Click
        ListaDepartamentos.Visible = False
        DataGridView1.Visible = True
        If IsNothing(conexion) Then
            Comprobar_conexion()
        End If
        Dim dataSet As DataSet = RellenarDatosDesconectadoBD()
        MostarDesconectado(DataSet)
    End Sub

    ''' <summary>
    ''' Muestra en un ListBox el dataReader 
    ''' </summary>
    ''' <param name="dataReader"></param>
    Private Sub Mostrar(dataReader As MySqlDataReader)

        Me.ListaDepartamentos.Items.Clear()
        While dataReader.Read()
            Me.ListaDepartamentos.Items.Add(dataReader("dept_no") & " -- " & dataReader("dnombre") & " -- " & dataReader("loc"))
        End While
        ' si aun esta conectado hay que desconectarse
        If Not dataReader.IsClosed Then
            CerrarDataReader()
        End If

    End Sub

    ''' <summary>
    ''' Muestra en un DataGridView los resultados de un dataSet
    ''' </summary>
    ''' <param name="dataSet"></param>
    Private Sub MostarDesconectado(dataSet As DataSet)
        ' Ahora DESCONECTADO, puede trabajar con los datos del DataSet
        Dim tabla As DataTable
        tabla = dataSet.Tables("departamentos")

        DataGridView1.DataSource = tabla
        '    Dim fila As DataRow
        '   Me.ListaDepartamentos.Items.Clear()
        '   For Each fila In tabla.Rows
        ' Muestra los datos en un ListBox
        '   Me.ListaDepartamentos.Items.Add(fila.Item("dnombre") & " " & fila.Item("loc"))
        '    Next

    End Sub


End Class
