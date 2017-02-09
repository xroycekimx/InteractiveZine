using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Intro : MonoBehaviour {
    public Fade fadeObj;

    // Use this for initialization
    void Start () {
        Screen.SetResolution(1280, 960, false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.E)) {
            fadeObj.StartFade(new Color(0, 0, 0), 2);
            StartCoroutine(sceneChange());
        }
        
        if (Input.GetKey(KeyCode.Escape)) {
            Application.Quit();
        }
    }

    IEnumerator sceneChange()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Library");
    }
}
