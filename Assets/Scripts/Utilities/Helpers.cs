using System;

namespace Utilities
{
    public static class Helpers
    {
        public static T GetRandomEnumValue<T>() where T : Enum
        {
            Array values = Enum.GetValues(typeof(T));
            int index = UnityEngine.Random.Range(0, values.Length);
            return (T)values.GetValue(index);
        }
    }
}