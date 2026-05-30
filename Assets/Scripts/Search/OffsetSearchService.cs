using System.Collections.Generic;
using Data;
using UnityEngine;

namespace Search
{
    public class OffsetSearchService
    {
        private List<Matrix4x4> m_models;
        private List<Matrix4x4> m_spaces;
        private float m_epsilon;
        
        public OffsetSearchService(List<Matrix4x4> _models, List<Matrix4x4> _spaces, float _epsilon)
        {
            m_models = _models;
            m_spaces = _spaces;
            m_epsilon = _epsilon;
        }
        
        public List<Matrix4x4> Search()
        {
            var results = new List<Matrix4x4>();
            var baseModel = m_models[0];
            var inverseBaseModel = baseModel.inverse;
            var spaceIndex = new MatrixIndex(m_spaces, m_epsilon);

            foreach (var spaceMatrix in m_spaces)
            {
                var offset = spaceMatrix * inverseBaseModel;

                if (IsValidOffset(offset, m_models, spaceIndex))
                    results.Add(offset);
            }
            
            return results;
        }
        
        private bool IsValidOffset(Matrix4x4 _offset, IReadOnlyList<Matrix4x4> _model, MatrixIndex _spaceIndex)
        {
            for (var i = 0; i < _model.Count; i++)
            {
                var transformed = _offset * _model[i];
                if (!_spaceIndex.ContainsApprox(transformed))
                    return false;
            }

            return true;
        }
    }
}