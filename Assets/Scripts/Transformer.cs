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
        return base.ProcessItem();
    }


}
