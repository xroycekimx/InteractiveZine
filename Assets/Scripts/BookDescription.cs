using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BookDescription : MonoBehaviour {
    public Book book;
    private bool descriptionToggle;
    private GUIStyle style;
    private string text, text2;
    private int textWidth, text2Width;

    // Use this for initialization
    void Start () {
        descriptionToggle = false;

        style = new GUIStyle();
        style.fontSize = 24;
        style.normal.textColor = Color.white;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            descriptionToggle = !descriptionToggle;
        }
    }

    void OnGUI()
    {
        GUI.depth = 0;
        if (!descriptionToggle)
        {
            text = "";
            text2 = "";
        }
        else if (descriptionToggle)
        {
            StartCoroutine(showDescription());
        }
        textWidth = text.Length * 10;
        text2Width = text2.Length * 10;
        GUI.Label(new Rect(Screen.width / 2 - textWidth / 2, Screen.height / 2 - 50, textWidth, Screen.height), text, style);
        GUI.Label(new Rect(Screen.width / 2 - text2Width / 2, Screen.height / 2 - 15, text2Width, Screen.height), text2, style);
    }

    IEnumerator showDescription()
    {
        //Fiction stories
        if (book.currentPage == 0)
        {
            text = "Silver Web, Issue 15, January 2002";
        }
        else if (book.currentPage == 2)
        {
            text = "Table of Contents";
        }
        else if (book.currentPage > 2 && book.currentPage <= 6)
        {
            text = "Conjuring the Disclaimers - Colin James";
        }
        else if (book.currentPage > 6 && book.currentPage <= 12)
        {
            text = "Ye Olde Ephemera Shoppe - Carol Orlock";
        }
        else if (book.currentPage > 12 && book.currentPage <= 14)
        {
            text = "Midwiving the World - Michael Bishop";
        }
        else if (book.currentPage > 14 && book.currentPage <= 20)
        {
            text = "One Window - Scott Thomas";
        }
        else if (book.currentPage > 20 && book.currentPage <= 26)
        {
            text = "The Apocrypha According to Cleveland - Daniel Abraham";
        }
        else if (book.currentPage > 26 && book.currentPage <= 34)
        {
            text = "Oh Goat-Foot God of Arcady! - Brian Stableford";
        }
        else if (book.currentPage > 34 && book.currentPage <= 42)
        {
            text = "An Interview With Scott Eagle - Jeff VanderMeer";
        }
        else if (book.currentPage > 42 && book.currentPage <= 50)
        {
            text = "A Lesser Michaelangelo - T. Jackson King";
        }
        else if (book.currentPage > 50 && book.currentPage <= 54)
        {
            text = "The Rain King - Michael S. Gentry";
        }
        else if (book.currentPage > 54 && book.currentPage <= 56)
        {
            text = "The Waiting Room - Vera Searles";
        }
        else if (book.currentPage > 56 && book.currentPage <= 62)
        {
            text = "The Comedian - Stepan Chapman";
        }
        else {
            text = "";
        }

        //Poems
        if (book.currentPage == 6)
        {
            text2 = "This is a Story You Already Know - Lois Marie Harrod";
        }
        else if (book.currentPage == 14)
        {
            text2 = "The Marriage of Lip & Ear - E.P. Allan";
        }
        else if (book.currentPage == 20)
        {
            text2 = "Who Knows The Homonym For 'Ritual Murder' - William John Watkins";
        }
        else if (book.currentPage == 26)
        {
            text2 = "Main Street - Scott Keeney";
        }
        else if (book.currentPage == 50)
        {
            text2 = "The Legend of Treat - Scott Keeney";
        }
        else if (book.currentPage == 56)
        {
            text2 = "The Rescue - Gary Myers";
        }
        else
        {
            text2 = "";
        }
        yield return null;
    }
}
