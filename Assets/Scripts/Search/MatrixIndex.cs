using System.Collections.Generic;
using UnityEngine;

namespace Search
{
    public class MatrixIndex
    {
        private const float CELL_SIZE_MULTIPLIER = 2f;
        
        private readonly Dictionary<Vector3Int, List<Matrix4x4>> m_buckets;
        private readonly float m_cellSize;
        private readonly float m_epsilon;

        public MatrixIndex(IReadOnlyList<Matrix4x4> _matrices, float _epsilon)
        {
            m_epsilon = _epsilon;
            m_cellSize = _epsilon * CELL_SIZE_MULTIPLIER;
            m_buckets = new Dictionary<Vector3Int, List<Matrix4x4>>(_matrices.Count);

            for (var i = 0; i < _matrices.Count; i++)
            {
                var key = GetPositionKey(_matrices[i]);
                List<Matrix4x4> bucket;
                if (!m_buckets.TryGetValue(key, out bucket))
                {
                    bucket = new List<Matrix4x4>();
                    m_buckets.Add(key, bucket);
                }

                bucket.Add(_matrices[i]);
            }
        }

        public bool ContainsApprox(Matrix4x4 _target)
        {
            var baseKey = GetPositionKey(_target);

            for (var x = -1; x <= 1; x++)
            {
                for (var y = -1; y <= 1; y++)
                {
                    for (var z = -1; z <= 1; z++)
                    {
                        var key = new Vector3Int(baseKey.x + x, baseKey.y + y, baseKey.z + z);
                        
                        if (!m_buckets.TryGetValue(key, out var candidates))
                            continue;

                        for (var i = 0; i < candidates.Count; i++)
                        {
                            if (candidates[i].ApproxEqual(_target, m_epsilon))
                                return true;
                        }
                    }
                }
            }

            return false;
        }

        private Vector3Int GetPositionKey(Matrix4x4 _matrix)
        {
            return new Vector3Int(
                Mathf.FloorToInt(_matrix.m03 / m_cellSize),
                Mathf.FloorToInt(_matrix.m13 / m_cellSize),
                Mathf.FloorToInt(_matrix.m23 / m_cellSize));
        }
    }
}