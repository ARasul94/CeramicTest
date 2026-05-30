using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Data;
using Export;
using IO;
using Loading;
using Search;
using TMPro;
using UnityEngine;

namespace Visual
{
    public class SearchController: MonoBehaviour
    {
        [SerializeField] private float m_epsilon = 0.0001f;
        [SerializeField] private string m_modelPath = "model";
        [SerializeField] private string m_spacePath = "space";
        [SerializeField] private CubesDrawer m_cubesDrawer;
        [SerializeField] private TextMeshProUGUI m_modelCountField;
        [SerializeField] private TextMeshProUGUI m_spaceCountField;
        [SerializeField] private TextMeshProUGUI m_offsetCountField;
        [SerializeField] private Transform m_modelsContainer;
        [SerializeField] private Transform m_spacesContainer;
        [SerializeField] private Transform m_offsetsContainer;

        private void Start()
        {
            Search();
        }

        public void Search()
        {
            var modelsText = FileReader.Read(m_modelPath);
            var models = MatrixJsonLoader.LoadMatrices(modelsText);
            StartCoroutine(m_cubesDrawer.Draw(models, m_modelsContainer, Color.yellow));
            m_modelCountField.text = models.Count.ToString();
            Debug.Log(models.Count);
            
            var spaceText = FileReader.Read(m_spacePath);
            var spaces = MatrixJsonLoader.LoadMatrices(spaceText);
            StartCoroutine(m_cubesDrawer.Draw(spaces, m_spacesContainer, Color.white));
            Debug.Log(spaces.Count);
            m_spaceCountField.text = spaces.Count.ToString();
            
            var offsetService = new OffsetSearchService(models, spaces, m_epsilon);
            var results = offsetService.Search();
            StartCoroutine(m_cubesDrawer.Draw(results, m_offsetsContainer, Color.green));
            Debug.Log(results.Count);
            m_offsetCountField.text = results.Count.ToString();

            var path = Path.Combine(Application.persistentDataPath, "offsets.json");
            OffsetExporter.Export(path, results);
            Debug.Log($"Path:\n{path}");
        }
        
        
    }
}