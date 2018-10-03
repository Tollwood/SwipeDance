using TMPro;
using UnityEngine;

public class StepCount : MonoBehaviour {

    public SoundManager soundManager;
	
	void Update () {
        GetComponent<TextMeshProUGUI>().text = "" + soundManager.stepCount;
	}
}
