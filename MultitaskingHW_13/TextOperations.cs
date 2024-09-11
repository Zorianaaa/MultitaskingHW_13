using System.Collections.Generic;
using System.IO;

class TextOperations
{
    private string text;

    public TextOperations(string filePath)
    {
        this.text = File.ReadAllText(filePath);
    }

    public Dictionary<char, int> GetCharFrequency()
    {
        Dictionary<char, int> frequency = new Dictionary<char, int>();

        foreach (char c in text)
        {
            if (frequency.ContainsKey(c))
                frequency[c]++;
            else
                frequency[c] = 1;
        }
        return frequency;
    }

    public Dictionary<string, int> GetWordFrequency()
    {
        Dictionary<string, int> frequency = new Dictionary<string, int>();
        string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (string word in words)
        {
            if (frequency.ContainsKey(word))
                frequency[word]++;
            else
                frequency[word] = 1;
        }
        return frequency;
    }
}
