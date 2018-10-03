using System;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    
    int currentStep = 0;

    public WinningModal winningModal;
    public GameState gameState;
    public int stepCount;
    public int beatCount;
    public float songPosInBeats = 0f;
    public bool play = false;

    void Start () {
        AudioManager audioManager = GetComponent<AudioManager>();
        audioManager.PlaySong(gameState.song);
        nextMove();
	}
	
	void Update () {
        AudioManager audioManager = GetComponent<AudioManager>();
        float songPositionInSecs = audioManager.songPositionInSecs();
        int remainingTime = audioManager.remainingTime(gameState.gameTime);
        if (remainingTime < 0f) {
            stopCurrentGame();
        }
        else {
            songPosInBeats = songPositionInSecs / gameState.song.secPerBeat();
            float threeQuarterBeatPos = songPosInBeats * gameState.song.beat;
            stepCount = (int)(threeQuarterBeatPos) % 3 + 1;
            gameState.remainingTime = remainingTime;

            int number = (int)Math.Truncate(threeQuarterBeatPos);
            if (number > currentStep)
            {
                nextMove();
                currentStep = number;
            }

            if (gameState.moveState == MoveState.CORRECT)
            {
                gameState.moveState = MoveState.COMPLETE;
            }
        }
	}

    private void stopCurrentGame()
    {
        GetComponent<AudioManager>().Stop();
        winningModal.gameObject.SetActive(true);
        UpdateHighscore();
    }

    private void UpdateHighscore()
    {
        int currentHighScore = PlayerPrefs.GetInt("Highscore", 0);
        if (currentHighScore < gameState.score)
        {
            PlayerPrefs.SetInt("Highscore", gameState.score);
        } 
    }

    private void nextMove()
    {
        gameState.moveState = MoveState.WAITING;
        int difficulty = PlayerPrefs.GetInt("Difficulty");
        gameState.currentMove = MoveTypeHelper.randomMove(gameState.currentMove, difficulty);
    }

}
