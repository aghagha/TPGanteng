using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {
    LineRenderer line;
    GameObject endPoint, startPoint;
	// Use this for initialization
	void Awake () {
        endPoint = GameObject.Find("Player/Laser/LaserPoint");
        startPoint = GameObject.Find("Player");
        line = GetComponent<LineRenderer>();
        line.SetPosition(0, startPoint.transform.position);
    }

    void Start()
    {
        line.SetPosition(0, new Vector3(startPoint.transform.position.x, startPoint.transform.position.y, -0.13f));
    }
	
	// Update is called once per frame
	void Update () {
        line.SetPosition(1, endPoint.transform.position);
	}
}
