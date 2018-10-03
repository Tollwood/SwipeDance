using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour {

    Dictionary<int, GameObject> touchedObjects;
	
	void Start () {
        touchedObjects = new Dictionary<int, GameObject>();	
	}
	
	void Update () {

        if(Input.touchCount == 0 ){
            HandleMouseClick();
        }

        foreach(Touch touch in Input.touches){
                
            if (touch.phase == TouchPhase.Began) {
                touchedObjects.Add(touch.fingerId, getShoeAt(touch.position));
            }

            if (touch.phase == TouchPhase.Moved){
                GameObject objectToMove;
                touchedObjects.TryGetValue(touch.fingerId, out objectToMove);
                MoveObject(objectToMove, touch.position);
            }

            if (touch.phase == TouchPhase.Ended){
                touchedObjects.Remove(touch.fingerId);
            }
        }
	}

    private void HandleMouseClick()
    {
        if(Input.GetMouseButtonDown(0)){
            MoveObject(getShoeAt(Input.mousePosition), Input.mousePosition);
        }
    }

    private void MoveObject(GameObject objectToMove, Vector2 newPosition)
    {
        if(objectToMove != null) {
            Debug.Log("Moving Gameobject: " + objectToMove.name);
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(newPosition);
            objectToMove.transform.position = new Vector3(worldPos.x, worldPos.y, 0);
        }


    }

    private GameObject getShoeAt(Vector2 newPoint)
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(newPoint);
        RaycastHit2D hit =  Physics2D.Raycast(worldPoint,Vector2.zero);

        if(hit.collider != null && (hit.collider.gameObject.tag == "LeftShoe" || hit.collider.gameObject.tag == "RightShoe" )){
            return hit.collider.gameObject;
        }
        return null;

    }


}
