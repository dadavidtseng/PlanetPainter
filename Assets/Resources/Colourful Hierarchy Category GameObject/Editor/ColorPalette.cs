using System.Collections.Generic;
using UnityEngine;

namespace Resources
{
    /// <summary>
    /// Details of custom design
    /// </summary>
    [System.Serializable]
    public class ColorDesign
    {
        [Tooltip("Rename gameObject begin with this key char")]
        public string keyChar;

        [Tooltip("Don't forget to change alpha to 255")]
        public Color textColor;

        [Tooltip("Don't forget to change alpha to 255")]
        public Color backgroundColor;

        public TextAnchor textAlignment;
        public FontStyle  fontStyle;
    }

    /// <summary>
    /// ScriptableObject:Save list of ColorDesign
    /// </summary>
    public class ColorPalette : ScriptableObject
    {
        public List<ColorDesign> colorDesigns = new();
    }
}