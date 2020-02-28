using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{   private Image content;

    private float CurrentFill;
    public float MaxValue { get; set; }
    private float CurrentValue;
    //because of this prop we can make sure our health doesnt go above health;
    public float MyCurrentValue 
    {   get => CurrentValue;
        set => CurrentValue = value; 
    }

  
    // Start is called before the first frame update
    void Start()
    {//content to acces the fill amount 
        content = GetComponent<Image>();
        //content.fillAmount = 0.5f;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
