using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    private bool play;
    private float timeWhenSongStarted;
    private Song currentSong;

    public void PlaySong(Song song) {
        play = true;
        currentSong = song;
        timeWhenSongStarted = (float)AudioSettings.dspTime;
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = song.audioClip;
        audioSource.Play();
    }

    public bool isPlaying() {
        return play;
    }

    public float songPositionInSecs(){
        return (float)(AudioSettings.dspTime - timeWhenSongStarted);
    }
    public float songPosInBeats(){
        if(currentSong == null){
            return 0f;
        }
        return songPositionInSecs() / currentSong.secPerBeat();
    }

    public int remainingTime( float gameTime){
        return (int)Math.Ceiling(gameTime - songPositionInSecs());  
    }

    internal void Stop()
    {
        GetComponent<AudioSource>().Stop();
    }
}
