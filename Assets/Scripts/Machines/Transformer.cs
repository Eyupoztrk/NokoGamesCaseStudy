using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformer : Machine
{
    void Start()
    {
        StartCoroutine(AutoProcess());

    }

    protected override IEnumerator ProcessItem()
    {
        print("Transformer �al���yor");
        return base.ProcessItem();
    }


}
