using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using UnityEngine;
using Newtonsoft.Json;

namespace Loading
{
    public static class MatrixJsonLoader
    {
        public static List<Matrix4x4> LoadMatrices(string _json)
        {
            var dtos = JsonConvert.DeserializeObject<List<MatrixDto>>(_json);
            
            if (dtos == null)
                throw new Exception("Failed to parse matrices json");
            
            return dtos.Select(_x => _x.ToMatrix()).ToList();
        }
    }
}