using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interfaces
{
    public interface IBaseFactory
    {
        public T CreateAsset<T>(bool cached = true);
        public T CreateAssetNotCached<T>();
    }
}
