using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public abstract class Market
{
    public abstract void Initialize();

    public abstract Task<bool> Purchase(String id);

    public abstract Task<bool> Consume(String id);

}
