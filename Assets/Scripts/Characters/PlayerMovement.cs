using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IAnimatable
{
    public Joystick joystick;
    public float speed;
    public float rotationSpeed;

    private Animator playerController;
    [SerializeField] private GameObject ax;

    public bool isCutting = false;

    

    

    private void Start()
    {
        playerController = GetComponent<Animator>();
    }

   

    void Update()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            transform.Translate(direction * speed * Time.deltaTime, Space.World);

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            if (!isCutting)
                Run();
        }
        else
        {
            if(!isCutting) 
              Idle();
        }
    }

    public void Cut()
    {
        isCutting = true;

        ax.gameObject.SetActive(true);
        playerController.SetBool("isCut", true);
        playerController.SetBool("isRun", false);
        playerController.SetBool("isIdle", false);
    }

    public void Idle()
    {
        isCutting = false;

        ax.gameObject.SetActive(false);
        playerController.SetBool("isCut", false);
        playerController.SetBool("isRun", false);
        playerController.SetBool("isIdle", true);
    }

    public void Run()
    {
        playerController.SetBool("isRun", true);
        playerController.SetBool("isIdle", false);
    }


}
