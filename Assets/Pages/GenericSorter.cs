using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenericSorter : MonoBehaviour
{
    //TODO: Will DRY Funcitonality with TitleSorter

    public List<SortItem> sortItems;
    public float spacing;
    public float offset;
    public float time = 0.3f;

    private void Start()
    {
        Debug.Log("Generic Sort Start");
        for (int j = sortItems.Count - 1; j > 0; j--)
            sortItems[j].size = j;

        System.Random rnd = new System.Random();
        sortItems = sortItems.OrderBy(x => rnd.Next()).ToList();

        for (int i = 0; i < sortItems.Count; i++)
            sortItems[i].move(indexToLetterPos(i), 0);

        StartCoroutine(fullSort());
    }

    float indexToLetterPos(float i)
    {
        return offset + (i * spacing) - sortItems.Count / 2 * spacing + spacing / 2;
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
                    sortItems[i].move(indexToLetterPos(i), time, 0, 40);
                    sortItems[i + 1].move(indexToLetterPos(i + 1), time, 0, -40);
                    yield return new WaitForSeconds(time);
                }
            }
    }
}
