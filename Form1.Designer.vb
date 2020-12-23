<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BtnConsultaDesc = New System.Windows.Forms.Button()
        Me.btnConsulta = New System.Windows.Forms.Button()
        Me.BtnConsultaEsc = New System.Windows.Forms.Button()
        Me.BtnInsercion = New System.Windows.Forms.Button()
        Me.BtnConexion = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ListaDepartamentos = New System.Windows.Forms.ListBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnConsultaDesc
        '
        Me.BtnConsultaDesc.Location = New System.Drawing.Point(13, 288)
        Me.BtnConsultaDesc.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnConsultaDesc.Name = "BtnConsultaDesc"
        Me.BtnConsultaDesc.Size = New System.Drawing.Size(121, 53)
        Me.BtnConsultaDesc.TabIndex = 5
        Me.BtnConsultaDesc.Text = "Consulta Desconectado"
        Me.BtnConsultaDesc.UseVisualStyleBackColor = True
        '
        'btnConsulta
        '
        Me.btnConsulta.Location = New System.Drawing.Point(13, 99)
        Me.btnConsulta.Margin = New System.Windows.Forms.Padding(4)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(121, 57)
        Me.btnConsulta.TabIndex = 2
        Me.btnConsulta.Text = "Consulta"
        Me.btnConsulta.UseVisualStyleBackColor = True
        '
        'BtnConsultaEsc
        '
        Me.BtnConsultaEsc.Location = New System.Drawing.Point(13, 227)
        Me.BtnConsultaEsc.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnConsultaEsc.Name = "BtnConsultaEsc"
        Me.BtnConsultaEsc.Size = New System.Drawing.Size(121, 53)
        Me.BtnConsultaEsc.TabIndex = 4
        Me.BtnConsultaEsc.Text = "ConsultaEscalar"
        Me.BtnConsultaEsc.UseVisualStyleBackColor = True
        '
        'BtnInsercion
        '
        Me.BtnInsercion.Location = New System.Drawing.Point(13, 164)
        Me.BtnInsercion.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnInsercion.Name = "BtnInsercion"
        Me.BtnInsercion.Size = New System.Drawing.Size(123, 55)
        Me.BtnInsercion.TabIndex = 3
        Me.BtnInsercion.Text = "Insercion"
        Me.BtnInsercion.UseVisualStyleBackColor = True
        '
        'BtnConexion
        '
        Me.BtnConexion.Location = New System.Drawing.Point(13, 36)
        Me.BtnConexion.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnConexion.Name = "BtnConexion"
        Me.BtnConexion.Size = New System.Drawing.Size(123, 55)
        Me.BtnConexion.TabIndex = 1
        Me.BtnConexion.Text = "Conexion"
        Me.BtnConexion.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(207, 36)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(494, 281)
        Me.DataGridView1.TabIndex = 9
        Me.DataGridView1.Visible = False
        '
        'ListaDepartamentos
        '
        Me.ListaDepartamentos.FormattingEnabled = True
        Me.ListaDepartamentos.ItemHeight = 16
        Me.ListaDepartamentos.Location = New System.Drawing.Point(207, 36)
        Me.ListaDepartamentos.Margin = New System.Windows.Forms.Padding(4)
        Me.ListaDepartamentos.Name = "ListaDepartamentos"
        Me.ListaDepartamentos.Size = New System.Drawing.Size(494, 292)
        Me.ListaDepartamentos.TabIndex = 8
        Me.ListaDepartamentos.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(726, 351)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.BtnConsultaDesc)
        Me.Controls.Add(Me.btnConsulta)
        Me.Controls.Add(Me.ListaDepartamentos)
        Me.Controls.Add(Me.BtnConsultaEsc)
        Me.Controls.Add(Me.BtnInsercion)
        Me.Controls.Add(Me.BtnConexion)
        Me.Name = "Form1"
        Me.Text = "Conexion a MySQL"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnConsultaDesc As Button
    Friend WithEvents btnConsulta As Button
    Friend WithEvents BtnConsultaEsc As Button
    Friend WithEvents BtnInsercion As Button
    Friend WithEvents BtnConexion As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ListaDepartamentos As ListBox
End Class
