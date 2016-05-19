using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
    Rigidbody2D rb;
    Vector2 finalPos;
    Vector3 pos;
    bool posSet = false;
    float bulletSpeed = 10f;
    // Use this for initialization
    void Start () {
        pos = transform.position;
        pos.z = -2.32f;
        rb = GetComponent<Rigidbody2D>();
    }
	
	void Update () {
        if (posSet)
        {
            transform.position = Vector3.MoveTowards(transform.position, finalPos, bulletSpeed * Time.deltaTime);
            //transform.localRotation = Quaternion.LookRotation(finalPos);
        }

        if(transform.position == (Vector3)finalPos)
        {
            Destroy(gameObject);
        }
    }

    void LateUpdate()
    {
        
    }

    public void SetFinalPos(Vector2 pos)
    {
        finalPos = pos;
        posSet = true;
    }
    
}
