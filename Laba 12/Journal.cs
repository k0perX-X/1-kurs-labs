using System.Collections.Generic;

namespace Laba_12
{
    public class Journal
    {
        public class JournalEntry
        {
            public string NameCollection { get; }
            public string TypeOfChange { get; }
            public string CollectionState { get; }

            public JournalEntry(string nameCollection, string typeOfChange, object obj)
            {
                NameCollection = nameCollection;
                TypeOfChange = typeOfChange;
                CollectionState = obj.ToString();
            }

            public override string ToString()
            {
                return $"{NameCollection}, Edited: {TypeOfChange}, Collection state: {CollectionState}";
            }
        }

        public void AddInList(object source, Task.CollectionHandlerEventArgs args)
        {
            List.Add(new JournalEntry(args.NameCollection, args.TypeOfChange, args.Object));
        }

        public List<JournalEntry> List = new List<JournalEntry>();

        public override string ToString()
        {
            string s = "";
            foreach (JournalEntry journalEntry in List)
            {
                s += journalEntry + "\n";
            }
            return s;
        }
    }
}