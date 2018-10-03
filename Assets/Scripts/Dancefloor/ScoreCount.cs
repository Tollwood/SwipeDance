using TMPro;
using UnityEngine;


public class ScoreCount : MonoBehaviour {

    public GameState gameState;

	void Update () {
        GetComponent<TextMeshProUGUI>().text = "" + gameState.score ;
	}
}
