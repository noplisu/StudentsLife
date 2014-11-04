using UnityEngine;
using System.Collections;

public class ObjectHighlighter : MonoBehaviour
{
    public Material highlightedMaterial;
    public Material material;

    public void Highlight()
    {
        renderer.material = highlightedMaterial;
    }

    public void RemoveHighlight()
    {
        renderer.material = material;
    }
} 
