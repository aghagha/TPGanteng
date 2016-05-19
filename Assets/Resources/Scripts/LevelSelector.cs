using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {
    string selected;
    public Text highScoreText;
    MyPlayerPref myPlayerPref;
    // Use this for initialization
    void Start () {
        //highScoreText = ((Object)GameObject.Find("HighScoreText")) as Text;
        myPlayerPref = GetComponent<MyPlayerPref>();
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void SetSelected()
    {
        selected = EventSystem.current.currentSelectedGameObject.name;
        ShowHighScore();
    }

    public void PlayLevel()
    {
        SceneManager.LoadScene("Level " + selected);
    }

    public void ShowHighScore()
    {
        highScoreText.text = "High Score : " + (myPlayerPref.GetHighScore("Level " + selected)).ToString();
    }

}
