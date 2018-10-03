using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {
    
    public TextMeshProUGUI highScoreValue;

    private void OnEnable(){
        highScoreValue.text = "" + PlayerPrefs.GetInt("Highscore");
    }

    public void PlayArcadeGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

    public void PlayWalzerGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
