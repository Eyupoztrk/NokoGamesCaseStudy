using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Machine
{
   
    

    public GameObject armature;
    public float armatureTurnSpeed = 100f; // Armature dönüþ hýzý

    private void Start()
    {
        StartCoroutine(AutoProcess());
    }


    protected override IEnumerator ProcessItem()
    {
        isProcessing = true;

        StartCoroutine(RotateArmature()); // Armature dönüþünü baþlat
        print("Spawner çalýþýyor");


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
