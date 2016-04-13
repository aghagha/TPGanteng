using UnityEngine;
using System.Collections;

public class Enemy2Script : MonoBehaviour
{
    Vector2 finalPos;
    GameObject target, camera;
    LevelDesign levelDesign;
    Rigidbody2D rb;
    bool isGrounded = false;

    float speed = 1f;
    float knockback = 30f;
    float hp = 2f;
    
    // Use this for initialization
    void Start()
    {
        target = GameObject.Find("Player");

        camera = GameObject.Find("Main Camera");
        levelDesign = camera.GetComponent<LevelDesign>();

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded && Time.timeScale != 0)
        {
            rb.gravityScale = 0;
            rb.AddForce((target.transform.position - transform.position).normalized * speed * Time.deltaTime, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "bullets")
        {
            hp -= 1;
            if (hp == 0)
            {
                Destroy(gameObject);
                levelDesign.AddScore(1);
            }
            else
            {
                rb.AddForce((transform.position - target.transform.position).normalized * knockback * Time.deltaTime, ForceMode2D.Impulse);
            }
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);
            levelDesign.GameOver();
        }
        else if(col.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }
}
