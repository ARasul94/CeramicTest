using System.Collections;
using System.Collections.Generic;
using Extensions;
using UnityEngine;

namespace Visual
{
    public class CubesDrawer: MonoBehaviour
    {
        [SerializeField] private Renderer m_cubePrefab;
        
        public IEnumerator Draw(List<Matrix4x4> _matrices, Transform _parent, Color _color)
        {
            var material = CreateMaterial(_color);
            var i = 0;
            foreach (var matrix in _matrices)
            {
                var cube = Instantiate(m_cubePrefab, _parent);
                cube.sharedMaterial = material;
                cube.transform.ApplyLocalTRS(matrix);
                i++;
                if (i % 100 == 0)
                {
                    i = 0;
                    yield return null;
                }
            }
        }
        
        private Material CreateMaterial(Color _color)
        {
            Material material = new Material(Shader.Find("Standard"));
            material.color = _color;
            return material;
        }
    }
}