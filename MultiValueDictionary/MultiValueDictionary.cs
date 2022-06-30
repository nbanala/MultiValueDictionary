using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary
{
    public class MultiValueDictionary
    {
        private Dictionary<string, List<string>> dictionary;

        public MultiValueDictionary()
        {
            dictionary = new Dictionary<string, List<string>>();
        }

        public MultiValueDictionary(Dictionary<string, List<string>> dictionary)
        {
            this.dictionary = dictionary;
        }

        public List<string> GetKeys()
        {
            if (dictionary.Count == 0)
            {
                return null;
            }
            return dictionary.Keys.ToList();
        }

        public List<string> GetMembers(string key)
        {
            if (dictionary.Count == 0 || !dictionary.ContainsKey(key))
            {
                return null;
            }

            return dictionary[key];
        }

        public bool add(string key, string value)
        {
            if (dictionary.ContainsKey(key) && dictionary[key].Contains(value))
            {
                return false;
            }
            if (dictionary.ContainsKey(key))
            {
                dictionary[key].Add(value);
                return true;
            }
            dictionary.Add(key, new List<string> { value });
            return true;
        }

        public (bool, string) Remove(string key, string value)
        {
            if (dictionary.ContainsKey(key))
            {
                int valueSize = dictionary[key].Count;
                if (dictionary[key].Contains(value))
                {
                    if (valueSize > 1)
                    {
                        dictionary[key].Remove(value);
                        return (true, "Removed");
                    }
                    else
                    {
                        dictionary.Remove(key);
                        return (true, "Removed");
                    }
                }

                return (false, "Error, member does not exist");
            }

            return (false, "Error, Key does not exist");
        }

        public bool RemoveAll(string key)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary.Remove(key);
                return true;
            }
            return false;
        }

        public void Clear()
        {
            dictionary.Clear();
        }

        public bool KeyExists(string key)
        {
            if (dictionary.Count == 0)
            {
                return false;
            }

            return dictionary.ContainsKey(key);
        }

        public bool MemberExists(string key, string value)
        {
            if (dictionary.Count == 0 || !dictionary.ContainsKey(key))
            {
                return false;
            }

            return dictionary[key].Contains(value);
        }

        public List<string> AllMembers()
        {
            if (dictionary.Count == 0)
            {
                return null;
            }

            List<string> members = new List<string>();
            foreach (var key in dictionary.Keys)
            {
                members.AddRange(dictionary[key]);
            }

            return members;
        }
    }
}
