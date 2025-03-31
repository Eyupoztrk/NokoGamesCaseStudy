using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationSetter : MonoBehaviour
{

    private Animator playerController; 
    void Start()
    {
        playerController = GetComponent<Animator>();
    }

}
