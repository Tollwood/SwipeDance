using TMPro;
using UnityEngine;



public class Timer : MonoBehaviour
{

    public GameState gameState;

    public void Update() {
        float remainingTime = gameState.remainingTime;
            string minutes = ((int)remainingTime / 60).ToString();
            string seconds = (remainingTime % 60).ToString("f0");
            if (seconds.Length == 1){
                seconds = seconds.PadLeft(2, '0');
            }
        GetComponent<TextMeshProUGUI>().text = minutes + ":" + seconds;  
    }
}
