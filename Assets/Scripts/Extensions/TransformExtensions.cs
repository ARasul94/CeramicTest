using UnityEngine;

namespace Extensions
{
    public static class TransformExtensions
    {
        public static void ApplyLocalTRS(this Transform _tr, Matrix4x4 _trs)
        {
            _tr.localPosition = _trs.ExtractPosition();
            _tr.localRotation = _trs.ExtractRotation();
            _tr.localScale = _trs.ExtractScale();
        }
    }
}