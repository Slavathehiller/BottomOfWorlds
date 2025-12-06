using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterAvatar : BaseAvatar
{
    public Character Character { get => _entity as Character; set => _entity = value; }

}
