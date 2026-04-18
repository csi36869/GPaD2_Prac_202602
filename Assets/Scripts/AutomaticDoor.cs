using System.Collections;
using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{
    public float rotateAngle = 90f;
    public float interval = 1f;
    public float rotateTime = 1.0f;

    private void Start()
    {
        StartCoroutine(AutoRotate());
    }

    IEnumerator AutoRotate()
    {
        while (true)
        {
            yield return StartCoroutine(RotateStep());
            yield return new WaitForSeconds(interval);
        }
    }

    IEnumerator RotateStep()
    {
        Quaternion startRot = transform.rotation;
        Quaternion endRot = startRot * Quaternion.Euler(0, rotateAngle, 0);

        float time = 0f;

        while (time < rotateTime)
        {
            time += Time.deltaTime;
            float t = time / rotateTime;

            transform.rotation = Quaternion.Lerp(startRot, endRot, t);
            yield return null;
        }

        transform.rotation = endRot;
    }
}