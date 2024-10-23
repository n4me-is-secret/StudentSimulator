using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogSystem : MonoBehaviour
{

    public GameObject DialogWindow;
    public GameObject DialogText;
    private int phraseNumber;

    void ShowDialog(string phrase)
    {
        DialogText.GetComponent<TMP_Text>().text = phrase;
        DialogWindow.SetActive(true);
    }

    void ContinueDialog(string phrase)
    {
        DialogText.GetComponent<TMP_Text>().text = phrase;
    }

    void HideDialog()
    {
        DialogWindow.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {   
        phraseNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {

            phraseNumber += 1;

            switch (phraseNumber)
            {
                case 1: ShowDialog("Привет, это первая фраза!"); break;
                case 2: ContinueDialog("Это вторая фраза!"); break;
                case 3: ContinueDialog("Это третья фраза!"); break;
                case 4: HideDialog(); break;
                case 5: phraseNumber = 0; break;
            }

        }
    } 

}
