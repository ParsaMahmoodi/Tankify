using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bazaar.Data;
using Bazaar.Poolakey.Data;
using UnityEngine;

public abstract class Market
{
    public abstract Task Initialize();

    public abstract Task<Result<PurchaseInfo>> Purchase(String id);

    public abstract Task<bool> Consume(String id);

}
