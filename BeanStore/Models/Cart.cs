using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeanStore.Models;

namespace BeanStore.Models
{
    public class Cart
    {
        //------------
        dbBeanDataContext data = new dbBeanDataContext();
        public int cId { set; get; }
        public string cName { set; get; }
        public string cImage_link { set; get; }
        public Double cPrice { set; get; }
        public Double cSale { set; get; }
        public int cQuantity { set; get; }
        public Double cAmount
        {
            get {
                if(cSale != 0)
                {
                    return (cQuantity * cPrice) - ((cQuantity * cPrice) * (cSale/100));
                }
                else { return cQuantity * cPrice; }
            }

        }
        //-------------
        public Cart (int item_id)
        {
            cId = item_id;
            item ite = data.items.Single(n => n.id == cId);
            cName = ite.name;
            cImage_link = ite.image_link;
            cPrice = double.Parse(ite.price.ToString());
            cSale = double.Parse(ite.sale.ToString());
            cQuantity = 1;
        }
    }
}