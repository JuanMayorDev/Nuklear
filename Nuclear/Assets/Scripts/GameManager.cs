//
// Copyright 2019 JotaDev
// Author: Juan Camilo Mayor Taborda
// Created: 18/09/2019
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Parameters

    // -------------PRIVATE----------------


    // -------------PUBLIC----------------

    public Transform player_tr;

    public Animator camera_anim;

    public float elapsed_time;

    public Transform door_to_tp;

    #endregion



    #region Singleton

    /// <summary>
    /// Campo privado que referencia a esta instancia
    /// </summary>
    static GameManager instance;

    /// <summary>
    /// Propiedad pública que devuelve una referencia a esta instancia
    /// Pertenece a la clase, no a esta instancia
    /// Proporciona un punto de acceso global a esta instancia
    /// </summary>
    public static GameManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        ///Asigna esta instancia al campo instance
        if (instance == null)
            instance = this;
        else
            Destroy(this);  ///Garantiza que sólo haya una instancia de esta clase   
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CameraTransition()
    {
        camera_anim.SetTrigger("Transition");
    }

    public void TpPlayer()
    {
        player_tr.position = door_to_tp.position;
        
        player_tr.GetComponent<PlayerController>().can_move = true;
    }
}
