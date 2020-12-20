Imports MySql.Data.MySqlClient

Public Class Form1

    Dim conexion As MySqlConnection
    Dim comando As New MySqlCommand
    Dim servidor = "localhost"
    Dim usuario = "root"
    Dim pswd = "root"
    Dim nameDB = "ejemplo"
    Dim resultado As Integer

    Private Sub BtnConexion_Click(sender As Object, e As EventArgs) Handles BtnConexion.Click
        If IsNothing(conexion) Then
            Comprobar_conexion()
        Else
            MsgBox("Ya has comprobado la conexion, Funciona bien ")
        End If
    End Sub

    Private Sub Comprobar_conexion()
        ':::Nuestro objeto MySqlConnection con la cadena de conexión y la ruta de la base
        conexion = New MySqlConnection("Server=localhost; Database=" & nameDB & "; Uid=root;Pwd=root ")
        ' Tambien se puede poner 
        '       Dim conexion As New MySqlConnection
        '       conexion.ConnectionString = "server=" & servidor & ";"Database="& nameBD &"; & "user id=" & usuario & ";" & "password=" & pswd & ";"
        '       conexion.ConnectionString = "Persist Security Info=False;User ID=*****;Password=*****;Initial Catalog=AdventureWorks;Server=MySqlServer"  

        ':::Utilizamos el try para capturar posibles errores
        Try
            ':::Abrimos la conexión
            conexion.Open()
            ':::Si se estableció conexión correctamente dirá "Conectado"
            MsgBox("Comprobada conexion: Conectado")
        Catch ex As Exception
            ':::Si no se conecta nos mostrara el posible fallo en la conexión
            MsgBox("No se conecto por: " & ex.Message)
            conexion = Nothing
        Finally
            conexion.Close()
            MsgBox("Desconectado")
        End Try
    End Sub

    Private Sub btnConsulta_Click(sender As Object, e As EventArgs) Handles btnConsulta.Click
        If IsNothing(conexion) Then
            MsgBox("Debes comprobar conexion")
        Else
            Consulta()
        End If

    End Sub
    Private Sub Consulta()

        'Un objeto DataReader permite la navegación hacia delante y de sólo lectura de los registros devueltos por una consulta.
        Dim dataReader As MySqlDataReader

        comando.CommandText = "SELECT * FROM departamentos"
        comando.Connection = conexion

        ' Conectar con la Base de Datos
        conexion.Open()

        'Para obtener un objeto DataReader tendremos que ejecutar un método ExecuteReader() de un objeto Command basado en una consulta SQL.
        dataReader = comando.ExecuteReader()

        ' Recorrer las filas devueltas en el DataReader y los muestra en un ListBox
        Me.ListaDepartamentos.Items.Clear()
        While dataReader.Read()
            ' Me.ListaAlumnos.Items.Add(dataReader("dnombre"))
            Me.ListaDepartamentos.Items.Add(dataReader("dept_no") & " -- " & dataReader("dnombre") & " -- " & dataReader("loc"))

        End While

        ' Cierra el objeto DataReader, liberando sus recursos
        dataReader.Close()
        ' Desconecta de la Base de Datos
        conexion.Close()

    End Sub

    Private Sub BtnInsercion_Click(sender As Object, e As EventArgs) Handles BtnInsercion.Click
        If IsNothing(conexion) Then
            MsgBox("Debes comprobar conexion")
        Else
            Insert()
        End If

    End Sub

    Private Sub Insert()

        comando.Connection = conexion

        'CommandText : Contiene la sentencia SQL que se ejecutará sobre la fuente de datos.

        'comando.CommandText = "INSERT INTO departamentos VALUES (12, 'Pablo','Neruda')"  Sin parametros
        comando.CommandText = "INSERT INTO departamentos VALUES (@id,@dnombre,@loc)"    'Con parametros

        comando.Parameters.AddWithValue("@id", 19)
        comando.Parameters.AddWithValue("@dnombre", "Marketing")
        comando.Parameters.AddWithValue("@loc", "Mislata")


        ' Conectar con la Base de Datos
        conexion.Open()

        Try
            'ExecuteNonQuery : Ejecuta la sentencia SQL debe ser del tipo que no devuelva resultados (UPDATE, DELETE, INSERT).
            resultado = comando.ExecuteNonQuery()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)

        End Try

        ' Desconectar de la Base de Datos
        conexion.Close()

        MessageBox.Show("Se han añadido " & resultado & " filas")
    End Sub

    Private Sub BtnConsultaEsc_Click(sender As Object, e As EventArgs) Handles BtnConsultaEsc.Click
        If IsNothing(conexion) Then
            MsgBox("Debes comprobar conexion")
        Else
            ConsultaEscalar()
        End If

    End Sub

    Private Sub ConsultaEscalar()
        comando.Connection = conexion
        comando.CommandText = "Select count(*) from departamentos"

        ' Conecta con la Base de Datos
        conexion.Open()
        ' Ejecuta la sentencia SQL (NonQuery ya que es una ' ' ' inserción). Sólo devuelve el número de filas afectadas
        resultado = comando.ExecuteScalar()
        ' Desconecta de la Base de Datos
        conexion.Close()
        MessageBox.Show("Hay " & resultado & " departamentos.")
    End Sub

    Private Sub BtnConsultaDesc_Click(sender As Object, e As EventArgs) Handles BtnConsultaDesc.Click
        If IsNothing(conexion) Then
            MsgBox("Debes comprobar conexion")
        Else
            RellenarDatosDesconectadoBD()
        End If

    End Sub

    Private Sub RellenarDatosDesconectadoBD()
        Dim strSQL = "SELECT * FROM departamentos"
        ' Crea el DataAdapter
        Dim dataAdapter As New MySqlDataAdapter(strSQL, conexion)

        'Crea el DataSet
        Dim dataSet As New DataSet()

        ' Conecta a la Base de Datos, carga el DataSet y desconecta
        conexion.Open()
        dataAdapter.Fill(dataSet, "departamentos")
        conexion.Close()
        MsgBox("Ahora esta desconectado; los datos estan en la memoria")

        ' Ahora DESCONECTADO, puede trabajar con los datos del DataSet
        Dim tabla As DataTable
        tabla = dataSet.Tables("departamentos")
        Dim fila As DataRow
        Me.ListaDepartamentos.Items.Clear()
        For Each fila In tabla.Rows
            ' Muestra los datos en un ListBox
            Me.ListaDepartamentos.Items.Add(fila.Item("dnombre") & " " & fila.Item("loc"))
        Next

    End Sub
End Class
