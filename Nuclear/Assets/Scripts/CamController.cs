//
// Copyright 2019 JotaDev
// Author: Juan Camilo Mayor Taborda
// Created: 18/09/2019
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CamController : MonoBehaviour
{

    #region Parameters

    // -------------PRIVATE----------------


    // -------------PUBLIC----------------
    #endregion

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TpPlayer()
    {
        GameManager.Instance.TpPlayer();
    }
}
