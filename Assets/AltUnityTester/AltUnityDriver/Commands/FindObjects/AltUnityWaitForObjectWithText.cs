namespace Altom.AltUnityDriver.Commands
{
    public class AltUnityWaitForObjectWithText : AltUnityBaseFindObjects
    {
        By by;
        string value;
        string text;
        By cameraBy;
        string cameraPath;
        bool enabled;
        double timeout;
        double interval;
        public AltUnityWaitForObjectWithText(SocketSettings socketSettings, By by, string value, string text, By cameraBy, string cameraPath, bool enabled, double timeout, double interval) : base(socketSettings)
        {
            this.by = by;
            this.value = value;
            this.cameraBy = cameraBy;
            this.cameraPath = cameraPath;
            this.enabled = enabled;
            this.timeout = timeout;
            this.interval = interval;
            this.text = text;
        }
        public AltUnityObject Execute()
        {
            string path = SetPath(by, value);
            double time = 0;
            AltUnityObject altElement = null;
            while (time < timeout)
            {
                try
                {
                    altElement = new AltUnityFindObject(SocketSettings, by, value, cameraBy, cameraPath, enabled).Execute();
                    if (altElement.GetText().Equals(text))
                        break;
                    throw new System.Exception("Not the wanted text");
                }
                catch (NotFoundException)
                {
                    System.Threading.Thread.Sleep(System.Convert.ToInt32(interval * 1000));
                    time += interval;
                    System.Diagnostics.Debug.WriteLine("Object " + path + " not found");
                }
                catch (System.Exception)
                {
                    System.Threading.Thread.Sleep(System.Convert.ToInt32(interval * 1000));
                    time += interval;
                    System.Diagnostics.Debug.WriteLine("Waiting for element " + path + " to have text " + text);
                }
            }
            if (altElement != null && altElement.GetText().Equals(text))
            {
                return altElement;
            }
            throw new WaitTimeOutException("Element with text: " + text + " not loaded after " + timeout + " seconds");
        }
    }
}