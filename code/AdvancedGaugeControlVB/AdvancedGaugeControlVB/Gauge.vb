'Without Imports, I would have to fully qualify every name
Imports System.ComponentModel
Imports System.Windows.Forms.BorderStyle
Imports System.Drawing.Drawing2D
Imports System.Math

'Defines Styles used to set the Style of a Gauge control.
Public Enum Style
    Needle
    Fill
End Enum

<DefaultProperty("Value"), _
DefaultEvent("Changed")> _
Public Class Gauge
    Inherits System.Windows.Forms.Control

    'Public Events
    Public Event Changed As EventHandler

    'Default Values
    Private Const _defaultBorderStyle As BorderStyle = Fixed3D
    Private ReadOnly _defaultForeColor As Color = Color.MidnightBlue
    Private ReadOnly _defaultStyle As Style = Style.Needle
    Private Const _defaultMaximum As Integer = 100
    Private Const _margin As Single = 10.0F

    'private members for properties
    Private _value As Integer
    Private _minimum As Integer
    Private _maximum As Integer = 100
    Private _style As Style = _defaultStyle
    Private _borderStyle As BorderStyle = _defaultBorderStyle


#Region " Component Designer generated code "

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    <DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ResizeRedraw = True
        Me.SetStyle(ControlStyles.DoubleBuffer, True)
        Me._style = Style.Needle
        Me.ForeColor = _defaultForeColor
        Me.BorderStyle = _defaultBorderStyle
    End Sub
#End Region

#Region " Public Properties "

    'Properties
    <Browsable(True), _
    Category("Behavior"), _
    Description("The current value of the gauge."), _
    DefaultValue(0)> _
    Public Property Value() As Integer
        Get
            Return _value
        End Get
        Set(ByVal Value As Integer)
            If (Value > _maximum) Or (Value < _minimum) Then
                Throw New System.ArgumentOutOfRangeException()
            Else
                _value = Value
                OnChanged(EventArgs.Empty)
                Invalidate()

            End If
        End Set
    End Property

    <Browsable(True), _
    Category("Behavior"), _
    Description("The minimum value that the control can take."), _
    DefaultValue(0), _
    RefreshProperties(RefreshProperties.Repaint)> _
    Public Property Minimum() As Integer
        Get
            Return _minimum
        End Get
        Set(ByVal Value As Integer)
            _maximum = Max(_maximum, Value)
            _value = Max(_value, Value)
            _minimum = Value
            OnChanged(EventArgs.Empty)
            Invalidate()
        End Set
    End Property

    <Browsable(True), _
    Category("Behavior"), _
    Description("The maximum value that the control can take."), _
    DefaultValue(_defaultMaximum), _
    RefreshProperties(RefreshProperties.Repaint)> _
    Public Property Maximum() As Integer
        Get
            Return _maximum
        End Get
        Set(ByVal Value As Integer)
            _minimum = Min(_minimum, Value)
            _value = Min(_value, Value)
            _maximum = Value
            OnChanged(EventArgs.Empty)
            Invalidate()
        End Set
    End Property


    <Browsable(True), _
    Category("Appearance"), _
    Description("Controls what type of border the Gauge should have.")> _
    Public Property BorderStyle() As BorderStyle
        Get
            Return _borderStyle
        End Get
        Set(ByVal Value As BorderStyle)
            _borderStyle = Value
            Invalidate()
        End Set
    End Property

    Public Function ShouldSerializeBorderStyle() As Boolean

        Return (_borderStyle <> _defaultBorderStyle)

    End Function

    Public Sub ResetBorderStyle()
        Me.BorderStyle = _defaultBorderStyle
    End Sub

    <Browsable(True), _
    Category("Appearance"), _
    Description("Determines whether the Gauge will show represent the value using a needle or a fill region")> _
    Public Property Style() As Style
        Get
            Return _style

        End Get
        Set(ByVal Value As Style)
            If Style.IsDefined(GetType(Style), Value) Then
                _style = Value
                Invalidate()
            End If
        End Set
    End Property

    Public Function ShouldSerializeStyle() As Boolean
        Return (_style <> _defaultStyle)
    End Function

    Public Sub ResetStyle()
        Me.Style = _defaultStyle
    End Sub

    Public Overrides Property ForeColor() As Color
        Get
            Return MyBase.ForeColor
        End Get
        Set(ByVal Value As Color)
            MyBase.ForeColor = Value
        End Set
    End Property

    Public Function ShouldSerializeForeColor() As Boolean
        Return Not ForeColor.Equals(_defaultForeColor)
    End Function

    Public Overrides Sub ResetForeColor()
        ForeColor = _defaultForeColor
    End Sub

    'hides an inherited property from showing up in object browser.  but still maintains functionality
    <Browsable(False)> _
    Public Overrides Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal Value As String)
            MyBase.Text = Value
        End Set
    End Property

#End Region

#Region " Public Methods "
    'public methods
    Public Sub Increment()
        Value = CInt(IIf(_value + 1 <= _maximum, _value + 1, _value))
    End Sub

    Public Sub Increment(ByVal Amount As Integer)
        Value = CInt(IIf(_value + Amount <= _maximum, _value + Amount, _value))
    End Sub

#End Region

#Region " Protected Methods "
    'protected instance methods
    Protected Overridable Sub OnChanged(ByVal e As EventArgs)
        RaiseEvent Changed(Me, e)
    End Sub

    Protected Overrides ReadOnly Property DefaultSize() As Size
        Get
            Return New Size(150, 100)
        End Get
    End Property

    Protected Overrides Sub OnBackColorChanged(ByVal e As EventArgs)
        MyBase.OnBackColorChanged(e)
        Invalidate()
    End Sub

    Protected Overrides Sub OnForeColorChanged(ByVal e As EventArgs)
        MyBase.OnForeColorChanged(e)
        Invalidate()
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        If Width < 50 Then Width = 50
        If Height < 50 Then Height = 50
    End Sub

    Protected Overrides Sub OnPaint(ByVal pe As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(pe)
        Dim radius As Single = ClientRectangle.Width / 2.0F - _margin
        Dim angle As Single = ((CSng(_value) - CSng(_minimum)) / (CSng(_maximum) - CSng(_minimum))) * 180.0F
        Dim origin As Point = New Point(CInt(ClientRectangle.Width / 2.0F), CInt(ClientRectangle.Height - _margin))

        pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        'Paint the border
        PaintBorder(pe)
        PaintBaseline(pe)


        'Paint the interior of the control based on the style
        Select Case _style
            Case Style.Needle
                PaintNeedle(pe, angle, radius, origin)
            Case Style.Fill
                PaintFill(pe, angle, radius, origin)

        End Select

    End Sub

#End Region

#Region " Private Paint Methods "

    Private Sub PaintBaseline(ByVal pe As PaintEventArgs)
        Dim x1 As Single = _margin
        Dim y As Single = Height - _margin
        Dim x2 As Single = Width - _margin

        Dim pen As Pen
        Try
            pen = New Pen(Me.ForeColor)
            pe.Graphics.DrawLine(pen, x1, y, x2, y)
        Finally
            If Not (pen Is Nothing) Then pen.Dispose()
        End Try

    End Sub
    Private Sub PaintNeedle(ByVal pe As PaintEventArgs, ByVal angle As Single, ByVal radius As Single, ByVal origin As Point)
        Dim matrix As Matrix = New Matrix()
        Dim path As GraphicsPath = New GraphicsPath()
        Dim pen As Pen

        matrix.Translate(origin.X, origin.Y)
        matrix.Rotate(angle)

        path.AddLine(0, 0, -radius, 0)
        path.Transform(matrix)

        Try
            pen = New Pen(ForeColor, 6)
            pen.StartCap = LineCap.RoundAnchor
            pen.EndCap = LineCap.ArrowAnchor
            pe.Graphics.DrawPath(pen, path)
        Finally
            If Not (pen Is Nothing) Then pen.Dispose()
        End Try
    End Sub

    Private Sub PaintFill(ByVal pe As PaintEventArgs, ByVal angle As Single, ByVal radius As Single, ByVal origin As Point)
        Dim matrix As Matrix = New Matrix()
        Dim path As GraphicsPath = New GraphicsPath()
        Dim brush As SolidBrush

        matrix.Translate(origin.X, origin.Y)

        path.AddPie(-radius, -radius, radius * 2, radius * 2, 180, angle)
        path.Transform(matrix)

        Try
            brush = New SolidBrush(ForeColor)
            pe.Graphics.FillPath(brush, path)
        Finally
            If Not (brush Is Nothing) Then brush.Dispose()
        End Try


    End Sub

    Public Sub PaintBorder(ByVal pe As PaintEventArgs)
        Dim blackBorderPen As Pen

        Select Case _borderStyle
            Case Fixed3D
                ControlPaint.DrawBorder3D(pe.Graphics, Me.ClientRectangle, Border3DStyle.Sunken)
            Case FixedSingle
                Try
                    blackBorderPen = New Pen(Color.Black, 1)
                    pe.Graphics.DrawRectangle(blackBorderPen, 0, 0, Me.ClientRectangle.Width - 1, Me.ClientRectangle.Height - 1)
                Finally
                    If Not (blackBorderPen Is Nothing) Then blackBorderPen.Dispose()
                End Try
        End Select
    End Sub

#End Region

End Class
