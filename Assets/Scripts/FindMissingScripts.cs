#region
/// copyright (c) iNucom. All rights reserved.
#endregion

using UnityEngine;
using UnityEditor;
using System.Linq;

namespace Inucom{
    public static class FindMissingScripts
    {
        [MenuItem("My Menu/Find MissingScripts in Project ")]
        static void FindMissingScriptsInProjectMenuItem()
        {
            string[] prefabPaths = AssetDatabase.GetAllAssetPaths().Where(path => path.EndsWith(".prefab", System.StringComparison.OrdinalIgnoreCase)).ToArray();

            foreach (string path in prefabPaths)
            {
                GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
                foreach (Component component in prefab.GetComponentsInChildren<Component>())
                {
                    if (component == null)
                    {
                        Debug.Log("prefab found with missing script" + path, prefab);
                        break;
                    }
                }

            }
        }

        [MenuItem("My Menu/Find MissingScripts in Scene")]
        static void FindMissingScriptsInSceneMenuItem()
        {
            foreach (GameObject gameObject in GameObject.FindObjectsOfType<GameObject>(true))
            {
                foreach (Component component in gameObject.GetComponentsInChildren<Component>())
                {
                    if (component == null)
                    {
                        Debug.Log("prefab found with missing script" + gameObject.name, gameObject);
                        break;
                    }
                }

            }
        }
    }
 }