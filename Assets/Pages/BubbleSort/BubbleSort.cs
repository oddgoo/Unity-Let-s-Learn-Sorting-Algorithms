using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BubbleSort : MonoBehaviour
{

    public int objectCount = 10;
    public float time = 0.5f;
    public GameObject objectToSort;

    List<BubbleSortItem> sortItems;

    void Start()
    {

        sortItems = Enumerable.Range(0, objectCount).Select((x, index) =>
           {
               BubbleSortItem s = GameObject.Instantiate(objectToSort).GetComponent<BubbleSortItem>();
               s.move(index, 0, Random.Range(-2, 2));
               return s;
           }
        ).ToList();

        StartCoroutine(fullSort());
    }

    IEnumerator fullSort()
    {
        yield return new WaitForSeconds(time);
        for (int j = sortItems.Count - 1; j > 0; j--)
            for (int i = 0; i < j; i++)
            {
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
            }

    }
}
