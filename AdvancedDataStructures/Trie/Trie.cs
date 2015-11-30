namespace Trie
{
    using System.Collections.Generic;

    public class Trie
    {
        private readonly Node root;

        public Trie()
        {
            this.root = new Node("");
        }

        public void AddWord(string word)
        {
            this.InnerAddWord(word, this.root);
        }

        private void InnerAddWord(string wordSubString, Node element)
        {
            while (true)
            {
                if (string.IsNullOrEmpty(wordSubString) || string.IsNullOrWhiteSpace(wordSubString))
                {
                    element.Occurances++;
                    return;
                }

                string currChar = wordSubString[0].ToString();

                if (!element.Children.ContainsKey(currChar))
                {
                    element.Children.Add(currChar, new Node(currChar) { Parent = element });
                }

                wordSubString = wordSubString.Substring(1);
                element = element.Children[currChar];
            }
        }

        public bool TryFindWord(string word, out int occurances)
        {
            return this.InnerTryFindWord(word, out occurances, root);
        }

        private bool InnerTryFindWord(string wordSubString, out int occurances, Node element)
        {
            while (true)
            {
                if (string.IsNullOrEmpty(wordSubString) || string.IsNullOrWhiteSpace(wordSubString))
                {
                    occurances = element.Occurances;
                    return true;
                }

                string currChar = wordSubString[0].ToString();

                if (!element.Children.ContainsKey(currChar))
                {
                    occurances = 0;
                    return false;
                }

                wordSubString = wordSubString.Substring(1);
                element = element.Children[currChar];
            }
        }

        private class Node
        {
            public Node(string value, int occurs = 0)
            {
                this.Children = new Dictionary<string, Node>();
                this.Value = value;
                this.Occurances = occurs;
            }

            public Node(char value, int occurs = 0)
                : this(value.ToString(), occurs)
            {
            }

            public string Value { get; set; }

            public int Occurances { get; set; }

            public Dictionary<string, Node> Children { get; set; }

            public Node Parent { get; set; }

            public override int GetHashCode()
            {
                return this.Value.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                var objAsNode = obj as Node;
                return objAsNode != null && this.Value.Equals(objAsNode.Value);
            }
        }
    }
}
