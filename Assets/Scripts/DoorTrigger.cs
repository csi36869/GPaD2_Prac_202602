using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] DoorAutoOpenDevice door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door.OpenDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door.CloseDoor();
        }
    }
}