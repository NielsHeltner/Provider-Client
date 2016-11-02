﻿using Provider.domain.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.domain.page
{
    public class PageManager
    {
        public List<Page> pages { get; private set; }

        public PageManager() //Temporary
        {
            pages = new List<Page>();
            pages.Add(new Page(new Supplier("Vitafit", "password1234")));
            pages.Add(new Page(new Supplier("B2Vitas", "password1234")));
            pages.Add(new Page(new Supplier("ProteinVitmins", "password1234")));
            Console.WriteLine(pages.GetType());
        }

        /// <summary>
        /// Returns a suppliers page
        /// </summary>
        /// <param name="supplier">The name of the suppliers page that should</param>
        /// <returns>Returns a specifik suppliers page</returns>
        public Page GetSupplierPage(Supplier supplier)
        {
            return pages.Find(page => page.owner.Equals(supplier));
        }
    }
}
