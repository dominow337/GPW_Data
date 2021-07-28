using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Text;
using System.Runtime;

public class Circle : MonoBehaviour {

    public GameObject planet1;
    public GameObject master;
    public Renderer PlanetGrey;
     public int numberOfObjects = 20;
    public int minObjects = 1;
    Vector3 xj;
    Vector3 yj;
    Vector3 zj;
     public float radius = 20f;
     public float xi = 2f;
     public float yi = 2f;
     public float zi = 2f;
    public Text licznik;
    float PC1;
    float PC2;
    float PC3;
    float size;
    float grey;

    public TextAsset jsonFile;
    public TextAsset jsonRGB;



    float x = -4f;
    float y = -8f;
    float z = -1f;
    int l = 0;

    Encoding ascii = Encoding.ASCII;
    float kanalA;

    public Renderer poswiata;
    void Start()
    {
       
            Datas datasInJson = JsonUtility.FromJson<Datas>(jsonFile.text);
            foreach (Data data in datasInJson.PCA)
            {

                
                Vector3 pos;
                float angle = Mathf.PI * 2 / numberOfObjects;
                float angleDegrees = -angle * Mathf.Rad2Deg;
                PC1 = data.PC1;
                PC2 = data.PC2;
                PC3 = data.PC3;
                grey = data.Obrot;
            if (l == 0)
                {
                    pos = transform.position + new Vector3((PC1*10000f), (PC2*100f), (PC3*10000f));
                }
                else if (l % 2 == 0 && l % 3 != 0)
                {
                    pos = transform.position + new Vector3((PC1 * 10000f * x), (PC2*100f), (PC3*10000f));
                }
                else if (l % 3 == 0)
                {
                    pos = transform.position + new Vector3((PC1*10000f), (PC2*100f * y), (PC3*10000f));
                }
                else
                {
                    pos = transform.position + new Vector3((PC1*10000f), (PC2*100f), (PC3*10000f * z));
                }






                kanalA = data.StopaZwrotu;

                Quaternion rot = Quaternion.Euler(0, angleDegrees, 0);
                GameObject planet = Instantiate(planet1, pos, rot);
                Renderer MyPoswiata = Instantiate(poswiata, pos, rot);
                Renderer MyGrey = Instantiate(PlanetGrey, pos, rot);
                planet.transform.SetParent(master.transform);
                MyPoswiata.transform.SetParent(master.transform);
                MyGrey.transform.SetParent(master.transform);


                size = data.WOLUMEN;
                
                
                
                planet.transform.localScale = new Vector3((size/1000f), (size/1000f), (size/1000f));
                MyPoswiata.transform.localScale = new Vector3((size*0.05f), (size*0.05f), (size*0.05f));
                MyGrey.transform.localScale = new Vector3((size*0.045f), (size*0.045f), (size*0.045f));
                MyPoswiata.name = data.NAZWA;
                planet.name = data.NAZWA;
                RGBDatas rgbinjson = JsonUtility.FromJson<RGBDatas>(jsonRGB.text);
                MyGrey.material.color = new Color(grey, grey, grey, 0.4f);
                //planet.material.color = new Color(data.Obrot, data.Obrot, data.Obrot, 1);
                foreach (Data rgbdata in rgbinjson.Color)
                {
                    if (rgbdata.Sektor == data.Sektor)
                    {
                        MyPoswiata.material.color = new Color(rgbdata.R / 255f, rgbdata.G / 255f, rgbdata.B / 255f, kanalA * 0.4f);
                    }
                }

                l++;


            }

        licznik.text = "Liczba planet: " + l.ToString();
            
        
    }
}
