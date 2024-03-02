using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(requiredComponent: typeof(ARRaycastManager))]
public class TapToPlace : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;

    GameObject spawnedObj;
    ARRaycastManager _arRayCastManager;
    Vector2 touchPosition;
    List<GameObject> _objects;
    int i; int j;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public void New(int k)
    {
        i = k;
    }

    private void Awake()
    {
        _arRayCastManager = GetComponent<ARRaycastManager>();
        _objects = new List<GameObject>();
        _objects.Add(obj1);
        _objects.Add(obj2);
        _objects.Add(obj3);
        i = 0; j = 0;
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    private void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;

        if (_arRayCastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            if (spawnedObj == null || i != j)
            {
                spawnedObj = Instantiate(_objects[i], hitPose.position, hitPose.rotation);
                j=i;
            }
            else
            {
                spawnedObj.transform.position = hitPose.position;
            }
        }
    }
}
