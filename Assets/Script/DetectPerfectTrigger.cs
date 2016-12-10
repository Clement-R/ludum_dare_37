using UnityEngine;
using System.Collections;

public class DetectPerfectTrigger : MonoBehaviour {
    private DetectTrigger parent;

    void Start() {
        parent = transform.parent.GetComponent<DetectTrigger>();
    }

    void OnTriggerStay(Collider other) {
        if (other.tag == "PerfectTrigger") {
            // Debug.Log("PerfectCollision");
            parent.isPerfectTriggered = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "PerfectTrigger") {
            // Debug.Log("PerfectCollision leaving");
            parent.isPerfectTriggered = false;
        }
    }
}
