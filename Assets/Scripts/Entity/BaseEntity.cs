using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BaseEntity
{
    public string Name  {get; set; }
    public virtual int MaxHitPoints { get ; set; }
    public int CurrentHitPoints { get; set; }
}
