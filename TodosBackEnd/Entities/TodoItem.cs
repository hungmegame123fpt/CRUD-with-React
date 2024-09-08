using System;
using System.Collections.Generic;

namespace TodosBackEnd.Entities;

public  class TodoItem
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool? IsComplete { get; set; }
}
