using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section : MonoBehaviour {

    public List<GameObject> pages = new List<GameObject>();

    public int currentPage = 0;

    private void Awake()
    {
        foreach (Transform t in transform)
            pages.Add( t.gameObject );
    }

    public void OnEnable()
    {
        currentPage = 0;
        activateCurrentPage();
    }

    public bool movePage(int amount)
    {

        Debug.Log(name + " moving page by amount: " + amount + " and current page is: " + currentPage);
        currentPage += amount;

        if ( (currentPage < 0) || (currentPage >= pages.Count))
        {
            currentPage = Mathf.Clamp(currentPage, 0, pages.Count - 1);
            return false;
        }
        else
        {
            activateCurrentPage();
            return true;
        }
    }

    void activateCurrentPage()
    {
        pages.ForEach(p => p.SetActive(false));
        pages[currentPage].SetActive(true);
    }
	
}
