using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.EventSystems;

public class ButtonHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Play() {
        SceneManager.LoadScene("Level Selector");
    }

    public void PlayLevel()
    {
        SceneManager.LoadScene("Level " + EventSystem.current.currentSelectedGameObject.name);
    }

    public void ToLevelSelector()
    {
        SceneManager.LoadScene("Level Selector");
    }

}
