using UnityEngine;

namespace VrVektoren.Behaviours
{
    public class TestCubeBehaviour : BaseButtonBehaviour
    {
        protected override void Start()
        {
            base.Start();
            
            // TODO Remove just for testing
            //https://vr-vektoren.ch/app/VrVektoren/tutorial/1
            //vrvektoren://tutorial/1
            //var url = "https://vr-vektoren.ch/app/VrVektoren/tutorial/2";
            //SceneService.TryOpenVectorVisualizer(url);
        }

        protected override void Update()
        {
            base.Update();
        }

        protected override void Trigger()
        {
            this.transform.Translate(0, 1, 0, Space.World);
        }
    }
}