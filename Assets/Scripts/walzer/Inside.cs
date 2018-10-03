using UnityEngine;

public class Inside : MonoBehaviour {

    public GameState gameState;
    public string TriggerOnTag;
    bool isActive = false;

    void OnEnable() {
        isActive = true;
    }
    void Update () {
        
        BoxCollider2D box =  this.GetComponent<BoxCollider2D>();
        Rect rect = new Rect(box.bounds.min, box.bounds.max);

        Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D[] hits = Physics2D.RaycastAll(box.bounds.center,Vector2.zero);
        foreach(RaycastHit2D hit in hits){
            
            if (hit.collider.gameObject.tag.Equals(TriggerOnTag) && isActive)
            {
                Debug.Log(this.name + "trigers on: " + TriggerOnTag +  hit.collider.gameObject.tag);
                gameState.score += 1;
                isActive = false;
            }    
        }
	}
}
