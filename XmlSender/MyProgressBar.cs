using System.Drawing;
using System.Windows.Forms;

namespace XmlSender
{
	public  class MyProgressBar : ProgressBar
	{
		public MyProgressBar(Point newloc, Size newsize)
		{
			Location = newloc;
			Size = newsize;
			PaintEventArgs e = new PaintEventArgs(this.CreateGraphics(), new Rectangle(this.Location, this.Size));
			OnPaint(e);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Graphics g = e.Graphics;
			drawText(ref g);
		}

		private void drawText(ref Graphics g)
		{
			Font f = new System.Drawing.Font("Arial", 9, FontStyle.Bold);
			StringFormat sf = new StringFormat();
			sf.Alignment = StringAlignment.Center;
			sf.LineAlignment = StringAlignment.Center;
			g.DrawString(string.Format("{0}%", Value), f, new SolidBrush(Color.FromArgb(73, 73, 73)), ClientRectangle, sf);
			f.Dispose();
			sf.Dispose();
		}
	}
}