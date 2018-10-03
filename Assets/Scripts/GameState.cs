using UnityEngine;

public class GameState : MonoBehaviour {

    public Song song;
    public int score = 0;
    public MoveTypes currentMove = MoveTypes.UP;
    public MoveState moveState = MoveState.WAITING;
    public float remainingTime;
    public float gameTime;
    public bool activeGame;

    private void Start()
    {
        gameTime = PlayerPrefs.GetFloat("gameTime", song.getLength());
    }
}