using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Music : MonoBehaviour {

    void Awake() {
        gameObject.GetComponent<AudioSource>().volume = 0.2f;
        gameObject.GetComponent<AudioSource>().loop = true;
        DontDestroyOnLoad(gameObject);
        gameObject.GetComponent<AudioSource>().Play();
    }
}