using UnityEngine;

namespace VrVektoren.Services
{
    public class ApplicationService: ScriptableObject
    {
        private static ApplicationService applicationService;
        private bool hasStartedUp;

        private static ApplicationService Instance
        {
            get
            {
                if (applicationService == null)
                {
                    applicationService = FindObjectOfType<ApplicationService>();

                    if (applicationService == null)
                    {
                        applicationService = ScriptableObject.CreateInstance<ApplicationService>();
                    }
                }

                return applicationService;
            }
        }

        public static bool HasStartedUp
        {
            get
            {
                return Instance.hasStartedUp;
            }
        }

        public static void Startup()
        {
            if (HasStartedUp)
            {
                return;
            }

            Instance.hasStartedUp = true;

#if UNITY_EDITOR
#else
            Application.deepLinkActivated += Instance.OnDeepLinkActivated;

            if (!SceneService.TryOpenVectorVisualizer(Application.absoluteURL))
            {
                SceneService.OpenSceneSelection();
            }
#endif
        }

        public void OnDeepLinkActivated(string uri)
        {
            SceneService.TryOpenVectorVisualizer(Application.absoluteURL);
        }
    }
}
