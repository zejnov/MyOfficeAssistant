using System.Collections.Generic;
using System.Linq;
using ToDoList.Domain;
using ToDoList.Repository;

namespace ToDoList.Service.Impl
{
    public class ElementService
    {
        private Dictionary<long, Element> Elements = ToDoRepostiroty.Elements;
        
        public Element Add(Element element)
        {
            var elementId = Elements.Count + 1;
            Elements.Add(elementId, element);
            
            element.Id = elementId;
            return element;
        }

        public Element Get(long id)
        {
            var result = Elements.TryGetValue(id, out var element);

            return result
                ? element
                : null;  //throw ex
        }

        public List<Element> GetAll()
        {
            return Elements
                .Select(e => e.Value)
                .ToList();
        }
        
    }
}