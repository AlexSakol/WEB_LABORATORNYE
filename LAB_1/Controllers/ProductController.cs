using Microsoft.AspNetCore.Mvc;
using WEB.Models;

namespace WEB.Controllers
{
    public class ProductController : Controller
    {
        private List<Good> goods;
        private List<Section> sections;

        public ProductController()
        {
            SetupData();
        }

        public IActionResult Index() => View(goods);

        private void SetupData()
        {
            sections = new List<Section>() { 
                new Section{ Id = 1, Name = "Одежда"},
                new Section{ Id = 2, Name = "Мебель"},
                new Section{ Id = 3, Name = "Компьютеры"}
            };

            goods = new List<Good>() {
                new Good{ Id = 1, Name= "Рубашка", Description="Белая", Count = 5, SectionId = 1, Image = "Shirt.jpg"},
                new Good{ Id = 2, Name= "Кофта", Description="Шерстяная", Count = 7, SectionId = 1, Image = "Jacket.jpg"},
                new Good{ Id = 3, Name= "Монитор", Description="ЖК, 12 дюймов", Count = 2, SectionId = 3, Image = "Screen.jpg"},
                new Good{ Id = 4, Name= "Стул", Description="Деревянный, жесткий", Count = 4, SectionId = 2, Image="Chair.jpg"},
                new Good{ Id = 5, Name= "Кресло", Description="Мягкое, кожаное", Count = 8, SectionId = 2, Image="Armchair.jpg"}
            };
        }
    }
}
