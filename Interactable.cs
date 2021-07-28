using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Interactable : MonoBehaviour{

   
	public float radius = 100f;
    SpaceMovement control;
    public bool isFocus = false;
    Transform user;

    
    public Renderer main;

    //ChangeText changeText;
    public string Nazwa;
    //protected string Isin;
    //protected string Sektor;
    public string StopaZwrotu;
    public string Wolumen;



    void Start()
    {
        Nazwa = main.name;
        StopaZwrotu = (main.material.color.a / 0.4f).ToString();
        Wolumen = (main.transform.localScale.y * 2).ToString();
        
    }

    protected void Update()
    {
        if (isFocus)
        {
         
        }
    }
    public void OnFocused(Transform userTransform)
    {
        isFocus = true;
        user = userTransform;
    }
    public void OnDefocused()
    {
        isFocus = false;
        user = null;
    }
	void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);

    }
}
