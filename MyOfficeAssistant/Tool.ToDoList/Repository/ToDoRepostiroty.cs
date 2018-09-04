using System.Collections.Generic;
using Tool.ToDoList.Domain;

namespace Tool.ToDoList.Repository
{
    public class ToDoRepostiroty
    {
        public static Dictionary<long, Element> Elements { get; set; }
    }
}