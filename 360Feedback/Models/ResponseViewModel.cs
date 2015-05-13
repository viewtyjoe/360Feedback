using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _360Feedback.Models
{
    public class ResponseViewModel
    {
        private List<List<decimal>> _NumericValues;
        private List<decimal> _Averages;

        public Student StudentFor { get; set; }

        public List<Question> Questions;

        private List<Response> _Responses;
        public List<Response> Responses
        {
            get{
                return _Responses;
            }
            set{
                _Responses = value;
                _Averages = new List<decimal>(value.Count);
                _NumericValues = new List<List<decimal>>(value.Count);
                int count = 0;
                List<decimal> averages = new List<decimal>();
                foreach(Response r in _Responses)
                {
                    string[] values = r.ResponseValues.Split(new char[]{','});
                    decimal[] decimalValues = new decimal[values.Length];
                    for(int i = 0; i < values.Length; i++)
                    {
                        decimalValues[i] = Decimal.Parse(values[i]);
                        if(count > 0)
                        {
                            averages[i] = (averages[i] + decimalValues[i]) / 2;
                        }
                        else
                        {
                            averages.Add(decimalValues[i]);
                        }
                    }
                    _NumericValues.Add(new List<decimal>(decimalValues));
                    count++;
                }
                _Averages.AddRange(averages);
            }
        }

        public List<List<decimal>> NumericValues
        {
            get { return _NumericValues; }
        }

        public List<decimal> Averages { get { return _Averages; } }
    }
}