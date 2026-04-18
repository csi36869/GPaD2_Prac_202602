using System.Collections;
using UnityEngine;

public class DoorAutoOpenDevice : MonoBehaviour
{
    [SerializeField] Vector3 dPos;
    [SerializeField] float moveTime = 1f;

    private bool open;
    private bool isMoving;

    private Vector3 closedPos;
    private Vector3 openPos;

    private void Start()
    {
        closedPos = transform.position;
        openPos = closedPos + dPos;
    }

    public void OpenDoor()
    {
        if (isMoving || open) return;

        StartCoroutine(MoveDoor(closedPos, openPos));
        open = true;
    }

    public void CloseDoor()
    {
        if (isMoving || !open) return;

        StartCoroutine(MoveDoor(openPos, closedPos));
        open = false;
    }

    IEnumerator MoveDoor(Vector3 start, Vector3 end)
    {
        isMoving = true;

        float time = 0f;

        while (time < moveTime)
        {
            time += Time.deltaTime;
            float t = time / moveTime;

            transform.position = Vector3.Lerp(start, end, t);

            yield return null;
        }

        transform.position = end;
        isMoving = false;
    }
}