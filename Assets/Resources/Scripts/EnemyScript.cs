using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
    Vector2 finalPos;
    GameObject target, camera;
    LevelDesign levelDesign;
    SFXManager sfxManager;
    Rigidbody2D rb;
    public Sprite burgerHit;

    float speed = 5f;
    float hp = 1f;
    bool isAlive;

	// Use this for initialization
	void Start () {
        target = GameObject.Find("Player");
        camera = GameObject.Find("Main Camera");
        levelDesign = camera.GetComponent<LevelDesign>();
        sfxManager = GameObject.Find("MusicBox").GetComponent<SFXManager>();
        rb = GetComponent<Rigidbody2D>();
        isAlive = true;
	}
	
	// Update is called once per frame
	void Update () {
        if(Time.timeScale != 0 && isAlive)transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        if(transform.position.y < -6)
        {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "bullets")
        {
            sfxManager.PlaySFX();
            hp -= 1;
            if(hp == 0)
            {
                Destroy(col.gameObject);
                //Destroy(gameObject);
                GetComponent<SpriteRenderer>().sprite = burgerHit;
                BurgerDie();
                levelDesign.AddScore(1);
            }
        }
        else if(col.gameObject.tag == "Player")
        {
            if (isAlive)
            {
                Destroy(col.gameObject);
                levelDesign.GameOver();
            }
        }
    }

    void BurgerDie()
    {
        GetComponent<Collider2D>().enabled = false;
        rb.velocity = new Vector2(0f, 0f);
        rb.gravityScale = 1;
        isAlive = false;
    }

}
