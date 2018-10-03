using UnityEngine;

public class DancefloorInput : MonoBehaviour {

    public Line firstLine;
    public Line secondLine;
    public GameState gameState;

	void Update(){
        if(Input.touchCount > 0 ){
            Touch firstTouch = Input.GetTouch(0);
            handleTouch(firstTouch, firstLine);  
          
            Touch secondTouch = Input.GetTouch(1);
            handleTouch(secondTouch, secondLine);
         
        } else {
            handleLeftClick();
        }

	}

    private void handleTouch(Touch touch, Line line)
    {
        if (isInsideDanceFloor(Input.mousePosition) && gameState.moveState == MoveState.WAITING) {
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            if (touch.phase == TouchPhase.Began) {
                line.StartDrawing(touchPosition);
            }
            line.GetComponent<Line>().UpdateLine(touchPosition);    
        }
        if (touch.phase == TouchPhase.Ended) {
            line.EndDrawing();
            VerifyMove();
        }
    }

    void handleLeftClick(){
        if(isInsideDanceFloor(Input.mousePosition) && gameState.moveState == MoveState.WAITING){
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0)){
                firstLine.StartDrawing(mousePosition);
            }

            if (Input.GetMouseButtonUp(0))
            {
                firstLine.EndDrawing();
                VerifyMove();
            }

            firstLine.GetComponent<Line>().UpdateLine(mousePosition);  
        }
    }

    void VerifyMove(){
        if (MoveVerificationLogic.verifyMove(firstLine, secondLine, gameState.currentMove))
        {
            gameState.moveState = MoveState.CORRECT;
            gameState.score += 1;
        }
        firstLine.Clear();
        secondLine.Clear();
    }

    private bool isInsideDanceFloor(Vector2 newPoint)
    {
        var ray = Camera.main.ScreenPointToRay(newPoint);

        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit) && "DanceFloor".Equals(hit.collider.tag))
        {
            return true;
        }
        return false;
    }


}
