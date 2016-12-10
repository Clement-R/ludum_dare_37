using UnityEngine;
using System.Collections;

public class DetectTrigger : MonoBehaviour {
    public bool isPerfectTriggered = false;

    private bool isTriggered = false;

    void OnTriggerStay(Collider other) {
        if (other.tag == "Note") {
            // Debug.Log("Collision");
            isTriggered = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Note") {
            // Debug.Log("Collision leaving");
            isTriggered = false;
        }
    }
}
