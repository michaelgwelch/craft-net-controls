using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Drawing2D;



namespace WindowsControls
{
	public enum Style
	{
		Needle,
		Pie
	}


	/// <summary>
	/// Summary description for Gauge.
	/// </summary>
	public class Gauge : System.Windows.Forms.Control
	{
		//Public Event
		public event EventHandler Changed;

		//Default values
		private readonly Color defaultForeColor = Color.MidnightBlue;
		private const Style defaultStyle = Style.Needle;
		private const int defaultMaximum = 100;
		private const float margin = 10f;
		private const BorderStyle defaultBorderStyle = BorderStyle.Fixed3D;

		//Private members
		private int value;
		private int minimum;
		private int maximum = defaultMaximum;
		private Style style = defaultStyle;
		private BorderStyle borderStyle = defaultBorderStyle;

		public Gauge() : base()
		{
			ResizeRedraw = true;
			SetStyle(ControlStyles.DoubleBuffer,true);
			ForeColor = defaultForeColor;	
		}

		//Properties
		[Browsable(true),
		Category("Behavior"),
		Description("The current value of the gauge."),
		DefaultValue(0)]
		public int Value
		{
			get
			{
				return value;
			}
			set
			{
				if ((value > maximum) || (value < minimum))
				{
					throw new System.ArgumentOutOfRangeException();
				}
				else
				{
					this.value = value;
					OnChanged(EventArgs.Empty);
					Invalidate();
				}
			}
		}

		[Browsable(true),
		Category("Behavior"),
		Description("The minimum value that the gauge can take."),
		DefaultValue(0),
		RefreshProperties(RefreshProperties.Repaint)]
		public int Minimum
		{
			get
			{
				return minimum;
			}
			set
			{
				maximum = Math.Max(maximum,value);
				this.value = Math.Max(this.value,value);
				minimum = value;
				Invalidate();
				OnChanged(EventArgs.Empty);
			}
		}

		[Browsable(true),
		Category("Behavior"),
		Description("The maximum value that the gauge can take."),
		DefaultValue(0),
		RefreshProperties(RefreshProperties.Repaint)]
		public int Maximum
		{
			get
			{
				return maximum;
			}
			set
			{
				minimum = Math.Min(minimum,value);
				this.value =Math.Min(this.value,value);
				maximum = value;
				OnChanged(EventArgs.Empty);
				Invalidate();
			}
		}

		[Browsable(true),
		Category("Appearance"),
		Description("Controls what type of border the Gauge should have.")]
		public BorderStyle BorderStyle
		{
			get 
			{
				return borderStyle;
			}
			set
			{
				borderStyle = value;
				Invalidate();
			}
		}

		public bool ShouldSerializeBorderStyle()
		{
			return borderStyle != defaultBorderStyle;
		}

		public void ResetBorderStyle()
		{
			borderStyle = defaultBorderStyle;
		}

		[Browsable(true),
		Category("Appearance"),
		Description("Determines if the gauge will be displayed as a needle or a pie piece.")]
		public Style Style
		{
			get
			{
				return style;
			}
			set
			{
				style = value;
				Invalidate();
			}
		}

		public bool ShouldSerializeStyle()
		{
			return style != defaultStyle;
		}

		public void ResetStyle()
		{
			style = defaultStyle;
		}

		public override Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
			}
		}

		public bool ShouldSerializeForeColor() 
		{
			return ! base.ForeColor.Equals(defaultForeColor);
		}

		public override void ResetForeColor()
		{
			base.ForeColor = defaultForeColor;
		}


		//hides an inherited property in the Properties window
		[Browsable(false)]
		public override String Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}

		protected virtual void OnChanged(EventArgs e)
		{
			if (Changed != null)
				this.Changed(this, e);

		}

		protected override Size DefaultSize
		{
			get
			{
				return new Size(50,50);
			}
		}

		protected override void OnBackColorChanged(EventArgs e)
		{
			base.OnBackColorChanged(e);
			Invalidate();
		}

		protected override void OnForeColorChanged(EventArgs e)
		{
			base.OnForeColorChanged(e);
			Invalidate();
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			if (Width < 50) Width = 50;
			if (Height < 50) Height = 50;
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
			float radius = (Width / 2.0f) - margin;
			float angle = ((float)(value - minimum) / (float)(maximum - minimum)) * 180f;
			Point origin = new Point(Width / 2, (int) (Height - margin));

			pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

			//Paint the border
			PaintBorder(pe);

			//Paint the baseline
			PaintBaseline(pe);

			//Paint the interior based on Style
			switch (style)
			{
				case Style.Needle:
					PaintNeedle(pe, angle, radius, origin);
					break;
				case Style.Pie:
					PaintPie(pe, angle, radius, origin);
					break;
			}


		}
		
		private void PaintBaseline(PaintEventArgs pe)
		{
			float x1 = margin;
			float x2 = Width - margin;
			float y = Height - margin;

			using (Pen pen = new Pen(ForeColor))
			{
				pe.Graphics.DrawLine(pen,x1,y,x2,y);
			}
		}

		private void PaintNeedle(PaintEventArgs pe, float angle, float radius, Point origin)
		{
			Matrix matrix = new Matrix();
			GraphicsPath path = new GraphicsPath();

			matrix.Translate(origin.X,origin.Y);
			matrix.Rotate(angle);

			path.AddLine(0,0,-radius,0);
			path.Transform(matrix);

			using (Pen pen = new Pen(ForeColor,6))
			{
				pen.StartCap = LineCap.RoundAnchor;
				pen.EndCap = LineCap.ArrowAnchor;
				pe.Graphics.DrawPath(pen, path);
			}
		}

		private void PaintPie(PaintEventArgs pe, float angle, float radius, Point origin)
		{
			Matrix matrix = new Matrix();
			GraphicsPath path = new GraphicsPath();

			matrix.Translate(origin.X, origin.Y);
			
			path.AddPie(-radius, -radius, radius * 2, radius * 2, 180, angle);
			path.Transform(matrix);

			using (Brush brush = new SolidBrush(ForeColor))
			{
				pe.Graphics.FillPath(brush, path);
			}
		}

		private void PaintBorder(PaintEventArgs pe)
		{
			switch (borderStyle)
			{
				case BorderStyle.Fixed3D:
					ControlPaint.DrawBorder3D(pe.Graphics, this.ClientRectangle, Border3DStyle.Sunken);
					break;
				case BorderStyle.FixedSingle:
					using (Pen pen = new Pen(Color.Black))
					{
						pe.Graphics.DrawRectangle(pen, 0, 0, this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1);
					}
					break;
				default:
					break;
			}
		}


	}
}
