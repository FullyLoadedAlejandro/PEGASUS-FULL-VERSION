using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using PEGASUS.Utilities;

namespace PEGASUS.Forms.CustomControls
	{
public class RapidPictureBox : PictureBox, IRapidPictureBox
{
	private readonly object _imageLock = new object();

	private Stopwatch _sWatch;

	private FrameCounter _frameCounter;

	public bool Running { get; set; }

	public int ScreenWidth { get; private set; }

	public int ScreenHeight { get; private set; }

	public Image GetImageSafe
	{
		get
		{
			return base.Image;
		}
		set
		{
			lock (_imageLock)
			{
				base.Image = value;
			}
		}
	}

	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams obj = base.CreateParams;
			obj.ExStyle |= 33554432;
			return obj;
		}
	}

	public void SetFrameUpdatedEvent(FrameUpdatedEventHandler e)
	{
		_frameCounter.FrameUpdated += e;
	}

	public void UnsetFrameUpdatedEvent(FrameUpdatedEventHandler e)
	{
		_frameCounter.FrameUpdated -= e;
	}

	public void Start()
	{
		_frameCounter = new FrameCounter();
		_sWatch = Stopwatch.StartNew();
		Running = true;
	}

	public void Stop()
	{
		if (_sWatch != null)
		{
			_sWatch.Stop();
		}
		Running = false;
	}

	public void UpdateImage(Bitmap bmp, bool cloneBitmap)
	{
		try
		{
			CountFps();
			if (ScreenWidth != bmp.Width && ScreenHeight != bmp.Height)
			{
				UpdateScreenSize(bmp.Width, bmp.Height);
			}
			lock (_imageLock)
			{
				Image getImageSafe = GetImageSafe;
				SuspendLayout();
				GetImageSafe = (cloneBitmap ? new Bitmap(bmp, base.Width, base.Height) : bmp);
				ResumeLayout();
				getImageSafe?.Dispose();
			}
		}
		catch (InvalidOperationException)
		{
		}
		catch (Exception)
		{
		}
	}

	public RapidPictureBox()
	{
		SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
	}

	protected override void OnPaint(PaintEventArgs pe)
	{
		lock (_imageLock)
		{
			if (GetImageSafe != null)
			{
				pe.Graphics.DrawImage(GetImageSafe, new Point(0, 0));
			}
		}
	}

	private void UpdateScreenSize(int newWidth, int newHeight)
	{
		ScreenWidth = newWidth;
		ScreenHeight = newHeight;
	}

	private void CountFps()
	{
		float deltaTime = (float)_sWatch.Elapsed.TotalSeconds;
		_sWatch = Stopwatch.StartNew();
		_frameCounter.Update(deltaTime);
	}
}
}