using VrVektoren.Services;
using UnityEngine;

namespace VrVektoren.Behaviours
{
    public class MainCameraBehaviour : MonoBehaviour
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        private readonly float turningSpeed = 0.5f;
#endif

        private float x;
        private float y;

        void Start()
        {
            ApplicationService.Startup();
        }

        void Update()
        {
#if UNITY_EDITOR || UNITY_STANDALONE
            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.y += turningSpeed;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.y -= turningSpeed;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                this.x += turningSpeed;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                this.x -= turningSpeed;
            }

            if (this.x > 90)
            {
                this.x = 90;
            }
            else if (this.x < -90)
            {
                this.x = -90;
            }

            if (this.y > 360)
            {
                this.y -= 360;
            }

            this.transform.localRotation = Quaternion.Euler(this.x, this.y, 0);
#endif
        }
    }
}
