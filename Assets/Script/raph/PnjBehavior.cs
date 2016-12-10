using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PnjBehavior : MonoBehaviour {

    public float speed;
    public GameObject target;
    private Vector3 targetVector;

	// Use this for initialization
	void Start () {
        targetVector = (target.transform.position - this.transform.position).normalized;
    }
	
	// Update is called once per frame
	void Update () {
        //this.transform.position = Vector3.Lerp(this.transform.position, Vector3.zero, Time.deltaTime * speed);
        transform.Translate(targetVector * Time.deltaTime * speed);
    }
}
