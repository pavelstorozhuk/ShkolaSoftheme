using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Task18_2
{
    public class CallsInfo
    {
        public CallsInfo()
        {

        }
        public int CountOfCalled { get; set; }
        public double ActivityPoint { get; set; }
    }
    public class MagazineOfCalls
    {
      

        private  readonly Dictionary<string, CallsInfo> _dictionary;

        public MagazineOfCalls()
        {
            _dictionary = new Dictionary<string, CallsInfo>();
        }

        public void Add(string key)
        {
            _dictionary.Add(key, new CallsInfo());
        }
       
        public void AddCall(string key,string key2)
        {

            if (!_dictionary.ContainsKey(key))
            {
                _dictionary.Add(key,new CallsInfo());
            }
            if (!_dictionary.ContainsKey(key2))
            {
                _dictionary.Add(key2, new CallsInfo());
            }
            _dictionary[key].ActivityPoint++;
            _dictionary[key2].CountOfCalled++;

        }

        public IEnumerator GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        public void AddSms(string key)
        {
            if (!_dictionary.ContainsKey(key))
            {
                _dictionary.Add(key, new CallsInfo());
            }
           
            _dictionary[key].ActivityPoint+=0.5;
         
        }
        public List<KeyValuePair<string,CallsInfo>> GetTopCalledyUsers()
        {
            var result = (from t in _dictionary
                orderby t.Value.CountOfCalled descending
                select t).Take(5).ToList();
            return result;

        }
        public List<KeyValuePair<string, CallsInfo>> GetTopActivityUsers()
        {
            var result = (from t in _dictionary
                          orderby t.Value.ActivityPoint descending
                          select t).Take(5).ToList();
            return result;

        }
    }
}
