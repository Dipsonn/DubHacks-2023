using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Helper component to delay colliders on grabbed objects when thrown to prevent bad collisions
public class ColliderDelay : MonoBehaviour
{
    public float delayTime;
    public GameObject rootObj;

    public void delayEnableCollider()
    {
        StartCoroutine(delayedEnable());
    }

    private IEnumerator delayedEnable()
    {
        foreach(Collider c in rootObj.GetComponentsInChildren<Collider>())
        {
            c.enabled = false;
        }
        yield return new WaitForSeconds(delayTime);
        foreach (Collider c in rootObj.GetComponentsInChildren<Collider>())
        {
            c.enabled = true;
        }
    }
}

