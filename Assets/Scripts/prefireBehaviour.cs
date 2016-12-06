using UnityEngine;
using System.Collections;

public class prefireBehaviour : MonoBehaviour {
    float time = 1.0f;
    float scaleY = 0.01f;

    // Use this for initialization
    void Awake()
    {
        this.transform.localScale = new Vector2(0.01f, 0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            Vector3 scale = transform.localScale;
            if (scale.y <= 0.4f)
            {
                scaleY += 0.01f;
                transform.localScale = new Vector2(scaleY/2, scaleY);
                transform.position = new Vector2(transform.position.x, transform.position.y + (scaleY/20.0f));
                time -= Time.deltaTime;
            }
        }
    }
}
