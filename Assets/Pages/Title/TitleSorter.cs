using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleSorter : MonoBehaviour {

    public GameObject singleLetter;
    public float spacing;
    public float offset;

    public float time = 0.2f;

    List<SortItem> sortItems = new List<SortItem>();

    public string title = "ORDENAMIENTO";

	void Start () {

        for(int i=0; i<title.Length; i++)
        {
            GameObject instance = GameObject.Instantiate(singleLetter, transform);
            instance.GetComponent<Text>().text = title[i].ToString();
            SortItem sortItem = instance.GetComponent<SortItem>();
            sortItem.size = i;
            sortItems.Add(sortItem); 
        }
		
        System.Random rnd = new System.Random();
        sortItems = sortItems.OrderBy(x => rnd.Next()).ToList();

        for(int i=0; i< sortItems.Count; i++)
        {
            sortItems[i].move( indexToLetterPos(i), 0);
        }

        StartCoroutine(fullSort());
    }

    float indexToLetterPos(float i)
    {
        return offset + (i * spacing) - title.Length / 2 * spacing + spacing / 2;
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
