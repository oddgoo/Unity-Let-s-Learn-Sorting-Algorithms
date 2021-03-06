﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BubbleSort : MonoBehaviour
{

    public int objectCount = 10;
    public float time = 0.5f;
    public GameObject objectToSort;

    List<BubbleSortItem> sortItems;
    Color objectColor;

    void Awake()
    {

        sortItems = Enumerable.Range(0, objectCount).Select((x, index) =>
           {
               BubbleSortItem s = GameObject.Instantiate(objectToSort, transform).GetComponent<BubbleSortItem>();
               //s.transform.Translate(0, 0, -20);
               s.move(index, 0, Random.Range(-2, 2));
               objectColor = s.getColor();
               return s;
           }
        ).ToList();

        StartCoroutine(fullSort());
    }

    private void OnEnable()
    {
        StartCoroutine(fullSort());
    }

    IEnumerator fullSort()
    {
        yield return new WaitForSeconds(time);
        for (int j = sortItems.Count - 1; j > 0; j--)
            for (int i = 0; i < j; i++)
            {
                sortItems[i].setColor(Color.green);
                sortItems[i + 1].setColor(Color.green);

                if (sortItems[i].size > sortItems[i + 1].size)
                {
                    BubbleSortItem temp = sortItems[i];
                    sortItems[i] = sortItems[i + 1];
                    sortItems[i + 1] = temp;
                    //Animation Stuff
                    sortItems[i].move(i, time, 1);
                    sortItems[i + 1].move(i + 1, time, -1);
                }
                yield return new WaitForSeconds(time);

                sortItems[i].setColor(objectColor);
                sortItems[i + 1].setColor(objectColor);
            }

    }
}
