using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortItem : MonoBehaviour {

    public int size;

    float origY, origZ;

    private void Awake()
    {
        origY = transform.localPosition.y;
        origZ = transform.localPosition.z;
    }

    public void move(float newXPos, float time, int curveZ = 0, float curveY = 0)
    {
        LeanTween.cancel(gameObject);
        Vector3 startingPos = new Vector3(transform.localPosition.x, origY, origZ);
        transform.localPosition = startingPos;

        LeanTween.moveLocalX(gameObject, newXPos, time).setEaseInOutSine();

        if(curveZ != 0)
            LeanTween.moveLocalZ(gameObject, curveZ, time / 2).setEaseInSine().setLoopPingPong(1);

        if (curveY != 0)
            LeanTween.moveLocalY(gameObject, curveY, time / 2).setEaseInSine().setLoopPingPong(1);
    }

}
