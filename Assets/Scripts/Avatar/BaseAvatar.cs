using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public abstract class BaseAvatar : MonoBehaviour
{
    protected BaseEntity _entity;
    public BaseEntity Entity { get => _entity; protected set => _entity = value; }
    public void Bind(BaseEntity entity)
    {
        _entity = entity;
    }
}
