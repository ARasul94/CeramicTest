using System;
using UnityEngine;

namespace IO
{
    public static class FileReader
    {
        public static string Read(string _path)
        {
            var textAsset = Resources.Load<TextAsset>(_path);
            if (textAsset == null)
                throw new InvalidOperationException("Resource not found: " + _path);
            
            return textAsset.text;
        }
    }
}