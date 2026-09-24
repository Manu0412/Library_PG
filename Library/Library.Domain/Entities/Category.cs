using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Entities
{
    public sealed class Category
    {

        public int Id { get; private set; }
        public string Name { get; private set; } = null;

        public Category(string name)
        {
            Name = name;
        }

        private Category()
        {
        }
    }
}
