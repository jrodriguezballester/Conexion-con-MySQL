Imports MySql.Data.MySqlClient

Module ConexionBD


    Public conexion As MySqlConnection
    Dim comando As New MySqlCommand
    ReadOnly servidor = "localhost"
    Dim usuario = "root"
    Dim pswd = "root"
    ReadOnly nameDB = "ejemplo"
    Dim resultado As Integer
    'Un objeto DataReader permite la navegación hacia delante y de sólo lectura de los registros devueltos por una consulta.
    Dim dataReader As MySqlDataReader

    ''' <summary>
    ''' Comprueba si puede conectarse a la BD
    ''' </summary>
    Public Sub Comprobar_conexion()
        '    conexion = New MySqlConnection("Server=localhost; Database=" & nameDB & "; Uid=root;Pwd=root ")
        conexion = New MySqlConnection("Server=" & servidor & "; Database=" & nameDB & "; Uid=" & usuario & ";Pwd=" & pswd)

        ' Tambien se puede poner 
        '       Dim conexion As New MySqlConnection
        '       conexion.ConnectionString = "server=" & servidor & ";"Database="& nameBD &"; & "user id=" & usuario & ";" & "password=" & pswd & ";"
        '       conexion.ConnectionString = "Persist Security Info=False;User ID=*****;Password=*****;Initial Catalog=AdventureWorks;Server=MySqlServer"  

        Try
            conexion.Open()
            ':::Si se estableció conexión correctamente dirá "Conectado"
            MsgBox("Comprobada conexion: Correcta")
        Catch ex As Exception
            ':::Si no se conecta nos mostrara el posible fallo en la conexión
            MsgBox("No se conecto por: " & ex.Message)
            conexion = Nothing
        Finally
            conexion.Close()
            '   MsgBox("Desconectado")
        End Try
    End Sub

    ''' <summary>
    ''' Ejecuta una consulta SQL del tipo ExecuteReader
    ''' </summary>
    ''' <returns>dataReader resultado de la sentencia SQL</returns>
    Public Function Consulta()

        comando.CommandText = "SELECT * FROM departamentos"
        comando.Connection = conexion

        ' Conectar con la Base de Datos
        conexion.Open()

        'Para obtener un objeto DataReader tendremos que ejecutar un método ExecuteReader() de un objeto Command basado en una consulta SQL.
        dataReader = comando.ExecuteReader()

        Return dataReader
    End Function

    ''' <summary>
    ''' Ejecuta una sentencia SQL de tipo Insert en la BD
    ''' </summary>
    Public Sub Insert()

        comando.Connection = conexion

        'CommandText : Contiene la sentencia SQL que se ejecutará sobre la fuente de datos.

        'comando.CommandText = "INSERT INTO departamentos VALUES (12, 'Pablo','Neruda')"  Sin parametros
        ' la sentencia puede tener parametros:
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

    ''' <summary>
    ''' Ejecuta sentencia SQL con un ExecuteScalar
    ''' </summary>
    ''' <returns></returns>
    Public Function ConsultaEscalar()
        comando.Connection = conexion
        comando.CommandText = "Select count(*) from departamentos"

        ' Conecta con la Base de Datos
        conexion.Open()
        ' Ejecuta la sentencia SQL (NonQuery ya que es una ' ' ' inserción). Sólo devuelve el número de filas afectadas
        resultado = comando.ExecuteScalar()
        ' Desconecta de la Base de Datos
        conexion.Close()
        Return resultado

    End Function

    ''' <summary>
    ''' Ejecuta sentencia SQL y la guarda en un dataset y cierra la conexion a BD
    ''' </summary>
    ''' <returns>dataSet resultado de una sentencia SQL</returns>
    Public Function RellenarDatosDesconectadoBD()
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

        Return dataSet
        End Function

    ''' <summary>
    ''' Cierra dataReader y conexion
    ''' </summary>
    Public Sub CerrarDataReader()
        dataReader.Close()
        conexion.Close()
    End Sub

End Module
