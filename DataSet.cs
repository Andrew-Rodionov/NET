using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace курсовая_ппNET
{
    public class DataSet
    {
        public List<double[]> Features { get; }
        public List<int> Labels { get; }

        public DataSet(List<double[]> features, List<int> labels)
        {
            Features = features;
            Labels = labels;
        }
    }
}
