namespace GlowAutomation.Framework
{
    public delegate void LogElementState(string messageKey, string stateKey);

    public delegate void LogVisualState(string messageKey, params object[] values);
}