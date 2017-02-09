using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    public GameObject player;
    private float speed;
    public Camera cam;
    public AudioClip footsteps;
    private AudioSource sounds;

	// Use this for initialization
	void Start () {
        Screen.SetResolution(1280, 960, false);
        speed = 7.5f;

        sounds = GetComponent<AudioSource>();
        sounds.clip = footsteps;
        sounds.loop = true;
        sounds.volume = 0.25f;
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.W)) { 
            transform.position += cam.transform.TransformDirection(Vector3.forward * speed * Time.deltaTime);
            if (!sounds.isPlaying) {
                sounds.Play();
            }
        } else {
            sounds.Pause();
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.position += cam.transform.TransformDirection(Vector3.left * speed * Time.deltaTime);
            if (!sounds.isPlaying) {
                sounds.Play();
            }
        }
        if (Input.GetKey(KeyCode.S)) {
            transform.position += cam.transform.TransformDirection(Vector3.back * speed * Time.deltaTime);
            if (!sounds.isPlaying) {
                sounds.Play();
            }
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.position += cam.transform.TransformDirection(Vector3.right * speed * Time.deltaTime);
            if (!sounds.isPlaying) {
                sounds.Play();
            }
        }
        transform.position = new Vector3(transform.position.x, 3, transform.position.z);
    }
}
