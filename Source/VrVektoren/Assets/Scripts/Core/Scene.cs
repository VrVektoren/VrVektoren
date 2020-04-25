using System;
using VrVektoren.Utilities;

namespace VrVektoren.Core
{
    public abstract class Scene
    {
        public abstract bool Closed { get; protected set; }

        public abstract void Load();
        public abstract void Close();
    }
}
