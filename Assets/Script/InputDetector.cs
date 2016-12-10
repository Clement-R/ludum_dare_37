using UnityEngine;
using System.Collections;

namespace proto_clement {
    public class InputDetector : MonoBehaviour {
        public GameObject entryA;
        public GameObject entryX;
        public GameObject entryB;
        public GameObject entryY;

        private DetectTrigger triggerEntryA;
        private DetectTrigger triggerEntryX;
        private DetectTrigger triggerEntryB;
        private DetectTrigger triggerEntryY;

        void Start() {
            triggerEntryA = entryA.GetComponent<DetectTrigger>();
            triggerEntryX = entryX.GetComponent<DetectTrigger>();
            triggerEntryB = entryB.GetComponent<DetectTrigger>();
            triggerEntryY = entryY.GetComponent<DetectTrigger>();
        }

        void Update() {
            if(Input.GetButtonDown("ButtonA")) {
                if(triggerEntryA.isTriggered) {
                    Debug.Log("Trigger");
                    // TODO : Remove note from the trigger list
                } else if(triggerEntryA.isPerfectTriggered) {
                    Debug.Log("Perfect Trigger");
                    // TODO : Remove note from the trigger list
                }
            }

            if (Input.GetButtonDown("ButtonX")) {
                if (triggerEntryX.isTriggered) {
                    // TODO : Remove note from the trigger list
                }
                else if (triggerEntryX.isPerfectTriggered) {
                    // TODO : Remove note from the trigger list
                }
            }

            if (Input.GetButtonDown("ButtonB")) {
                if (triggerEntryB.isTriggered) {
                    // TODO : Remove note from the trigger list
                }
                else if (triggerEntryB.isPerfectTriggered) {
                    // TODO : Remove note from the trigger list
                }
            }

            if (Input.GetButtonDown("ButtonY")) {
                if (triggerEntryY.isTriggered) {
                    // TODO : Remove note from the trigger list
                }
                else if (triggerEntryY.isPerfectTriggered) {
                    // TODO : Remove note from the trigger list
                }
            }
        }
    }
}
