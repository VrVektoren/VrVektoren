using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VrVektoren.Core;
using VrVektoren.Utilities;
using Scene = VrVektoren.Core.Scene;

namespace VrVektoren.Services
{
    public class SceneService: ScriptableObject
    {
        private static SceneService sceneService;
        private Scene currentScene;
        private SceneSelection sceneSelection;
        private Visualizer vectorVisualizer;
        private QRCodeScanner qRCodeScanner;
        
        private static SceneService Instance
        {
            get
            {
                if (sceneService == null)
                {
                    sceneService = FindObjectOfType<SceneService>();

                    if (sceneService == null)
                    {
                        sceneService = ScriptableObject.CreateInstance<SceneService>();
                    }
                }

                return sceneService;
            }
        }

        private static void CloseScene(Scene scene)
        {
            if(scene != null)
            {
                scene.Close();
            }
        }
    
        // Todo: Remove
        public static void LogDebug(String logMessage)
        {
            Debug.Log(logMessage);
            var texts = GameObject.FindGameObjectsWithTag("debugText");

            foreach (var text in texts)
            {
                text.GetComponent<Text>().text = logMessage;
            }
        }

        public static Scene CurrentScene 
        {
            get
            {
                return Instance.currentScene;
            }
        }

        public static SceneSelection SceneSelection
        {
            get
            {
                return Instance.sceneSelection;
            }
        }

        public static Visualizer VectorVisualizer
        {
            get
            {
                return Instance.vectorVisualizer;
            }
        }

        public static QRCodeScanner QRCodeScanner
        {
            get
            {
                return Instance.qRCodeScanner;
            }
        }
        
        public static bool TryOpenVectorVisualizer(String uri)
        {
            // Parse URI
            // Definition
            // Case 1: "https://vr-vektoren.ch/app/VrVektoren/[section]/[id]"
            //      2: "vrvektoren://[section]/[id]"
            //
            // Example "https://vr-vektoren.ch/app/VrVektoren/tutorial/1"
            // Config:
            string[] avaliableSections = {"tutorial"};

            if (string.IsNullOrWhiteSpace(uri))
            {
                LogDebug("uri is null or size = 0");
                return false;
            }

            Uri unparsedUrl;
            if (!Uri.TryCreate(uri, UriKind.Absolute, out unparsedUrl))
            {
                LogDebug("Not a valid uri. URI:" + uri);
                return false;
            }

            if (unparsedUrl.Scheme != "vrvektoren" 
                && !(unparsedUrl.Scheme == "https" && unparsedUrl.Authority == "vr-vektoren.ch"))
            {
                LogDebug("not a valid scheme according to definition. URI:" + uri + ", Scheme:" + unparsedUrl.Scheme + ", Authority:" + unparsedUrl.Authority);
                return false;
            }

            string relativePath;
            if (unparsedUrl.AbsolutePath.Contains("VrVektoren"))
            {
                relativePath = unparsedUrl.AbsolutePath.Split(new string[] { "VrVektoren" }, 2, StringSplitOptions.None)[1];
            }
            else
            {
                relativePath = unparsedUrl.Authority + unparsedUrl.AbsolutePath;
            }
            
            string[] path = relativePath.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
            if (path.Length != 2) // "[section]" / "[id]"
            {
                LogDebug("not a valid path according to definition. URI:" + uri);
                return false;
            }

            string section = path[0];
            string idString = path[1];

            if (!avaliableSections.Contains(section))
            {
                LogDebug("not a valid section according to definition. URI:" + uri);
                return false;
            }

            if (!int.TryParse(idString, out int id))
            {
                LogDebug("not a valid id according to definition. URI:" + uri);
                return false;
            }

            if (!VisualizationService.GetVisualizations().Any(p => p.Id == id))
            {
                LogDebug("not a existing id:" + idString);
                return false;
            }

            OpenVectorVisualizer(id);

            // Todo: Remove
            LogDebug(idString);

            return true;
        }

        public static void OpenVectorVisualizer(int visualizationId)
        {
            Guard.IsNotNull(visualizationId);

            var lastScene = Instance.currentScene;
            var visualizer = new Visualizer();
            visualizer.Vizualization = VisualizationService.GetVisualizations().Single(visualization => visualization.Id == visualizationId);
            visualizer.Load();
            Instance.currentScene = visualizer;
            Instance.vectorVisualizer = visualizer;

            SceneManager.LoadSceneAsync("Scenes/VectorVisualizer");

            CloseScene(lastScene);
        }

        public static void OpenQRCodeScanner()
        {
            var lastScene = Instance.currentScene;
            var qRScanner = new QRCodeScanner();
            qRScanner.Load();
            Instance.currentScene = qRScanner;
            Instance.qRCodeScanner = qRScanner;
            
            SceneManager.LoadSceneAsync("Scenes/QRCodeScanner");

            CloseScene(lastScene);
        }

        public static void OpenSceneSelection()
        {
            var lastScene = Instance.currentScene;
            var selection = new SceneSelection();
            selection.Load();
            Instance.currentScene = selection;
            Instance.sceneSelection = selection;
            
            SceneManager.LoadSceneAsync("Scenes/SceneSelection");

            CloseScene(lastScene);
        }
    }
}
