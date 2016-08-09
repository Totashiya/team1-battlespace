using UnityEngine;

public class FPSCounter : MonoBehaviour {

	public int frameRange = 60; // the range of frames in which they are averaged

	public int AverageFPS { get; private set; }

	public int HighestFPS { get; private set; }
	public int LowestFPS { get; private set; }

	int[] fpsBuffer; // stores the FPS values of multiple frame
	int fpsBufferIndex; // so we know where to put the data of the next frame

	void Update() {
		// Initialize buffer if either we just started, or frameRange has changed
		if (fpsBuffer == null || fpsBuffer.Length != frameRange) {
			InitializeBuffer ();
		}
		UpdateBuffer ();
		CalculateFPS ();
	}

	void InitializeBuffer() {
		if (frameRange <= 0) {
			frameRange = 1;
		}
		fpsBuffer = new int[frameRange];
		fpsBufferIndex = 0;
	}
		
	void UpdateBuffer() {
		// Store the current FPS at the current index which is incremented
		fpsBuffer[fpsBufferIndex++] = (int)(1f / Time.unscaledDeltaTime);
		if (fpsBufferIndex >= frameRange) {
			fpsBufferIndex = 0;
		}
	}

	void CalculateFPS() {
		int sum = 0;
		int highest = 0;
		int lowest = int.MaxValue;
		for (int i = 0; i < frameRange; i++) {
			int fps = fpsBuffer [i];
			sum += fps;

			if (fps > highest) {
				highest = fps;
			}
			if (fps < lowest) {
				lowest = fps;
			}
		}
		AverageFPS = (int)((float)sum / frameRange);
		HighestFPS = highest;
		LowestFPS = lowest;
	}
}