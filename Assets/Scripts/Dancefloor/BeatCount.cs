using TMPro;
using UnityEngine;

public class BeatCount : MonoBehaviour {

    public SoundManager soundManager;
	
	void Update () {
        int beatCount = (int)(soundManager.songPosInBeats % 4 + 1);
        GetComponent<TextMeshProUGUI>().text = "Beat Count: " + beatCount;
	}
}
