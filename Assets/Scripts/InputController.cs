using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

    public GameObject CameraGO;
    public GameObject DemonGO;
    public Sprite DemonSprite;
    public GameObject AngelGO;
    public Sprite AngelSprite;
    float distanceX;
    float distanceY;
    float BOUNDARY_X = 6.0f;
    float BOUNDARY_Y = 6.0f;
    float shiftDistance = 0.05f;
    float thrust = 10.0f;
    float speed = 1.5f;
    Vector3 tempVector;

    // Use this for initialization
    void Start () {
        //Debug.Log(Screen.width + " : " + Screen.height);
        DemonGO.GetComponent<Animator>().speed = 0.0f;
        DemonGO.GetComponent<SpriteRenderer>().sprite = DemonSprite;
        AngelGO.GetComponent<Animator>().speed = 0.0f;
        AngelGO.GetComponent<SpriteRenderer>().sprite = AngelSprite;
    }

    // Update is called once per frame
    void Update()
    {

        distanceX = DemonGO.transform.position.x - AngelGO.transform.position.x;
        distanceY = DemonGO.transform.position.y - AngelGO.transform.position.y;
        if (distanceX <= -BOUNDARY_X)
        {
            tempVector = new Vector3(shiftDistance, 0, 0);
            DemonGO.transform.position += tempVector;
            AngelGO.transform.position -= tempVector;
        }
        else if (distanceX >= BOUNDARY_X)
        {
            tempVector = new Vector3(-shiftDistance, 0, 0);
            DemonGO.transform.position += tempVector;
            AngelGO.transform.position -= tempVector;
        }
        if (distanceY <= -BOUNDARY_Y)
        {
            tempVector = new Vector3(0, shiftDistance, 0);
            DemonGO.transform.position += tempVector;
            AngelGO.transform.position -= tempVector;
        }
        else if (distanceY >= BOUNDARY_Y)
        {
            tempVector = new Vector3(0, -shiftDistance, 0);
            DemonGO.transform.position += tempVector;
            AngelGO.transform.position -= tempVector;
        }
        distanceX = Mathf.Abs(distanceX);
        distanceY = Mathf.Abs(distanceY);

        //  Input Control for Demon (WASD)
        if (Input.GetKey(KeyCode.W))
        {
            DemonGO.GetComponent<Animator>().speed = 0.7f;
            DemonGO.GetComponent<Animator>().SetInteger("MoveDirection", 0);
            if (distanceX <= BOUNDARY_X && distanceY <= BOUNDARY_Y)
                DemonGO.transform.Translate(Vector3.up * Time.deltaTime * speed);
            DemonGO.GetComponent<Rigidbody2D>().AddForce(transform.up * thrust);
            CameraGO.GetComponent<CameraFollow>().isActive = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            DemonGO.GetComponent<Animator>().speed = 0.7f;
            DemonGO.GetComponent<Animator>().SetInteger("MoveDirection", 1);
            if (distanceX <= BOUNDARY_X && distanceY <= BOUNDARY_Y)
                DemonGO.transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            DemonGO.GetComponent<Animator>().speed = 0.7f;
            DemonGO.GetComponent<Animator>().SetInteger("MoveDirection", 2);
            if (distanceX <= BOUNDARY_X && distanceY <= BOUNDARY_Y)
                DemonGO.transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            DemonGO.GetComponent<Animator>().speed = 0.7f;
            DemonGO.GetComponent<Animator>().SetInteger("MoveDirection", 3);
            if (distanceX <= BOUNDARY_X && distanceY <= BOUNDARY_Y)
                DemonGO.transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKeyDown(KeyCode.S) && DemonGO.GetComponent<LifePower>().Power > 0)
        {
            GameObject lightning = Instantiate(Resources.Load<GameObject>("lightning"));
            lightning.name = "lightning";
            lightning.transform.localScale = new Vector2(0.5f, 0.7f);
            lightning.transform.position = new Vector2(DemonGO.transform.position.x, 4.25f);
            DemonGO.GetComponent<LifePower>().Power -= 1;
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            DemonGO.GetComponent<Animator>().speed = 0.0f;
        }

        //  Input Control for Angel (Arrows)
        if (Input.GetKey(KeyCode.Keypad8))
        {
            AngelGO.GetComponent<Animator>().speed = 0.7f;
            AngelGO.GetComponent<Animator>().SetInteger("MoveDirection", 0);
            if (distanceX <= BOUNDARY_X && distanceY <= BOUNDARY_Y)
                AngelGO.transform.Translate(Vector3.up * Time.deltaTime * speed);
            AngelGO.GetComponent<Rigidbody2D>().AddForce(transform.up * thrust);
            CameraGO.GetComponent<CameraFollow>().isActive = false;
        }
        if (Input.GetKey(KeyCode.Keypad6))
        {
            AngelGO.GetComponent<Animator>().speed = 0.7f;
            AngelGO.GetComponent<Animator>().SetInteger("MoveDirection", 1);
            if (distanceX <= BOUNDARY_X && distanceY <= BOUNDARY_Y)
                AngelGO.transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.Keypad5))
        {
            AngelGO.GetComponent<Animator>().speed = 0.7f;
            AngelGO.GetComponent<Animator>().SetInteger("MoveDirection", 2);
            if (distanceX <= BOUNDARY_X && distanceY <= BOUNDARY_Y)
                AngelGO.transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.Keypad4))
        {
            AngelGO.GetComponent<Animator>().speed = 0.7f;
            AngelGO.GetComponent<Animator>().SetInteger("MoveDirection", 3);
            if (distanceX <= BOUNDARY_X && distanceY <= BOUNDARY_Y)
                AngelGO.transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKeyDown(KeyCode.Keypad5) && AngelGO.GetComponent<LifePower>().Power > 0)
        {
            GameObject waterfall = Instantiate(Resources.Load<GameObject>("waterfall"));
            waterfall.name = "waterfall";
            waterfall.transform.localScale = new Vector2(0.01f, 2.5f);
            waterfall.transform.position = new Vector2(AngelGO.transform.position.x, 0.7f);
            AngelGO.GetComponent<LifePower>().Power -= 1;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            AngelGO.GetComponent<Animator>().speed = 0.0f;
        }

    }
}
