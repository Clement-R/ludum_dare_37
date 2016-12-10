using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectTriggerBehavior : MonoBehaviour {

    private DoorBehavior parent;

    void Start()
    {
        parent = transform.parent.GetComponent<DoorBehavior>();
    }

    void OnTriggerEnter(Collider aCol)
    {
        parent.PerfectTriggerEnter(aCol);
    }

    void OnTriggerExit(Collider aCol)
    {
        parent.PerfectTriggerExit(aCol);
    }
}
