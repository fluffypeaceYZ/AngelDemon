using UnityEngine;
using System.Collections;

public class lightningBehaviour : MonoBehaviour {

    float time = 1.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (time < 0)
        {
            Destroy(gameObject);
        }
        time -= Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "iceberg")
        {
            GameObject fairy = Instantiate(Resources.Load<GameObject>("fairy"));
            fairy.name = "fairy";
            fairy.transform.position = other.transform.position;
            Destroy(other.gameObject);
        }
    }
}
