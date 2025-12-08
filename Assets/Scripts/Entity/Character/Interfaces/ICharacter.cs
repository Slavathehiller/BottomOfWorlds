using Assets.Scripts.Entity.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ICharacter
{
    public string Name { get; set; }
    public PlayerCart Cart { get; set; }
    public PlayerState State { get; set; }
}

