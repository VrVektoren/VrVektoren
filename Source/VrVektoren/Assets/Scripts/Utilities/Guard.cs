using System;
using UnityEngine;

namespace VrVektoren.Utilities
{
    public static class Guard
    {
        public static void IsNotNull<T>(T value)
        {
            if (value == null)
            {
                throw new NullReferenceException();
            }
        }

        public static void IsTrue(Boolean value)
        {
            if (value != true)
            {
                throw new InvalidOperationException();
            }
        }

        internal static void HasComponent<T>(GameObject gameObject)
        {
            if (gameObject.GetComponent<T>() == null)
            {
                throw new ArgumentException($"GameObject has missing component \"{typeof(T).FullName}\".");
            }
        }

        public static void IsFalse(Boolean value)
        {
            if (value != false)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
