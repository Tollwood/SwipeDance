using UnityEngine;

public class StopsManager : MonoBehaviour {

    public GameState gameState;

    public GameObject firstLeft;
    public GameObject secondLeft;
    public GameObject thirdLeft;

    public GameObject firstRight;
    public GameObject secondRight;
    public GameObject thirdRight;

    GameObject[] stops;
    bool playing = false;
    bool startPlaying = false;

    void Start () {
        stops = new GameObject[] { firstRight, firstLeft, secondRight, secondLeft, thirdRight, thirdLeft };
	}
	

	void Update () {

        if (Input.GetMouseButtonDown(0)){
            startPlaying = true;
        }

        if(startPlaying && !playing){
            GetComponent<AudioManager>().PlaySong(gameState.song);
            playing = true;
        }

        float songPosInBeats = GetComponent<AudioManager>().songPosInBeats();
        int indexToActivate = ((int)songPosInBeats % stops.Length);
        GameObject stopToActivate = stops[indexToActivate];
        stopToActivate.SetActive(true);
        fadeIn(stopToActivate.GetComponent<SpriteRenderer>(), songPosInBeats);

        int indexToDeactivate = indexToActivate == 0 ? stops.Length -1 : indexToActivate -1 ;
        GameObject stopToDeactivate = stops[indexToDeactivate];
        fadeOut(stopToDeactivate.GetComponent<SpriteRenderer>(), songPosInBeats);
        if(stopToDeactivate.GetComponent<SpriteRenderer>().color.a <= .2f){
            stopToDeactivate.SetActive(false);    
        }

	}

    void fadeIn(SpriteRenderer spriteRenderer, float songPosInBeats){
        fade(spriteRenderer, songPosInBeats);
    }

    void fadeOut(SpriteRenderer spriteRenderer, float songPosInBeats)
    {
        float alphaValue =  1 - (songPosInBeats % 1) ;
        fade(spriteRenderer, alphaValue);
    }

    void fade(SpriteRenderer spriteRenderer, float songPosInBeats){
        Color tmpColor = spriteRenderer.color;
        tmpColor.a = songPosInBeats % 1;
        spriteRenderer.color = tmpColor;
    }
}
