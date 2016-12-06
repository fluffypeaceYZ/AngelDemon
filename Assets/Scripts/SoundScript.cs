using UnityEngine;
using System.Collections;

public class SoundScript : MonoBehaviour {
	public AudioClip thunder;
	public AudioClip waterfall;
	AudioSource audio;
	// Use this for initialization
	void Start () {

		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.S)) {
		
			audio.PlayOneShot(thunder, 0.7F);
		
		} 

		if (Input.GetKey (KeyCode.Keypad5)) {

			audio.PlayOneShot(waterfall, 0.7F);
		
		}
	
	}
}
