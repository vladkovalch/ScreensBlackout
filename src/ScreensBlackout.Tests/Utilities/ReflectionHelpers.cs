using System.Reflection;

namespace ScreensBlackout.Tests.Utilities
{
    internal static class ReflectionHelpers
    {
        public static T GetPrivateFieldValue<T>(this object obj, string fieldName)
        {
            var bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            var field = obj.GetType().GetField(fieldName, bindingFlags);

            return (T)field?.GetValue(obj);
        }
    }
}
