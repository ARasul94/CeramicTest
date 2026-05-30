using System.Collections.Generic;
using System.IO;
using Data;
using Newtonsoft.Json;
using UnityEngine;

namespace Export
{
    public static class OffsetExporter
    {
        public static void Export(string _path, IReadOnlyList<Matrix4x4> _offsets)
        {
            var dtoList = new List<MatrixDto>(_offsets.Count);
            for (var i = 0; i < _offsets.Count; i++)
                dtoList.Add(MatrixDto.FromMatrix(_offsets[i]));

            var directory = Path.GetDirectoryName(_path);
            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var json = JsonConvert.SerializeObject(dtoList, Formatting.Indented);
            File.WriteAllText(_path, json);
        }
    }
}