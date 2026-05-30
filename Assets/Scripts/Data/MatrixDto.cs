using System;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Serialization;

namespace Data
{
    [Serializable]
    public class MatrixDto
    {
        [JsonProperty("m00")] public float m_00;
        [JsonProperty("m10")] public float m_10;
        [JsonProperty("m20")] public float m_20;
        [JsonProperty("m30")] public float m_30;
        [JsonProperty("m01")] public float m_01;
        [JsonProperty("m11")] public float m_11;
        [JsonProperty("m21")] public float m_21;
        [JsonProperty("m31")] public float m_31;
        [JsonProperty("m02")] public float m_02;
        [JsonProperty("m12")] public float m_12;
        [JsonProperty("m22")] public float m_22;
        [JsonProperty("m32")] public float m_32;
        [JsonProperty("m03")] public float m_03;
        [JsonProperty("m13")] public float m_13;
        [JsonProperty("m23")] public float m_23;
        [JsonProperty("m33")] public float m_33;

        public Matrix4x4 ToMatrix()
        {
            var m = new Matrix4x4
            {
                m00 = m_00,
                m10 = m_10,
                m20 = m_20,
                m30 = m_30,
                m01 = m_01,
                m11 = m_11,
                m21 = m_21,
                m31 = m_31,
                m02 = m_02,
                m12 = m_12,
                m22 = m_22,
                m32 = m_32,
                m03 = m_03,
                m13 = m_13,
                m23 = m_23,
                m33 = m_33
            };

            return m;
        }

        public static MatrixDto FromMatrix(Matrix4x4 _m)
        {
            return new MatrixDto
            {
                m_00 = _m.m00, m_10 = _m.m10, m_20 = _m.m20, m_30 = _m.m30,
                m_01 = _m.m01, m_11 = _m.m11, m_21 = _m.m21, m_31 = _m.m31,
                m_02 = _m.m02, m_12 = _m.m12, m_22 = _m.m22, m_32 = _m.m32,
                m_03 = _m.m03, m_13 = _m.m13, m_23 = _m.m23, m_33 = _m.m33
            };
        }
    }
}