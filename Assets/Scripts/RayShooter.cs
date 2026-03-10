using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RayShooter : MonoBehaviour
{
    private Camera cam;
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void OnGUI()
    {
        int size = 12;
        float posX = cam.pixelWidth / 2 - size / 4;
        float posY = cam.pixelHeight / 2 - size / 2;

        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.red;
        style.fontSize = 40;

        GUI.Label(new Rect(posX, posY, size, size), "*", style);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, 0);
            Ray ray = cam.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null)
                {
                    //Debug.Log("Target hit");
                    target.ReactToHit();
                }
                else
                {
                    StartCoroutine(SphereIndicator(hit.point));
                }

            }
        }
    }

    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        sphere.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }
}