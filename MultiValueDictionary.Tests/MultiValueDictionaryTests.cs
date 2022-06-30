using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MultiValueDictionary.Tests
{
    public class MultiValueDictionaryTests
    {

        private Dictionary<string, List<string>> _dictionary;

        public MultiValueDictionaryTests()
        {
            _dictionary = new Dictionary<string, List<string>>();
        }

        [Fact]
        public void GetKeys_ReturnNull_whenEmpty()
        {
            var MVDict = new MultiValueDictionary();
            var result = MVDict.GetKeys();
            Assert.Null(result);
        }

        [Fact]
        public void GetKeys_ReturnKeys_whenAvailable()
        {
            _dictionary.Add("foo", new List<string> { "good" });
            var MVDict = new MultiValueDictionary(_dictionary);
            var result = MVDict.GetKeys();
            Assert.NotNull(result);
            Assert.Equal("foo",result[0]);
        }

        [Fact]
        public void GetMembers_ReturnNull_whenEmpty()
        {
            var MVDict = new MultiValueDictionary();
            var result = MVDict.GetMembers("foo");
            Assert.Null(result);
        }

        [Fact]
        public void GetMembers_ReturnMembers_whenAvailable()
        {
            _dictionary.Add("foo", new List<string> { "good", "bad" });
            var MVDict = new MultiValueDictionary(_dictionary);
            var result = MVDict.GetMembers("foo");
            Assert.NotNull(result);
            Assert.Equal("good", result[0]);
        }

        [Fact]
        public void Add_ReturnFalse_IfkeyValueExist()
        {
            _dictionary.Add("foo", new List<string> { "good" });
            var MVDict = new MultiValueDictionary(_dictionary);
            var result = MVDict.add("foo", "good");
            Assert.False(result);
        }

        [Fact]
        public void Add_ReturnTrue_IfOnlykeyExist()
        {
            _dictionary.Add("foo", new List<string> { "good" });
            var MVDict = new MultiValueDictionary(_dictionary);
            var result = MVDict.add("foo", "bad");
            Assert.True(result);
        }

        [Fact]
        public void Add_ReturnTrue_IfNewValue()
        {
            _dictionary.Add("foo", new List<string> { "good" });
            var MVDict = new MultiValueDictionary(_dictionary);
            var result = MVDict.add("goo", "bad");
            Assert.True(result);
        }

        [Fact]
        public void Remove_ReturnFalse_IfKeyNotExists()
        {
            _dictionary.Add("foo", new List<string> { "good" });
            var MVDict = new MultiValueDictionary(_dictionary);
            var result = MVDict.Remove("goo", "good");
            Assert.False(result.Item1);
        }

        [Fact]
        public void Remove_ReturnTrue_IfKeyExists()
        {
            _dictionary.Add("foo", new List<string> { "good" });
            var MVDict = new MultiValueDictionary(_dictionary);
            var result = MVDict.Remove("foo", "good");
            Assert.True(result.Item1);
        }

        [Fact]
        public void Remove_ReturnFalse_IfKeyExistsValueNotExists()
        {
            _dictionary.Add("foo", new List<string> { "good" });
            var MVDict = new MultiValueDictionary(_dictionary);
            var result = MVDict.Remove("foo", "bad");
            Assert.False(result.Item1);
        }

        [Fact]
        public void RemoveAll_ReturnFalse_IfKeyNotExists()
        {
            _dictionary.Add("foo", new List<string> { "good" });
            var MVDict = new MultiValueDictionary(_dictionary);
            var result = MVDict.RemoveAll("goo");
            Assert.False(result);
        }

        [Fact]
        public void RemoveAll_ReturnTrue_IfKeyExists()
        {
            _dictionary.Add("foo", new List<string> { "good" });
            var MVDict = new MultiValueDictionary(_dictionary);
            var result = MVDict.RemoveAll("foo");
            Assert.True(result);
        }

        [Fact]
        public void KeyExists_ReturnTrue_IfKeyExists()
        {
            _dictionary.Add("foo", new List<string> { "good" });
            var MVDict = new MultiValueDictionary(_dictionary);
            var result = MVDict.KeyExists("foo");
            Assert.True(result);
        }

        [Fact]
        public void KeyExists_ReturnFalse_IfKeyNotExists()
        {
            _dictionary.Add("foo", new List<string> { "good" });
            var MVDict = new MultiValueDictionary(_dictionary);
            var result = MVDict.KeyExists("goo");
            Assert.False(result);
        }

        [Fact]
        public void KeyExists_ReturnFalse_IfEmpty()
        {
            var MVDict = new MultiValueDictionary();
            var result = MVDict.KeyExists("goo");
            Assert.False(result);
        }

        [Fact]
        public void MemberExists_ReturnFalse_IfEmpty()
        {
            var MVDict = new MultiValueDictionary();
            var result = MVDict.MemberExists("goo","good");
            Assert.False(result);
        }

        [Fact]
        public void MemberExists_ReturnFalse_IfKeyNotExists()
        {
            _dictionary.Add("foo", new List<string> { "good" });
            var MVDict = new MultiValueDictionary(_dictionary);
            var result = MVDict.MemberExists("goo", "good");
            Assert.False(result);
        }

        [Fact]
        public void MemberExists_ReturnTrue_IfKeyandValueExists()
        {
            _dictionary.Add("foo", new List<string> { "good" });
            var MVDict = new MultiValueDictionary(_dictionary);
            var result = MVDict.MemberExists("foo", "good");
            Assert.True(result);
        }

        [Fact]
        public void MemberExists_ReturnFalse_IfValueNotExists()
        {
            _dictionary.Add("foo", new List<string> { "good" });
            var MVDict = new MultiValueDictionary(_dictionary);
            var result = MVDict.MemberExists("foo", "bad");
            Assert.False(result);
        }

        [Fact]
        public void AllMembers_ReturnNull_IfEmpty()
        {
            var MVDict = new MultiValueDictionary();
            var result = MVDict.AllMembers();
            Assert.Null(result);
        }

        [Fact]
        public void AllMembers_ReturnMembers_IfExists()
        {
            _dictionary.Add("foo", new List<string> { "good" });
            _dictionary.Add("goo", new List<string> { "good" });

            var MVDict = new MultiValueDictionary(_dictionary);
            var result = MVDict.AllMembers();
            Assert.Equal("good", result[0]);
            Assert.Equal("good", result[1]);
        }
    }
}
