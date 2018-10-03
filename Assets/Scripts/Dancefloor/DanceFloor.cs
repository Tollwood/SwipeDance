using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceFloor : MonoBehaviour {

    public GameState gameState;
	

	void Update () {
        gameObject.SetActive(gameState.remainingTime > 0);	
	}
}
