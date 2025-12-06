using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface ICharacterBattle
{
    public string Name { get; set; }
    public int MaxHitPoints { get ; set; }
    public int CurrentHitPoints { get ; set ; }
}

