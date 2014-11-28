using System;
using System.Collections.Generic;
using System.Linq;
using EPiServer.ServiceLocation;
using EPiServer.Shell.ObjectEditing;

namespace EPiServer.Templates.Alloy.Business.EditorDescriptors
{
    [ServiceConfiguration(typeof(ISelectionQuery))]
    public class SampleSelectionQuery : ISelectionQuery
    {
        SelectItem[] _items;
        public SampleSelectionQuery()
        {
            _items = new SelectItem[] { 
                new SelectItem() { Text = "Linus Ekström", Value = "LE" },
                new SelectItem() { Text = "Martin Henricsson", Value = "MH" },
                new SelectItem() { Text = "Marcus Granström", Value = "MG" } };
        }
        public IEnumerable<ISelectItem> GetItems(string query)
        {
            return _items.Where(i => i.Text.StartsWith(query, StringComparison.OrdinalIgnoreCase));
        }
        public ISelectItem GetItemByValue(string value)
        {
            return _items.FirstOrDefault(i => i.Value.Equals(value));
        }
    }
}