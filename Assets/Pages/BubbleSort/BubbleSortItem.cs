using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(SortItem))]
public class BubbleSortItem : MonoBehaviour
{
    public float scaleFactor = 0.05f;
    SortItem sortItem;

    public int size
    {
        get
        {
            return sortItem.size;
        }
    }

    private void Awake()
    {
        sortItem = GetComponent<SortItem>();
    }

    private void Start()
    {
        sortItem.size = Random.Range(4, 30);
        transform.Find("Model").localScale = Vector3.one * sortItem.size * scaleFactor;
    }

    public void move(int newIndex, float time, int curveZ = 0, int curveY = 0)
    {
        sortItem.move(newIndex, time, curveZ, curveY);
    }

}
