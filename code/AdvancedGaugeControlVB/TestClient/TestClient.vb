Imports System.Windows.Forms
Imports AdvancedGaugeControlVB.Style
Imports AdvancedGaugeControlVB

Public Class GaugeTestForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        valueText.DataBindings.Add(New Binding("Text", testGauge, "Value"))
        minimumText.DataBindings.Add(New Binding("Text", testGauge, "Minimum"))
        maximumText.DataBindings.Add(New Binding("Text", testGauge, "Maximum"))
        aTrackBar.DataBindings.Add(New Binding("Maximum", testGauge, "Maximum"))
        aTrackBar.DataBindings.Add(New Binding("Minimum", testGauge, "Minimum"))
        aTrackBar.DataBindings.Add(New Binding("Value", testGauge, "Value"))
        styleCombo.SelectedIndex = 0
        borderStyleCombo.SelectedIndex = 2
        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents propertyGroup As System.Windows.Forms.GroupBox
    Friend WithEvents testGroup As System.Windows.Forms.GroupBox
    Friend WithEvents aTrackBar As System.Windows.Forms.TrackBar
    Friend WithEvents valLabel As System.Windows.Forms.Label
    Friend WithEvents minLabel As System.Windows.Forms.Label
    Friend WithEvents maxLabel As System.Windows.Forms.Label
    Friend WithEvents valueText As System.Windows.Forms.TextBox
    Friend WithEvents minimumText As System.Windows.Forms.TextBox
    Friend WithEvents maximumText As System.Windows.Forms.TextBox
    Friend WithEvents styleLabel As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents styleCombo As System.Windows.Forms.ComboBox
    Friend WithEvents borderStyleCombo As System.Windows.Forms.ComboBox
    Friend WithEvents foreColorButton As System.Windows.Forms.Button
    Friend WithEvents theColorDialog As System.Windows.Forms.ColorDialog

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents testGauge As AdvancedGaugeControlVB.Gauge
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.minimumText = New System.Windows.Forms.TextBox()
        Me.valueText = New System.Windows.Forms.TextBox()
        Me.theColorDialog = New System.Windows.Forms.ColorDialog()
        Me.borderStyleCombo = New System.Windows.Forms.ComboBox()
        Me.styleLabel = New System.Windows.Forms.Label()
        Me.valLabel = New System.Windows.Forms.Label()
        Me.foreColorButton = New System.Windows.Forms.Button()
        Me.styleCombo = New System.Windows.Forms.ComboBox()
        Me.propertyGroup = New System.Windows.Forms.GroupBox()
        Me.maximumText = New System.Windows.Forms.TextBox()
        Me.maxLabel = New System.Windows.Forms.Label()
        Me.minLabel = New System.Windows.Forms.Label()
        Me.testGroup = New System.Windows.Forms.GroupBox()
        Me.testGauge = New AdvancedGaugeControlVB.Gauge()
        Me.aTrackBar = New System.Windows.Forms.TrackBar()
        Me.propertyGroup.SuspendLayout()
        Me.testGroup.SuspendLayout()
        CType(Me.aTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 160)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 23)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "BorderStyle:"
        '
        'minimumText
        '
        Me.minimumText.Location = New System.Drawing.Point(88, 64)
        Me.minimumText.Name = "minimumText"
        Me.minimumText.TabIndex = 4
        Me.minimumText.Text = "0"
        '
        'valueText
        '
        Me.valueText.Location = New System.Drawing.Point(88, 32)
        Me.valueText.Name = "valueText"
        Me.valueText.TabIndex = 3
        Me.valueText.Text = "0"
        '
        'borderStyleCombo
        '
        Me.borderStyleCombo.DropDownWidth = 104
        Me.borderStyleCombo.Items.AddRange(New Object() {"None", "FixedSingle", "Fixed3D"})
        Me.borderStyleCombo.Location = New System.Drawing.Point(88, 160)
        Me.borderStyleCombo.Name = "borderStyleCombo"
        Me.borderStyleCombo.Size = New System.Drawing.Size(104, 21)
        Me.borderStyleCombo.TabIndex = 8
        '
        'styleLabel
        '
        Me.styleLabel.Location = New System.Drawing.Point(16, 128)
        Me.styleLabel.Name = "styleLabel"
        Me.styleLabel.Size = New System.Drawing.Size(40, 23)
        Me.styleLabel.TabIndex = 2
        Me.styleLabel.Text = "Style:"
        '
        'valLabel
        '
        Me.valLabel.Location = New System.Drawing.Point(16, 32)
        Me.valLabel.Name = "valLabel"
        Me.valLabel.Size = New System.Drawing.Size(56, 23)
        Me.valLabel.TabIndex = 0
        Me.valLabel.Text = "Value:"
        '
        'foreColorButton
        '
        Me.foreColorButton.Location = New System.Drawing.Point(56, 200)
        Me.foreColorButton.Name = "foreColorButton"
        Me.foreColorButton.TabIndex = 10
        Me.foreColorButton.Text = "Fore Color..."
        '
        'styleCombo
        '
        Me.styleCombo.DropDownWidth = 104
        Me.styleCombo.Items.AddRange(New Object() {"Needle", "Fill"})
        Me.styleCombo.Location = New System.Drawing.Point(88, 128)
        Me.styleCombo.Name = "styleCombo"
        Me.styleCombo.Size = New System.Drawing.Size(104, 21)
        Me.styleCombo.TabIndex = 7
        '
        'propertyGroup
        '
        Me.propertyGroup.Controls.AddRange(New System.Windows.Forms.Control() {Me.foreColorButton, Me.borderStyleCombo, Me.styleCombo, Me.Label1, Me.maximumText, Me.minimumText, Me.valueText, Me.maxLabel, Me.minLabel, Me.valLabel, Me.styleLabel})
        Me.propertyGroup.Location = New System.Drawing.Point(8, 24)
        Me.propertyGroup.Name = "propertyGroup"
        Me.propertyGroup.Size = New System.Drawing.Size(200, 240)
        Me.propertyGroup.TabIndex = 1
        Me.propertyGroup.TabStop = False
        Me.propertyGroup.Text = "Gauge Properties"
        '
        'maximumText
        '
        Me.maximumText.Location = New System.Drawing.Point(88, 96)
        Me.maximumText.Name = "maximumText"
        Me.maximumText.TabIndex = 5
        Me.maximumText.Text = "100"
        '
        'maxLabel
        '
        Me.maxLabel.Location = New System.Drawing.Point(16, 96)
        Me.maxLabel.Name = "maxLabel"
        Me.maxLabel.Size = New System.Drawing.Size(56, 23)
        Me.maxLabel.TabIndex = 2
        Me.maxLabel.Text = "Maximum:"
        '
        'minLabel
        '
        Me.minLabel.Location = New System.Drawing.Point(16, 64)
        Me.minLabel.Name = "minLabel"
        Me.minLabel.Size = New System.Drawing.Size(56, 23)
        Me.minLabel.TabIndex = 1
        Me.minLabel.Text = "Minimum:"
        '
        'testGroup
        '
        Me.testGroup.Controls.AddRange(New System.Windows.Forms.Control() {Me.testGauge, Me.aTrackBar})
        Me.testGroup.Location = New System.Drawing.Point(216, 24)
        Me.testGroup.Name = "testGroup"
        Me.testGroup.Size = New System.Drawing.Size(200, 240)
        Me.testGroup.TabIndex = 2
        Me.testGroup.TabStop = False
        Me.testGroup.Text = "Test Gauge"
        '
        'testGauge
        '
        Me.testGauge.ForeColor = System.Drawing.Color.MidnightBlue
        Me.testGauge.Location = New System.Drawing.Point(24, 24)
        Me.testGauge.Name = "testGauge"
        Me.testGauge.Size = New System.Drawing.Size(152, 136)
        Me.testGauge.TabIndex = 2
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
        'GaugeTestForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(424, 277)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.testGroup, Me.propertyGroup})
        Me.Name = "GaugeTestForm"
        Me.Text = "Test Gauge Utility"
        Me.propertyGroup.ResumeLayout(False)
        Me.testGroup.ResumeLayout(False)
        CType(Me.aTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub foreColorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles foreColorButton.Click
        theColorDialog.Color = testGauge.ForeColor
        theColorDialog.ShowDialog()
        testGauge.ForeColor = theColorDialog.Color
    End Sub

    Private Sub aTrackBar_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles aTrackBar.Scroll
        testGauge.Value = aTrackBar.Value
        valueText.Text = aTrackBar.Value.ToString()
    End Sub

    Private Sub styleCombo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles styleCombo.SelectedIndexChanged
        Dim obj As Object
        obj = System.Enum.Parse(GetType(Style), styleCombo.Text)
        testGauge.Style = CType(obj, Style)

    End Sub

    Private Sub borderStyleCombo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles borderStyleCombo.SelectedIndexChanged
        Dim obj As Object
        obj = System.Enum.Parse(GetType(System.Windows.Forms.BorderStyle), borderStyleCombo.Text)
        testGauge.BorderStyle = CType(obj, System.Windows.Forms.BorderStyle)
    End Sub

End Class
