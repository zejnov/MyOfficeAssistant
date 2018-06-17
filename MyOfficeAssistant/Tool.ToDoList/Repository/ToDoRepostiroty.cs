using System.Collections.Generic;
using ToDoList.Domain;

namespace ToDoList.Repository
{
    public class ToDoRepostiroty
    {
        public static Dictionary<long, Element> Elements { get; set; }
    }
}