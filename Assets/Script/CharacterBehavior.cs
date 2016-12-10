using UnityEngine;
using System.Collections;

namespace proto_clement {
    public class CharacterBehavior : MonoBehaviour {
        public GameObject door;

        private Vector3 doorPosition;
        private float timeToDoor = 1.0f;
        private GameRules god;

        void Start() {
            GameObject gameManager = GameObject.Find("GameManager");
            god = gameManager.GetComponent<GameRules>();

            // Get destination and duration of the travel
            doorPosition = door.GetComponent<Transform>().position;
            timeToDoor = god.TimeWalk;
            StartCoroutine(MoveOverSeconds(gameObject, doorPosition, timeToDoor));
        }

        public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds) {
            float elapsedTime = 0;
            Vector3 startingPos = objectToMove.transform.position;
            while (elapsedTime < seconds) {
                transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            transform.position = end;
        }
    }
}