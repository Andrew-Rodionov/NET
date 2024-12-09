using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace курсовая_ппNET
{
    public class DataLoader
    {
        public DataSet LoadData(string filePath)
        {
            List<double[]> features = new List<double[]>();
            List<int> labels = new List<int>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(';');
                        if (parts.Length < 2)
                        {
                            throw new FormatException("Неверный формат данных. Каждая строка должна содержать хотя бы один признак и одну метку.");
                        }

                        double[] feature = new double[parts.Length - 1];
                        for (int i = 0; i < parts.Length - 1; i++)
                        {
                            if (!double.TryParse(parts[i], out feature[i]))
                            {
                                throw new FormatException($"Неверное значение признака: {parts[i]}");
                            }
                        }

                        if (!int.TryParse(parts[parts.Length - 1], out int label))
                        {
                            throw new FormatException($"Неверное значение метки: {parts[parts.Length - 1]}");
                        }

                        features.Add(feature);
                        labels.Add(label);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при загрузке данных: {ex.Message}");
            }

            return new DataSet(features, labels);
        }

        public void PreprocessData(DataSet dataSet)
        {
            // Пример предобработки: нормализация данных
            for (int i = 0; i < dataSet.Features[0].Length; i++)
            {
                double min = double.MaxValue;
                double max = double.MinValue;

                foreach (var feature in dataSet.Features)
                {
                    if (feature[i] < min) min = feature[i];
                    if (feature[i] > max) max = feature[i];
                }

                foreach (var feature in dataSet.Features)
                {
                    feature[i] = (feature[i] - min) / (max - min);
                }
            }
        }
    }
}
