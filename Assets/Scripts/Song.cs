using System;
using UnityEngine;

public class Song : MonoBehaviour
{
    public AudioClip audioClip;
    public int bpm;
    public float beat;


    public int getMaxScore(float gameTime){
        return (int)Math.Truncate(gameTime / secPerBeat() * beat);
    }

    public float secPerBeat(){
        return 60f / bpm;  
    }

    internal float getLength()
    {
        return audioClip.length;
    }
}
