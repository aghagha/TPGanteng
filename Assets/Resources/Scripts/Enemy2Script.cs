using UnityEngine;
using System.Collections;

public class Enemy2Script : MonoBehaviour
{
    Vector2 finalPos, moveDirection;
    GameObject target, camera;
    LevelDesign levelDesign;
    SFXManager sfxManager;
    Rigidbody2D rb;
    public Sprite burgerHitKiri, burgerHitKanan;

    bool isGrounded = false, isAlive = true;
    float speed = 1f;
    float knockback = 100f;
    float hp = 2f;

    public float maxVelocity, currVelo;
    
    // Use this for initialization
    void Start()
    {
        target = GameObject.Find("Player");
        sfxManager = GameObject.Find("MusicBox").GetComponent<SFXManager>();
        camera = GameObject.Find("Main Camera");
        levelDesign = camera.GetComponent<LevelDesign>();

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }


    void FixedUpdate()
    {
        if (isGrounded && Time.timeScale != 0 && isAlive)
        {
            rb.gravityScale = 0;
            rb.AddForce((target.transform.position - transform.position).normalized * speed * Time.deltaTime, ForceMode2D.Impulse);
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "bullets")
        {
            sfxManager.PlaySFX();
            hp -= 1;
            if (hp == 0)
            {
                isAlive = false;
                rb.AddForce((transform.position - col.transform.position).normalized * 5000 * Time.deltaTime, ForceMode2D.Impulse);
                levelDesign.AddScore(1);
            }
            else
            {
                if(transform.position.x < col.transform.position.x)
                {
                    GetComponent<SpriteRenderer>().sprite = burgerHitKiri;
                } else
                {
                    GetComponent<SpriteRenderer>().sprite = burgerHitKanan;
                }
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
