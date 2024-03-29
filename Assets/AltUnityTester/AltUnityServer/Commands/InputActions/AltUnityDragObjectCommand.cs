﻿using Altom.AltUnityDriver;
using Newtonsoft.Json;

namespace Assets.AltUnityTester.AltUnityServer.Commands
{
    class AltUnityDragObjectCommand : AltUnityCommand
    {
        UnityEngine.Vector2 position;
        AltUnityObject altUnityObject;

        public AltUnityDragObjectCommand(params string[] parameters) : base(parameters, 4)
        {
            this.position = JsonConvert.DeserializeObject<UnityEngine.Vector2>(parameters[2]);
            this.altUnityObject = JsonConvert.DeserializeObject<AltUnityObject>(parameters[3]);
        }

        public override string Execute()
        {
            LogMessage("Drag object: " + altUnityObject);
            string response = AltUnityErrors.errorNotFoundMessage;
            AltUnityMockUpPointerInputModule mockUp = new AltUnityMockUpPointerInputModule();
            var pointerEventData = mockUp.ExecuteTouchEvent(new UnityEngine.Touch() { position = position });
            UnityEngine.GameObject gameObject = AltUnityRunner.GetGameObject(altUnityObject);
            UnityEngine.Camera viewingCamera = AltUnityRunner._altUnityRunner.FoundCameraById(altUnityObject.idCamera);
            UnityEngine.Vector3 gameObjectPosition = viewingCamera.WorldToScreenPoint(gameObject.transform.position);
            pointerEventData.delta = pointerEventData.position - new UnityEngine.Vector2(gameObjectPosition.x, gameObjectPosition.y);
            LogMessage("GameOBject: " + gameObject);
            UnityEngine.EventSystems.ExecuteEvents.Execute(gameObject, pointerEventData, UnityEngine.EventSystems.ExecuteEvents.dragHandler);
            var camera = AltUnityRunner._altUnityRunner.FoundCameraById(altUnityObject.idCamera);
            response = Newtonsoft.Json.JsonConvert.SerializeObject(camera != null ? AltUnityRunner._altUnityRunner.GameObjectToAltUnityObject(gameObject, camera) : AltUnityRunner._altUnityRunner.GameObjectToAltUnityObject(gameObject));
            return response;
        }
    }
}
