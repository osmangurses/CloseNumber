using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public GameObject gmm;
    public int butonsayisi;
    public string renk;
    public GameManager gm;
    public Button[] sarilar, yesiller;
    void Start()
    {
        gm = gmm.GetComponent<GameManager>();
        gameObject.GetComponent<Button>().onClick.AddListener(Clicked); 
    }
    public void Clicked()
    {
        Debug.Log("sira: " + gm.sira);
        Debug.Log("butonrengi: " + renk);
        Debug.Log("toplamzar: " + gm.toplamzar);
        Debug.Log("butonsayisi: " + butonsayisi);
        Debug.Log("Fonksiyona Girdi");
        if (gm.toplamzar>=butonsayisi && renk==gm.sira)
        {
            Debug.Log("Ýfe Girdi");
            gm.toplamzar -= butonsayisi;
            if (renk=="yesil")
            {
                gameObject.GetComponent<Image>().sprite = gm.yesil[0];
            }
            else
            {
                gameObject.GetComponent<Image>().sprite = gm.sari[0];
            }


            butonsayisi = 100;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (gm.ytime <= 0 || gm.stime <= 0)
        {
            Debug.Log("Buraya girdi");
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
}
