using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UniRx;

public class BookPresenter : MonoBehaviour {

    public Button button_next;
    public Button button_prev;
    public Button button_menu;

    public GameObject sectionRoot;
    public GameObject sideMenuRoot;
    public Text title;

    List<Section> mainSections = new List<Section>();
    Section currentSection;

    List<Button> sideButtons;

    List<GameObject> currentPages;

    bool sideMenuOpened = true;
    float sideMenuX;


    void Awake()
    {
        sideMenuRoot.SetActive(true);
        sideMenuX = sideMenuRoot.transform.localPosition.x;
        sideMenuRoot.transform.localPosition = new Vector2(-600, sideMenuRoot.transform.localPosition.y);
        toggleSideMenu();

        foreach(Transform t in sectionRoot.transform)
            mainSections.Add( t.GetComponent<Section>() );

        sideButtons = sideMenuRoot.GetComponentsInChildren<Button>().ToList();
        sideButtons.ForEach(b => b.onClick.AsObservable().Subscribe(x => goToSection(b.name)));

        button_next.onClick.AsObservable().Subscribe(_ => movePage(1));
        button_prev.onClick.AsObservable().Subscribe(_ => movePage(-1));

        button_menu.onClick.AsObservable().Subscribe(_ => toggleSideMenu());
    }

    void toggleSideMenu()
    {
        sideMenuOpened = !sideMenuOpened;

        LeanTween.moveLocalX(
            sideMenuRoot,
            sideMenuOpened ? sideMenuX : -600,
            0.6f
        ).setEase(LeanTweenType.easeOutSine);
    }

    void Start()
    {
        //On start, open the title Screen
        mainSections.ForEach(x => x.gameObject.SetActive(false));
        mainSections[0].gameObject.SetActive(true);
        currentSection = mainSections[0];

    }

    void movePage(int amount)
    {
        if (!currentSection.movePage(amount))
            goToSection(  (int) (mainSections.FindIndex( x => x == currentSection) + Mathf.Sign(amount)) );

    }


    void goToSection(string sectionName)
    {

        Debug.Log("Going to section: " + sectionName);
        mainSections.ForEach(s => {
            s.gameObject.SetActive(false);

            if (s.name == sectionName)
            {
                s.gameObject.SetActive(true);
                currentSection = s;
            }
        }
        );
    }

    void goToSection(int sectionNumber)
    {
        if ( (sectionNumber < 0 ) || (sectionNumber >= mainSections.Count) )
            return;

        mainSections.ForEach(s => s.gameObject.SetActive(false));
        mainSections[sectionNumber].gameObject.SetActive(true);
        currentSection = mainSections[sectionNumber];
    }
	
}
