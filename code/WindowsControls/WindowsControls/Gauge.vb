'Without Imports, I would have to fully qualify every name
Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Math


<DefaultProperty("Value"), _
DefaultEvent("ValueChanged")> _
Public Class Gauge
    Inherits System.Windows.Forms.Control

    'Public Events
    Public Event ValueChanged As EventHandler

    'Default Values
    Private ReadOnly _defaultForeColor As Color = Color.MidnightBlue
    Private Const _defaultMaximum As Integer = 100
    Private Const _margin As Single = 10.0F

    'private members for properties
    Private _value As Integer
    Private _minimum As Integer
    Private _maximum As Integer = _defaultMaximum

#Region " Component Designer generated code "

    Public Sub New()
        MyBase.New()

        'Add any initialization after the InitializeComponent() call
        Me.ResizeRedraw = True
        Me.SetStyle(ControlStyles.DoubleBuffer, True)
        Me.ForeColor = _defaultForeColor
    End Sub

#End Region


#Region " Properties "

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
                Throw New ArgumentOutOfRangeException()
            Else
                _value = Value
                Invalidate()
                OnValueChanged(EventArgs.Empty)
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
            _minimum = Value
            Me.Value = Max(_value, Value)
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
            _maximum = Value
            Me.Value = Min(_value, Value)
            Invalidate()
        End Set
    End Property

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

    Public Overrides Property ForeColor() As System.Drawing.Color
        Get
            Return MyBase.ForeColor
        End Get
        Set(ByVal Value As System.Drawing.Color)
            MyBase.ForeColor = Value
        End Set
    End Property

    Public Function ShouldSerializeForeColor() As Boolean
        Return Not MyBase.ForeColor.Equals(_defaultForeColor)
    End Function

    Public Overrides Sub ResetForeColor()
        MyBase.ForeColor = _defaultForeColor
    End Sub

    Protected Overrides ReadOnly Property DefaultSize() As Size
        Get
            Return New Size(150, 100)
        End Get
    End Property

#End Region


#Region " Public Methods "
    'public methods
    Public Sub Increment()
        If _value < _maximum Then
            Value += 1
        End If
    End Sub

    Public Sub Decrement()
        If _value > _minimum Then
            Value -= 1
        End If
    End Sub

#End Region

#Region " Protected Methods "
    'protected instance methods
    Protected Overridable Sub OnValueChanged(ByVal e As EventArgs)
        RaiseEvent ValueChanged(Me, e)
    End Sub

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
        Dim angle As Single
        Dim origin As Point = New Point((ClientRectangle.Width / 2), CInt(ClientRectangle.Height - _margin))
        Dim pen As Pen

        'Calculate angle to rotate
        If _minimum = _maximum Then
            angle = 0
        Else
            angle = ((CSng(_value) - CSng(_minimum)) / (CSng(_maximum) - CSng(_minimum))) * Math.PI
        End If

        pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        'Paint the border
        ControlPaint.DrawBorder3D(pe.Graphics, Me.ClientRectangle, Border3DStyle.Sunken)

        'Paint the baseline
        pen = New Pen(ForeColor)
        pe.Graphics.DrawLine(pen, _margin, ClientRectangle.Height - _margin, ClientRectangle.Width - _margin, ClientRectangle.Height - _margin)

        'Paint the needle
        pen.StartCap = LineCap.RoundAnchor
        pen.EndCap = LineCap.ArrowAnchor
        pen.Width = 6
        Dim endpoint As Point = New Point(origin.X - CInt(radius * Cos(angle)), origin.Y - CInt(radius * Sin(angle)))
        pe.Graphics.DrawLine(pen, origin, endpoint)

        pen.Dispose()
    End Sub

#End Region

End Class


