using System;
using System.Collections.Generic;

namespace PEGASUS.Utilities
{ 

public class PooledBufferManager
{
	private readonly int _bufferLength;

	private int _bufferCount;

	private readonly Stack<byte[]> _buffers;

	public int BufferLength => _bufferLength;

	public int MaxBufferCount => _bufferCount;

	public int BuffersAvailable => _buffers.Count;

	public bool ClearOnReturn { get; set; }

	public event EventHandler NewBufferAllocated;

	public event EventHandler BufferRequested;

	public event EventHandler BufferReturned;

	protected virtual void OnNewBufferAllocated(EventArgs e)
	{
		this.NewBufferAllocated?.Invoke(this, e);
	}

	protected virtual void OnBufferRequested(EventArgs e)
	{
		this.BufferRequested?.Invoke(this, e);
	}

	protected virtual void OnBufferReturned(EventArgs e)
	{
		this.BufferReturned?.Invoke(this, e);
	}

	public PooledBufferManager(int baseBufferLength, int baseBufferCount)
	{
		if (baseBufferLength <= 0)
		{
			throw new ArgumentOutOfRangeException("baseBufferLength", baseBufferLength, "Buffer length must be a positive integer value.");
		}
		if (baseBufferCount <= 0)
		{
			throw new ArgumentOutOfRangeException("baseBufferCount", baseBufferCount, "Buffer count must be a positive integer value.");
		}
		_bufferLength = baseBufferLength;
		_bufferCount = baseBufferCount;
		_buffers = new Stack<byte[]>(baseBufferCount);
		for (int i = 0; i < baseBufferCount; i++)
		{
			_buffers.Push(new byte[baseBufferLength]);
		}
	}

	public byte[] GetBuffer()
	{
		if (_buffers.Count > 0)
		{
			lock (_buffers)
			{
				if (_buffers.Count > 0)
				{
					return _buffers.Pop();
				}
			}
		}
		return AllocateNewBuffer();
	}

	private byte[] AllocateNewBuffer()
	{
		byte[] result = new byte[_bufferLength];
		_bufferCount++;
		OnNewBufferAllocated(EventArgs.Empty);
		return result;
	}

	public bool ReturnBuffer(byte[] buffer)
	{
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (buffer.Length != _bufferLength)
		{
			return false;
		}
		if (ClearOnReturn)
		{
			Array.Clear(buffer, 0, buffer.Length);
		}
		lock (_buffers)
		{
			if (!_buffers.Contains(buffer))
			{
				_buffers.Push(buffer);
			}
		}
		return true;
	}

	public void IncreaseBufferCount(int buffersToAdd)
	{
		if (buffersToAdd <= 0)
		{
			throw new ArgumentOutOfRangeException("buffersToAdd", buffersToAdd, "The number of buffers to add must be a nonnegative, nonzero integer.");
		}
		List<byte[]> list = new List<byte[]>(buffersToAdd);
		for (int i = 0; i < buffersToAdd; i++)
		{
			list.Add(new byte[_bufferLength]);
		}
		lock (_buffers)
		{
			_bufferCount += buffersToAdd;
			for (int j = 0; j < buffersToAdd; j++)
			{
				_buffers.Push(list[j]);
			}
		}
	}

	public int DecreaseBufferCount(int buffersToRemove)
	{
		if (buffersToRemove <= 0)
		{
			throw new ArgumentOutOfRangeException("buffersToRemove", buffersToRemove, "The number of buffers to remove must be a nonnegative, nonzero integer.");
		}
		int num = 0;
		lock (_buffers)
		{
			for (int i = 0; i < buffersToRemove; i++)
			{
				if (_buffers.Count > 0)
				{
					_buffers.Pop();
					num++;
					_bufferCount--;
					continue;
				}
				return num;
			}
			return num;
		}
	}
}
}