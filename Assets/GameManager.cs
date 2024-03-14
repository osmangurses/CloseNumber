using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button[] sarilar,yesiller;
    public Sprite[] sari,yesil,zarlar;
    public Button zarci,zar1,zar2;
    public string sira;
    public Text yTimer, sTimer;
    public int toplamzar;
    public float timer,ytime,stime;
    bool firstclick, stopupdate;
    public int saripuan, yesilpuan;
    
    void Start()
    {
        stopupdate= false;
        stime = ytime = 15;
        timer = 10;
        sira="sari";
        zarci.onClick.AddListener(zarat);
        firstclick= true;
    }

    public void zarat()
    {
        if (firstclick)
        {
            timer = 0;
            firstclick = false;
        }
        else
        {
            timer = 10;
            int rand1 = Random.Range(0, 6);
            int rand2 = Random.Range(0, 6);
            zar1.GetComponent<Image>().sprite = zarlar[rand1];
            zar2.GetComponent<Image>().sprite = zarlar[rand2];
            toplamzar = rand1 + rand2 + 2;
            firstclick = true;
            if (sira == "yesil")
            {
                sira = "sari";
            }
            else
            {
                sira = "yesil";
            }
            zarci.gameObject.SetActive(false);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (!stopupdate)
        {
            for (int i = 0; i < sarilar.Length; i++)
            {
                saripuan += sarilar[i].GetComponent<ButtonScript>().butonsayisi;
            }
            for (int i = 0; i < yesiller.Length; i++)
            {
                yesilpuan += yesiller[i].GetComponent<ButtonScript>().butonsayisi;
            }
            if (timer < 2)
            {
                zar1.GetComponent<Image>().sprite = zarlar[Random.Range(0, 6)];
                zar2.GetComponent<Image>().sprite = zarlar[Random.Range(0, 6)];
            }
            if (toplamzar != 0)
            {
                if (sira == "yesil")
                {
                    ytime -= Time.deltaTime;

                    sTimer.text = ((int)stime).ToString();
                    yTimer.text = ((int)ytime).ToString();
                }
                else
                {
                    stime -= Time.deltaTime;

                    sTimer.text = ((int)stime).ToString();
                    yTimer.text = ((int)ytime).ToString();
                }
            }
            else
            {
                ytime = 15;
                stime = 15;
                if (!(ytime <= 0 || stime <= 0))
                {
                    zarci.gameObject.SetActive(true);
                }
                sTimer.text = ((int)stime).ToString();
                yTimer.text = ((int)ytime).ToString();
            }
            if (ytime <= 0 || stime <= 0 || (yesilpuan == 800 && toplamzar == 0) || (saripuan == 800 && toplamzar == 0))
            {
                Time.timeScale = 0;
                if (yesilpuan == 800 && toplamzar==0)
                {
                    sTimer.text = "LOSE";
                    yTimer.text = "WIN";
                }
                else if (saripuan ==800&&toplamzar==0)
                {
                    yTimer.text = "LOSE";
                    sTimer.text = "WIN";
                }
                else if (ytime <= 0)
                {
                    yTimer.text = "LOSE";
                    sTimer.text = "WIN";
                }
                else
                {
                    sTimer.text = "LOSE";
                    yTimer.text = "WIN";
                }
                zarci.gameObject.SetActive(false);
                stopupdate= true;
            }
            else
            {
                saripuan = 0;
                yesilpuan = 0;
            }
        }
        
        
    }
}
