using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinningModal : MonoBehaviour {

    public TextMeshProUGUI MaxScore;
    public TextMeshProUGUI YourScore;
    public TextMeshProUGUI Rating;

    public GameState gameState;

    private void OnEnable() {
        int maxScore = gameState.song.getMaxScore(gameState.gameTime);
        MaxScore.text = "Max Score: " + maxScore;
        YourScore.text = " Your Score: " + gameState.score;
        Rating.text = WinningHelper.getRating(maxScore, gameState.score);
    }

    public void GotoMainMenu(){
        SceneManager.LoadScene(0);
    }
}
