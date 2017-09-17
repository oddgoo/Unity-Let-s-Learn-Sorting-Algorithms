using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenericSorter : MonoBehaviour
{

    public List<SortItem> sortItems;
    public float time = 0.4f;

    private void Awake()
    {
        sortItems.Select((x, index) => x.size);
    }

    void OnEnable()
    {
        shuffle();
        StartCoroutine(fullSort());
    }

    void shuffle()
    {
        sortItems.Select(
           x => swapItems(x, sortItems[ Random.Range(0, sortItems.Count) ]) 
        );
    }

    void swapItems(SortItem a, SortItem b)
    {

    }

    void swapItems(float time)
    {

    }



    IEnumerator fullSort()
    {
        yield return new WaitForSeconds(time);
        for (int j = sortItems.Count - 1; j > 0; j--)
            for (int i = 0; i < j; i++)
            {
                if (sortItems[i].size > sortItems[i + 1].size)
                {
                    SortItem temp = sortItems[i];
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
