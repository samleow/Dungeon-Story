using Newtonsoft.Json;

namespace Assets.AltUnityTester.AltUnityServer.Commands
{
    class AltUnitySetMultipointSwipeCommand : AltUnityCommand
    {
        UnityEngine.Vector2 start;
        UnityEngine.Vector2 destination;
        string duration;

        public AltUnitySetMultipointSwipeCommand(params string[] parameters) : base(parameters, 5)
        {
            this.start = JsonConvert.DeserializeObject<UnityEngine.Vector2>(parameters[2]);
            this.destination = JsonConvert.DeserializeObject<UnityEngine.Vector2>(parameters[3]);
            this.duration = parameters[4];
        }

        public override string Execute()
        {
#if ALTUNITYTESTER
            LogMessage("Touch at: " + start);
            string response = AltUnityErrors.errorNotFoundMessage;

            UnityEngine.Vector2[] positions = { start, destination };
            Input.SetMultipointSwipe(positions, float.Parse(duration));
            response = "Ok";

            return response;
#else
            return null;
#endif
        }
    }
}
