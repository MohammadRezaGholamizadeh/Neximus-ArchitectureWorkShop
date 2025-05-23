using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neximus.WorkShop.Domain.Products.Categories;

public class ProductCategory
{
    public long Id  { get; set; }
    public string Title { get; set; }
    public string Descreption { get; set; }
    public string Slug { get; set; }
}
