using UnityEngine;

namespace VrVektoren.Utilities
{
    public static class GameObjectColorHelper
    {
        public static Color GetGameObjectColor(GameObject gameObject)
        {
            return gameObject.GetComponent<Renderer>().material.GetColor("_Color");
        }

        public static void SetGameObjectColor(GameObject gameObject, Color color)
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", color);
        }
    }
}
