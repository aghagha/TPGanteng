using UnityEngine;
using System.Collections;

public class MyPlayerPref : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public float GetHighScore(string level)
    {
        return PlayerPrefs.GetFloat(level+"HighScore", 0);
    }

    public void SetHighScore(float score, string level)
    {
        PlayerPrefs.SetFloat(level+"HighScore", score);
        
    }


}
