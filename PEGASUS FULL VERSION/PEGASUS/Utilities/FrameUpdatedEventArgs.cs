using System;

namespace PEGASUS.Utilities
{ 

public class FrameUpdatedEventArgs : EventArgs
{
	public float CurrentFramesPerSecond { get; private set; }

	public FrameUpdatedEventArgs(float _CurrentFramesPerSecond)
	{
		CurrentFramesPerSecond = _CurrentFramesPerSecond;
	}
}
}