﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    

    private GameObject currentArrow;

    public GameObject scifiBowArrowPrefab;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttachArrow()
    {
        if(currentArrow == null)
        {
            currentArrow = Instantiate(scifiBowArrowPrefab);
        }
    }
}
