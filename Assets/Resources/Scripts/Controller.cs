using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
    public float coolDown;

    Vector3 rot;
    GameObject laser, laserStart, laserPoint;
    GameObject bulletPrefab;
    bool rotLeft = false, rotRight = false;
    float lastShoot;

    public float rotSpeed;

    // Use this for initialization
    void Start () {
        coolDown = 0.3f;
        lastShoot = 1f;
        laser = GameObject.Find("Player/Laser");
        laserPoint = GameObject.Find("Player/Laser/LaserPoint");
        laserStart = GameObject.Find("Player/Laser/LaserStart");
        bulletPrefab = (GameObject)Resources.Load("Prefab/Fire");
	}
	
	// Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) )
            Shoot();
    }

	void FixedUpdate () {
        rot = laser.transform.localEulerAngles;
        LaserMovement();
    }

    void LaserMovement()
    {
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)|| rotLeft)
        //if(rotLeft)
        {
            if (rot.z < 180)
                laser.transform.Rotate(Vector3.forward, rotSpeed * Time.deltaTime);
        }
		else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || rotRight)
        //else if (rotRight)
        {
            if (rot.z < 181 && rot.z > 0)
                laser.transform.Rotate(Vector3.back, rotSpeed * Time.deltaTime);
        }

        //clamp the rotation
        if (rot.z > 181 && rot.z < 270)
        {
            laser.transform.localEulerAngles = new Vector3(laser.transform.rotation.x, laser.transform.rotation.y, 180);

        }
        else if (rot.z > 270)
        {
            laser.transform.localEulerAngles = new Vector3(laser.transform.rotation.x, laser.transform.rotation.y, 0);
        }
    }

    public void RotateToLeft()
    {
        if (rot.z < 180 && rotLeft)
            laser.transform.Rotate(Vector3.forward, rotSpeed * Time.deltaTime);
    }

    public void RotateToRight()
    {
        if (rot.z < 181 && rot.z > 0 && rotRight)
            laser.transform.Rotate(Vector3.back, rotSpeed * Time.deltaTime);
    }

    public void SetTrueLeft()
    {
        rotLeft = true;
    }

    public void SetTrueRight()
    {
        rotRight = true;
    }

    public void Stop()
    {
        rotRight = rotLeft = false;
    }

    public void Shoot()
    {
		if ((Time.realtimeSinceStartup - lastShoot) > coolDown) 
		{
			GameObject bullet;
			BulletScript bulletScript;
			lastShoot = Time.realtimeSinceStartup;

			bullet = (GameObject)Instantiate(bulletPrefab, laserStart.transform.position, Quaternion.identity);
			bulletScript = bullet.GetComponent<BulletScript>();
			bulletScript.SetFinalPos(laserPoint.transform.position);	
		}
    }

}
