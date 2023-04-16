using UnityEngine;

namespace Globals.Utils
{
    public static class ObjectNameHierarchyPrinter
    {
        public static string Get(Transform t)
        { 
            Transform currTransform = t;
            string result = currTransform.name;

            while (currTransform.parent != null)
            {
                currTransform = currTransform.parent;
                result += " / " + currTransform.name;
            }

            return result;
        }
    }
}
