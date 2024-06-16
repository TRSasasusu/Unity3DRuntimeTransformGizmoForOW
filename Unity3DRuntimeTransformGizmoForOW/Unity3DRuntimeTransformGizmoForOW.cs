using OWML.Common;
using OWML.ModHelper;
using RuntimeGizmos;
using System.Collections;
using UnityEngine;

namespace Unity3DRuntimeTransformGizmoForOW {
    public class Unity3DRuntimeTransformGizmoForOW : ModBehaviour {
        public static Shader _lineShader;
        public static Shader _outlineShader;

        private void Awake() {
            // You won't be able to access OWML's mod helper in Awake.
            // So you probably don't want to do anything here.
            // Use Start() instead.
        }

        private void Start() {
            // Starting here, you'll have access to OWML's mod helper.
            ModHelper.Console.WriteLine($"{nameof(Unity3DRuntimeTransformGizmoForOW)} is loaded!", MessageType.Success);

            var bundle = ModHelper.Assets.LoadBundle("assets/runtimegizmo");
            _lineShader = bundle.LoadAsset<Shader>("Assets/RuntimeGizmo/Shader/Resources/Lines.shader");
            _outlineShader = bundle.LoadAsset<Shader>("Assets/RuntimeGizmo/Shader/Resources/Outline.shader");
            ModHelper.Console.WriteLine("Complete loading the bundle!", MessageType.Success);


            // Example of accessing game code.
            LoadManager.OnCompleteSceneLoad += (scene, loadScene) => {
                if (loadScene != OWScene.SolarSystem) return;
                ModHelper.Console.WriteLine("Loaded into solar system!", MessageType.Success);
                StartCoroutine(SetRuntimeGizmo());
                //var owcamera = Locator.GetActiveCamera();
            };
        }

        IEnumerator SetRuntimeGizmo() {
            OWCamera owcamera;
            while(true) {
                yield return null;
                owcamera = Locator._activeCamera;
                if(owcamera) {
                    break;
                }
            }
            ModHelper.Console.WriteLine($"owcamera: {owcamera}");
            ModHelper.Console.WriteLine($"owcamera.mainCamera: {owcamera.mainCamera}");
            owcamera.mainCamera.gameObject.AddComponent<TransformGizmo>();
        }
    }

}
