using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortItem : MonoBehaviour {

    [HideInInspector]
    public int size;

    float origY, origZ;

    private void Awake()
    {
        origY = transform.position.y;
        origZ = transform.position.z;
    }

    public void move(float newXPos, float time, int curveZ = 0, int curveY = 0)
    {
        LeanTween.cancel(gameObject);
        Vector3 startingPos = new Vector3(transform.position.x, origY, origZ);
        transform.position = startingPos;

        Vector3 newPos = new Vector3(newXPos, transform.position.y, transform.position.z);
        LeanTween.moveLocalX(gameObject, newXPos, time).setEaseInOutSine();

        LeanTween.moveLocalZ(gameObject, curveZ, time / 2).setEaseInSine().setLoopPingPong(1);
        LeanTween.moveLocalY(gameObject, curveY, time / 2).setEaseInSine().setLoopPingPong(1);
    }

}
