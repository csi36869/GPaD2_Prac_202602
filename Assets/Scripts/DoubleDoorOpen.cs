using UnityEngine;

public class DoubleDoorOpen : MonoBehaviour
{
    [SerializeField] Animator leftDoor;
    [SerializeField] Animator rightDoor;

    private bool open;
    private bool isMoving;

    void Start()
    {
        leftDoor.SetBool("Open", false);
        rightDoor.SetBool("Open", false);
    }

    public void Operate()
    {
        if (isMoving) return;

        open = !open;

        leftDoor.SetBool("Open", open);
        rightDoor.SetBool("Open", open);

        StartCoroutine(Lock());
    }

    System.Collections.IEnumerator Lock()
    {
        isMoving = true;
        yield return new WaitForSeconds(1f);
        isMoving = false;
    }
}