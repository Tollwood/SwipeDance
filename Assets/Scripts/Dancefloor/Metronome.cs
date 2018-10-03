using System;
using UnityEngine;

public class Metronome : MonoBehaviour {


    private int maxRotation = 20;
    public SoundManager soundManager;

	void Update () {
        float beatPos = soundManager.songPosInBeats;
        bool goingRight = IsEven((int)Math.Truncate(beatPos));
        int maxAbsolut = maxRotation * 2;
        float percentOfBeat = beatPos - (float)Math.Floor(beatPos);

        float rotationZ = maxAbsolut * percentOfBeat - maxRotation;
        if (goingRight)
        {
            rotationZ = -1 * maxAbsolut * percentOfBeat + maxRotation;
        }
        transform.eulerAngles = new Vector3(0, 0, rotationZ);
	}

    private bool IsEven(int value)
    {
        return value == 0 || value % 2 == 0;
    }
}
