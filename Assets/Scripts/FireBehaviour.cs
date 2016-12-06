using UnityEngine;
using System.Collections;

public class FireBehaviour : MonoBehaviour {
    float TIMEDELAY = 0.5f;
    float time;
    bool setDelay = false;


	// Use this for initialization
	void Start () {
        time = TIMEDELAY;
        transform.position = new Vector3(transform.position.x, transform.position.y, -1);
	}
	
	// Update is called once per frame
	void Update () {
	    if (setDelay == true)
        {
            time -= Time.deltaTime;
        }
        if (time <= 0)
        {
            this.gameObject.transform.FindChild("Collider2D").GetComponent<BoxCollider2D>().isTrigger = false;
            setDelay = false;
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "GetThus")
        {
            this.gameObject.transform.FindChild("Collider2D").GetComponent<BoxCollider2D>().isTrigger = true;
            setDelay = true;
            time = TIMEDELAY;
        }
        if (other.gameObject.name == "Demon")
        {
            this.gameObject.transform.FindChild("Collider2D").GetComponent<BoxCollider2D>().isTrigger = true;
            setDelay = true;
            time = TIMEDELAY/2;
        }

    }

}
