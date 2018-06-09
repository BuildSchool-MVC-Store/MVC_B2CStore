using OSLibrary.ADO.NET.Repositories;
using OSLibrary.Containers;
using OSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLibrary.Sevices
{
    public class CategoryService
    {
        public IEnumerable<Category> GetCategory()
        {
            return RepositoryContainer.GetInstance<CategoryRepository>().GetAll();
        }
    }
}
