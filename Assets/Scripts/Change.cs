using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change : MonoBehaviour
{
    public void arm()
    {
        FindAnyObjectByType<TapToPlace>().New(1);
    }

    public void jtb()
    {
        FindAnyObjectByType<TapToPlace>().New(2);
    }

    public void cuub()
    {
        FindAnyObjectByType<TapToPlace>().New(0);
    }
}
