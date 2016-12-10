using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour {

    List<Collider> pnjsNormal;
    List<Collider> pnjsPerfect;

    private void Awake()
    {
        pnjsNormal = new List<Collider>();
        pnjsPerfect = new List<Collider>();
    }
    
    void Start () {
		
	}
	
	void Update () {
        //Debug.Log(this.name + " " + pnjsNormal.Count + " " +pnjsPerfect.Count);
        //INPUT


	}

    public void NormalTriggerEnter(Collider other)
    {
        pnjsNormal.Add(other);
        Debug.Log("normal enter " + other.name);
    }

    public void PerfectTriggerEnter(Collider other)
    {
        pnjsPerfect.Add(other);
        Debug.Log("perfect enter " + other.name);
    }

    public void NormalTriggerExit(Collider other)
    {
        pnjsNormal.Remove(other);
        Destroy(other.gameObject);
    }

    public void PerfectTriggerExit(Collider other)
    {
        pnjsPerfect.Remove(other);
    }
}
