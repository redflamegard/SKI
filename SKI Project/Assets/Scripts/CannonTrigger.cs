using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTrigger : MonoBehaviour {
    [SerializeField]
    Transform holdLocation;

    private void OnTriggerEnter(Collider other)
    {
        CannonController controller = GetComponent<CannonController>();
        if (other.GetComponent<Player>().GetType() == typeof(Player))
        {
            other.GetComponent<Player>().enabled = false;
            other.transform.position = holdLocation.position;

            //controller.currentPlayerID = other.GetComponent<Player>().ID;
            controller.enabled = true;
        }
    }
}
