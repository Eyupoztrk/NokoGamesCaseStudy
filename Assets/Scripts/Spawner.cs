using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Machine
{
   
    

    public GameObject armature;
    public float armatureTurnSpeed = 100f; 

    private void Start()
    {
        StartCoroutine(AutoProcess());
    }


    protected override IEnumerator ProcessItem()
    {
        isProcessing = true;

        StartCoroutine(RotateArmature());
        print("Spawner �al���yor");


        return base.ProcessItem();
    }




    protected virtual IEnumerator RotateArmature()
    {
        while (isProcessing)
        {
            armature.transform.Rotate(armatureTurnSpeed * Time.deltaTime, 0, 0);
            yield return null;
        }
    }
}
