using System.Collections.Generic;
using System.Linq;

namespace PEGASUS.Utilities
{ 

public class FrameCounter
{
	public const int MAXIMUM_SAMPLES = 100;

	private Queue<float> _sampleBuffer = new Queue<float>();

	public long TotalFrames { get; private set; }

	public float TotalSeconds { get; private set; }

	public float AverageFramesPerSecond { get; private set; }

	public event FrameUpdatedEventHandler FrameUpdated;

	public void Update(float deltaTime)
	{
		float num = 1f / deltaTime;
		_sampleBuffer.Enqueue(num);
		if (_sampleBuffer.Count > 100)
		{
			_sampleBuffer.Dequeue();
			AverageFramesPerSecond = _sampleBuffer.Average((float i) => i);
		}
		else
		{
			AverageFramesPerSecond = num;
		}
		OnFrameUpdated(new FrameUpdatedEventArgs(AverageFramesPerSecond));
		TotalFrames++;
		TotalSeconds += deltaTime;
	}

	protected virtual void OnFrameUpdated(FrameUpdatedEventArgs e)
	{
		this.FrameUpdated?.Invoke(e);
	}
}
}