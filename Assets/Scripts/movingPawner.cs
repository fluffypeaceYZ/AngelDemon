using UnityEngine;
using System.Collections;

public class movingPawner : MonoBehaviour {

    int sign = -1;
    float speed = 2.0f;
    float COUNTDOWN = 2.0f;
    float time;
    //float thrust = 2.0f;
    float RandNum;

    // Use this for initialization
    void Start () {
        time = COUNTDOWN;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(sign * Vector2.left * Time.deltaTime * speed);
        time -= Time.deltaTime;
        if (time <= 0f)
        {
            RandNum = Random.Range(0, 3);
            if (RandNum == 1)
            {
                GameObject prefire = Instantiate(Resources.Load<GameObject>("preFire"));
                prefire.name = "preFire";
                Vector2 newPos = gameObject.transform.position;
                newPos.y += 0.0f;
                prefire.transform.position = newPos;
                prefire.transform.position = new Vector3(prefire.transform.position.x, prefire.transform.position.y, 1.0f);
                StartCoroutine(WaitFor(1.0f, newPos, prefire));
            }
            RandNum = Random.Range(0, 3);
            if (RandNum == 1)
            {
                GameObject preicing = Instantiate(Resources.Load<GameObject>("preicing"));
                preicing.name = "preicing";
                Vector2 newPos = gameObject.transform.position;
                newPos.y += 2.0f;
                preicing.transform.position = newPos;
                StartCoroutine(WaitFor(1.0f,newPos,preicing));
            }
            time = COUNTDOWN;
        }
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            sign *= -1;
        }
    }

    IEnumerator WaitFor(float sec, Vector2 newPos, GameObject preGO)
    {
        if (preGO.name == "preicing")
        {
            yield return new WaitForSeconds(sec);
            GameObject iceberg = Instantiate(Resources.Load<GameObject>("iceberg"));
            iceberg.name = "iceberg";
            iceberg.transform.position = newPos;
            Destroy(preGO);
        }
        else
        {
            yield return new WaitForSeconds(sec);
            GameObject fire = Instantiate(Resources.Load<GameObject>("Fire"));
            fire.name = "Fire";
            fire.transform.position = newPos;
            Destroy(preGO);
        }


    }
}
