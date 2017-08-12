using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortItem : MonoBehaviour {

    public int size;
    public float scaleFactor = 0.05f;

	void Start () {
        size = Random.Range(4, 30);
        transform.Find("Model").localScale = Vector3.one * size * scaleFactor;
    }

    public void move(int newIndex, float time, int curveDirection)
    {
        
        LeanTween.cancel(gameObject);
        Vector3 newPos = new Vector3(newIndex, transform.position.y, transform.position.z);
        LeanTween.moveLocalX(gameObject, newIndex, time).setEaseInOutSine();
        LeanTween.moveLocalZ(gameObject, curveDirection, time / 2).setEaseInSine().setLoopPingPong(1);
    }
	
}
