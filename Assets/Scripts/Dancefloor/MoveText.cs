using TMPro;
using UnityEngine;

public class MoveText : MonoBehaviour
{
    public bool leftMove;
    public GameState gameState;

    // Update is called once per frame
    void Update()
    {
        
        if (gameState.moveState == MoveState.CORRECT)
        {
            GetComponent<TextMeshProUGUI>().text = "";
        }
        if (gameState.moveState == MoveState.WAITING)
        {
            GetComponent<TextMeshProUGUI>().text = MoveTypeHelper.MoveTypeToString(gameState.currentMove, leftMove);
         
        }
    }
}
