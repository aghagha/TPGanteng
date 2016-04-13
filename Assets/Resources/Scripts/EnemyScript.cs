using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
    Vector2 finalPos;
    GameObject target, camera;
    LevelDesign levelDesign;

    float speed = 5f;
    float hp = 1f;

	// Use this for initialization
	void Start () {
        target = GameObject.Find("Player");
    
        camera = GameObject.Find("Main Camera");
        levelDesign = camera.GetComponent<LevelDesign>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Time.timeScale != 0)transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "bullets")
        {
            hp -= 1;
            if(hp == 0)
            {
                Destroy(col.gameObject);
                Destroy(gameObject);
                levelDesign.AddScore(1);
            }
        }
        else if(col.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);
            levelDesign.GameOver();
        }
    }
}
