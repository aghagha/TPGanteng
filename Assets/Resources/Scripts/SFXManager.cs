using UnityEngine;
using System.Collections;

public class SFXManager : MonoBehaviour {
    public AudioClip splash1, splash2, splash3;
    AudioSource audioSource;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlaySFX()
    {
        int temp = Random.Range(1, 4);
        switch (temp)
        {
            case 1:
                audioSource.PlayOneShot((splash1));
                break;
            case 2:
                audioSource.PlayOneShot((splash2));
                break;
            case 3:
                audioSource.PlayOneShot((splash3));
                break;
        }
        
    }
}
