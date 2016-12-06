using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifePower : MonoBehaviour {

    public GameObject CameraGO;
    public GameObject LifeText;
    public GameObject PowerText;
	public AudioClip fire;
	public AudioClip ice;
	AudioSource audioHurt;
    [HideInInspector]
    public int Life;
    [HideInInspector]
    public int Power;

	// Use this for initialization
	void Start () {
        Life = 20;
        Power = 10;
		audioHurt = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (this.gameObject.name == "Angel")
        {
            LifeText.GetComponent<Text>().text = "Angel Health: " + Life.ToString();
            PowerText.GetComponent<Text>().text = "Holy Water: " + Power.ToString();
        }
        if (this.gameObject.name == "Demon")
        {
            LifeText.GetComponent<Text>().text = "Demon Health: " + Life.ToString();
            PowerText.GetComponent<Text>().text = "Destruction: " + Power.ToString();
        }
        if (Life <= 0)
            SceneManager.LoadScene("scene-01");

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor")
            CameraGO.GetComponent<CameraFollow>().isActive = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "iceberg" && this.gameObject.name == "Angel")
        {
			GetComponent<AudioSource>().PlayOneShot(ice, 0.7F);
			Life -= 2;
            gameObject.transform.FindChild("icetornade").gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(WaitFor(1,"angel"));
        }
        if (other.gameObject.name == "fairy" && this.gameObject.name == "Angel")
        {
            Power += 1;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "Fire" && this.gameObject.name == "Demon")
        {
			GetComponent<AudioSource>().PlayOneShot(fire, 0.7F);
			Life -= 2;
            gameObject.transform.FindChild("explosion").gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(WaitFor(1,"demon"));
        }
        if (other.gameObject.name == "ghost" && this.gameObject.name == "Demon")
        {
            Power += 1;
            Destroy(other.gameObject);
        }

    }

    IEnumerator WaitFor(float sec, string player)
    {
        yield return new WaitForSeconds(sec);
        if (player == "demon")
            gameObject.transform.FindChild("explosion").gameObject.SetActive(false);
        else
            gameObject.transform.FindChild("icetornade").gameObject.SetActive(false);
    }

}
