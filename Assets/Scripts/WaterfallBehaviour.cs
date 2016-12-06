using UnityEngine;
using System.Collections;

public class WaterfallBehaviour : MonoBehaviour {

    float time = 1.0f;
    float scaleX = 0.01f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (time > 0)
        {
            Vector3 scale = transform.localScale;
            if (scale.x <= 0.5f)
            {
                scaleX += 0.01f;
                transform.localScale = new Vector2(scaleX, 2.5f);
                time -= Time.deltaTime;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Fire")
        {
            GameObject ghost = Instantiate(Resources.Load<GameObject>("ghost"));
            ghost.name = "ghost";
            ghost.transform.position = other.transform.position;
            Destroy(other.gameObject);
        }
    }
}
