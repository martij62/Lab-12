using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab12
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
                {
                Response.Write("Please enter valid search keyword");
                return;
                }

            var books = Books.GetBooks();
            var sortedBooks = from bookItem in books
                              where bookItem.Title.Contains(txtSearch.Text)
                              orderby bookItem.Title
                              select bookItem;

            GridView1.DataSource = sortedBooks;
            GridView1.DataBind(); //Must always call after setting datasource
        }
    }
}