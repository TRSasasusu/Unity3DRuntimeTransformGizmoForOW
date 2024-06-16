using OWML.Common;
using OWML.ModHelper;

namespace Unity3DRuntimeTransformGizmoForOW {
    public class Unity3DRuntimeTransformGizmoForOW : ModBehaviour {
        private void Awake() {
            // You won't be able to access OWML's mod helper in Awake.
            // So you probably don't want to do anything here.
            // Use Start() instead.
        }

        private void Start() {
            // Starting here, you'll have access to OWML's mod helper.
            ModHelper.Console.WriteLine($"{nameof(Unity3DRuntimeTransformGizmoForOW)} is loaded!", MessageType.Success);


            // Example of accessing game code.
            LoadManager.OnCompleteSceneLoad += (scene, loadScene) => {
                if (loadScene != OWScene.SolarSystem) return;
                ModHelper.Console.WriteLine("Loaded into solar system!", MessageType.Success);
            };
        }
    }

}
