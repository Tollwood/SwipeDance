using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class OptionMenu : MonoBehaviour {
    
    public Slider difficultySlider;
    public Slider durationSlider;
    public TextMeshProUGUI durtionValue;

    void Start() {
        difficultySlider.value = PlayerPrefs.GetInt("Difficulty", 0);
        durationSlider.value = PlayerPrefs.GetFloat("gameTime", durationSlider.maxValue);
        durtionValue.text = "" + durationSlider.value;
    }

    public void DifficultyChanged()
    {
        PlayerPrefs.SetInt("Difficulty", (int)difficultySlider.value);
    }

    public void DurationChanged()
    {
        PlayerPrefs.SetFloat("gameTime", durationSlider.value);
        durtionValue.text = "" + durationSlider.value;
    }

    public void ResetHighscore()
    {
        PlayerPrefs.SetInt("Highscore", 0);
    }
}
