using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Factories.Interfaces
{
    public interface IUIAssetFactory
    {
        public T CreateAsset<T>(GameObject parent) where T : MonoBehaviour;
    }
}
