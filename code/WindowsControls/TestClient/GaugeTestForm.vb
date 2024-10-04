Public Class GaugeTestForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        minimumText.DataBindings.Add(New Binding("Text", testGauge, "Minimum"))
        valueText.DataBindings.Add(New Binding("Text", testGauge, "Value"))
        maximumText.DataBindings.Add(New Binding("Text", testGauge, "Maximum"))

        aTrackBar.DataBindings.Add(New Binding("Minimum", testGauge, "Minimum"))
        aTrackBar.DataBindings.Add(New Binding("Value", testGauge, "Value"))
        aTrackBar.DataBindings.Add(New Binding("Maximum", testGauge, "Maximum"))

        changeCountText.Text = "0"
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents minimumText As System.Windows.Forms.TextBox
    Friend WithEvents valueText As System.Windows.Forms.TextBox
    Friend WithEvents maximumText As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents testGauge As WindowsControls.Gauge
    Friend WithEvents aTrackBar As System.Windows.Forms.TrackBar
    Friend WithEvents changeCountText As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents incrementButton As System.Windows.Forms.Button
    Friend WithEvents decrementButton As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.testGauge = New WindowsControls.Gauge()
        Me.aTrackBar = New System.Windows.Forms.TrackBar()
        Me.minimumText = New System.Windows.Forms.TextBox()
        Me.valueText = New System.Windows.Forms.TextBox()
        Me.maximumText = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.decrementButton = New System.Windows.Forms.Button()
        Me.incrementButton = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.changeCountText = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        CType(Me.aTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'testGauge
        '
        Me.testGauge.Location = New System.Drawing.Point(24, 24)
        Me.testGauge.Name = "testGauge"
        Me.testGauge.Size = New System.Drawing.Size(152, 136)
        Me.testGauge.TabIndex = 0
        '
        'aTrackBar
        '
        Me.aTrackBar.Location = New System.Drawing.Point(24, 176)
        Me.aTrackBar.Maximum = 100
        Me.aTrackBar.Name = "aTrackBar"
        Me.aTrackBar.Size = New System.Drawing.Size(152, 42)
        Me.aTrackBar.TabIndex = 1
        Me.aTrackBar.TickFrequency = 10
        '
        'minimumText
        '
        Me.minimumText.Location = New System.Drawing.Point(88, 32)
        Me.minimumText.Name = "minimumText"
        Me.minimumText.Size = New System.Drawing.Size(96, 20)
        Me.minimumText.TabIndex = 2
        Me.minimumText.Text = "0"
        Me.minimumText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'valueText
        '
        Me.valueText.Location = New System.Drawing.Point(88, 64)
        Me.valueText.Name = "valueText"
        Me.valueText.Size = New System.Drawing.Size(96, 20)
        Me.valueText.TabIndex = 3
        Me.valueText.Text = "0"
        Me.valueText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'maximumText
        '
        Me.maximumText.Location = New System.Drawing.Point(88, 96)
        Me.maximumText.Name = "maximumText"
        Me.maximumText.Size = New System.Drawing.Size(96, 20)
        Me.maximumText.TabIndex = 4
        Me.maximumText.Text = "100"
        Me.maximumText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 23)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Minimum:"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 23)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Value:"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 23)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Maximum:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.decrementButton, Me.incrementButton, Me.Label4, Me.changeCountText, Me.maximumText, Me.minimumText, Me.Label2, Me.valueText, Me.Label1, Me.Label3})
        Me.GroupBox1.Location = New System.Drawing.Point(8, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 240)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Gauge Properties"
        '
        'decrementButton
        '
        Me.decrementButton.Location = New System.Drawing.Point(104, 184)
        Me.decrementButton.Name = "decrementButton"
        Me.decrementButton.Size = New System.Drawing.Size(80, 23)
        Me.decrementButton.TabIndex = 11
        Me.decrementButton.Text = "Decrement"
        '
        'incrementButton
        '
        Me.incrementButton.Location = New System.Drawing.Point(16, 184)
        Me.incrementButton.Name = "incrementButton"
        Me.incrementButton.Size = New System.Drawing.Size(80, 23)
        Me.incrementButton.TabIndex = 10
        Me.incrementButton.Text = "Increment"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 23)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Changes:"
        '
        'changeCountText
        '
        Me.changeCountText.Location = New System.Drawing.Point(88, 128)
        Me.changeCountText.Name = "changeCountText"
        Me.changeCountText.ReadOnly = True
        Me.changeCountText.Size = New System.Drawing.Size(96, 20)
        Me.changeCountText.TabIndex = 8
        Me.changeCountText.Text = "0"
        Me.changeCountText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.testGauge, Me.aTrackBar})
        Me.GroupBox2.Location = New System.Drawing.Point(216, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 240)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Test Gauge"
        '
        'GaugeTestForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(424, 269)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox2, Me.GroupBox1})
        Me.Name = "GaugeTestForm"
        Me.Text = "Test Gauge Utility"
        CType(Me.aTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub aTrackBar_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles aTrackBar.Scroll
        testGauge.Value = aTrackBar.Value
        valueText.Text = aTrackBar.Value.ToString
    End Sub

    Private Sub testGauge_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles testGauge.ValueChanged
        changeCountText.Text = CStr(CInt(changeCountText.Text) + 1)
    End Sub

    Private Sub incrementButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles incrementButton.Click
        testGauge.Increment()
    End Sub

    Private Sub decrementButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles decrementButton.Click
        testGauge.Decrement()
    End Sub

End Class
