using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
    Vector2 finalPos;
    Vector3 pos;
    bool posSet = false;
    float bulletSpeed = 10f;
    // Use this for initialization
    void Start () {
        pos = transform.position;
        pos.z = -2.32f;
	}
	
	// Update is called once per frame
	void Update () {
        if (posSet)
        {
            transform.position = Vector3.MoveTowards(transform.position, finalPos, bulletSpeed * Time.deltaTime);
        }

        if(transform.position == (Vector3)finalPos)
        {
            Destroy(gameObject);
        }
	}

    public void SetFinalPos(Vector2 pos)
    {
        finalPos = pos;
        posSet = true;
    }
}
