using UnityEditor;
using UnityEngine;

namespace Resources
{
    [InitializeOnLoad]
    public class StyleHierarchy
    {
        private static readonly string[]     dataArray; //  Find ColorPalette GUID
        private static readonly ColorPalette colorPalette;

        static StyleHierarchy()
        {
            dataArray = AssetDatabase.FindAssets("t:ColorPalette");

            if (dataArray.Length < 1)
                return;

            //We have only one color palette, so we use dataArray[0] to get the path of the file
            var path = AssetDatabase.GUIDToAssetPath(dataArray[0]);

            colorPalette = AssetDatabase.LoadAssetAtPath<ColorPalette>(path);

            EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyWindow;
        }

        private static void OnHierarchyWindow(int instanceID, Rect selectionRect)
        {
            //To make sure there is no error on the first time the tool imported in project
            if (dataArray.Length == 0)
                return;

            var instance = EditorUtility.InstanceIDToObject(instanceID);

            if (instance == null)
                return;

            foreach (var design in colorPalette.colorDesigns)
            {
                //Check if the name of each gameObject is begun with keyChar in colorDesigns list.
                if (!instance.name.StartsWith(design.keyChar))
                    continue;

                //Remove the symbol(keyChar) from the name.
                var newName = instance.name[design.keyChar.Length..];

                //Draw a rectangle as a background, and set the color.
                EditorGUI.DrawRect(selectionRect, design.backgroundColor);

                //Create a new GUIStyle to match the design in colorDesigns list.
                var newStyle = new GUIStyle
                               {
                                   alignment = design.textAlignment,
                                   fontStyle = design.fontStyle,
                                   normal = new GUIStyleState()
                                            {
                                                textColor = design.textColor,
                                            }
                               };

                //Draw a label to show the name in upper letters and newStyle.
                //If you don't like all capital latter, you can remove ".ToUpper()".
                // EditorGUI.LabelField(selectionRect, newName.ToUpper(), newStyle);
                EditorGUI.LabelField(selectionRect, newName, newStyle);
            }
        }
    }
}