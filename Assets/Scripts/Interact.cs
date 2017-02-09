using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Interact : MonoBehaviour {
    private bool fadeIn;

    private RaycastHit hit;
    private Ray ray;
    public Camera cam;
    private bool toggleInteractGUI;
    public Fade fadeObj;
    public Texture circle;

    private GUIStyle style;
    public Text text;
    private bool Text1, Text2, Text3, Text4;

    public Text text2;
    private int eCount;

    public Text text3;
    private bool eDoor;

    // Use this for initialization
    void Start () {
        fadeIn = true;

        toggleInteractGUI = false;
        Text1 = Text2 = Text3 = Text4 = false;
        style = new GUIStyle();
        style.fontSize = 20;
        style.normal.textColor = Color.white;

        eCount = 0;
        eDoor = false;
    }

	// Update is called once per frame
	void Update () {
        StartCoroutine(offFade(1));
        if (fadeIn) {
            fadeObj.StartFade(new Color(0, 0, 0, 0), 1);
        }

        ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        if (Physics.Raycast(ray, out hit, 5.0f)) {
            if (hit.collider.gameObject.tag == "Interactable") {
                toggleInteractGUI = true;
                if (Input.GetKey(KeyCode.E)) {
                    fadeObj.StartFade(new Color(0, 0, 0), 2);
                    StartCoroutine(sceneChange());
                }
            }
            if (hit.collider.gameObject.tag == "Door")
            {
                if (Input.GetKey(KeyCode.E))
                {
                    eDoor = true;
                }
            }
        } else {
            toggleInteractGUI = false;
        }

        if (Input.GetKey(KeyCode.Escape)) {
            Application.Quit();
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            eCount++;
        }
    }

    IEnumerator sceneChange() {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Zine");
    }

    void OnGUI() {
        GUI.DrawTexture(new Rect(Screen.width / 2, Screen.height / 2, 7, 7), circle);
        if (toggleInteractGUI) {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 1.2f, 100, 20), "Press E to Read", style);
        }
        
        //Easter Egg - taking too damn long
        if (Time.timeSinceLevelLoad > 30 && !Text1) {
            StartCoroutine(firstText(5.0f));
        } else if (Time.timeSinceLevelLoad > 60 && !Text2) {
            StartCoroutine(secondText(5.0f));
        } else if (Time.timeSinceLevelLoad > 90 && !Text3) {
            StartCoroutine(thirdText(5.0f));
        } else if (Time.timeSinceLevelLoad > 120 && !Text4) {
            StartCoroutine(fourthText(5.0f));
        }

        //Easter Egg - pressing E 500 times
        if (eCount == 50)
        {
            StartCoroutine(pressedE(7.5f));
        } else if (eCount == 100)
        {
            StartCoroutine(pressedE2(5.0f));
        } else if (eCount == 200)
        {
            StartCoroutine(pressedE3(5.0f));
        } else if (eCount == 325)
        {
            StartCoroutine(pressedE4(3.0f));
        } else if (eCount == 500)
        {
            StartCoroutine(pressedE5(7.5f));
        }

        //Easter Egg - trying to leave
        if (eDoor)
        {
            StartCoroutine(pressedDoor(5.0f));
        }
    }

    IEnumerator firstText(float delay)
    {
        text.enabled = true;
        text.text = "There's literally nothing to do here. Just walk up to the book and press E";
        yield return new WaitForSeconds(delay);
        Text1 = true;
        text.enabled = false;
    }

    IEnumerator secondText(float delay)
    {
        text.enabled = true;
        text.text = "I hope you're not observing the dust float around...";
        yield return new WaitForSeconds(delay);
        Text2 = true;
        text.enabled = false;
    }

    IEnumerator thirdText(float delay)
    {
        text.enabled = true;
        text.text = "Why are you STILL in this part of the game??? Just quit at this point";
        yield return new WaitForSeconds(delay);
        Text3 = true;
        text.enabled = false;
    }

    IEnumerator fourthText(float delay)
    {
        text.enabled = true;
        text.text = "I'll quit for you";
        yield return new WaitForSeconds(delay);
        Text4 = true;
        text.enabled = false;
        Application.Quit();
    }

    IEnumerator pressedE(float delay)
    {
        text2.enabled = true;
        text2.text = "You went around touching every little thing in the room, but it didn't make a single difference, nor did it advance the story in any way";
        yield return new WaitForSeconds(delay);
        text2.enabled = false;
    }

    IEnumerator pressedE2(float delay)
    {
        text2.enabled = true;
        text2.text = "Are you serious? You pressed 'E' 100 times now. Stop";
        yield return new WaitForSeconds(delay);
        text2.enabled = false;
    }

    IEnumerator pressedE3(float delay)
    {
        text2.enabled = true;
        text2.text = "Do you enjoy wasting your life like this?";
        yield return new WaitForSeconds(delay);
        text2.enabled = false;
    }

    IEnumerator pressedE4(float delay)
    {
        text2.enabled = true;
        text2.text = "Your parents must be proud";
        yield return new WaitForSeconds(delay);
        text2.enabled = false;
    }

    IEnumerator pressedE5(float delay)
    {
        text2.enabled = true;
        text2.text = "This is now 'Press E Simulator Game'. Please continue to press E for the next 5 minutes to see a special message";
        yield return new WaitForSeconds(delay);
        text2.enabled = false;
    }

    IEnumerator pressedDoor(float delay)
    {
        text3.enabled = true;
        text3.text = "IT'S LOCKED! YOU'RE TRAPPED IN HERE FOREVER! It's not a real door, but we'll pretend it's locked";
        yield return new WaitForSeconds(delay);
        text3.enabled = false;
        eDoor = false;
    }

    IEnumerator offFade(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        fadeIn = false;
    }
}