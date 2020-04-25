using UnityEngine;
using VrVektoren.Core;
using VrVektoren.Services;
using VrVektoren.Utilities;

namespace VrVektoren.Behaviours
{
    public class TurnTableBehaviour : MonoBehaviour
    {
        public GameObject VectorPrefab;

        private Vizualization visualization;
    
        void Start()
        {
            Guard.IsNotNull(VectorPrefab);
            Guard.HasComponent<VectorBehaviour>(VectorPrefab);

            this.visualization = SceneService.VectorVisualizer.Vizualization;

            foreach (var vector in visualization.Vectors)
            {
                var container = this.transform.Find("TurnTable").Find("VectorContainer");
                var vectorGameObject = Instantiate(this.VectorPrefab);
                vectorGameObject.transform.SetParent(container);
                vectorGameObject.GetComponent<VectorBehaviour>().Initialize(vector);
            }
        }
        
        void Update()
        {

        }

        public void Rotate(float angle)
        {
            transform.Find("TurnTable").transform.Rotate(Vector3.up, angle);
        }
    }
}
