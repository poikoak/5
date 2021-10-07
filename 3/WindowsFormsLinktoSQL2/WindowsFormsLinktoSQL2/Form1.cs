using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsLinktoSQL2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        readonly MyDataContext db = new MyDataContext();

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            // -показать всех авторов книг в жанре 'business', которые живут в штате CA(2 способа, JOIN, подзапросы)
            /*  var result =( from t in db.authors
                           join p in db.titleauthors on t.au_id equals p.au_id
                           where t.state == "CA"
                           from s in db.titles
                           join q in db.titleauthors on s.title_id equals q.title_id
                           where s.type == "Business"
                           select new
                           {
                               Authors = t.au_fname,
                               State = t.state,
                               Type=s.type                       
                           }).Distinct(); */


            var result = db.titles.Where(book => book.type == "Business").Join(db.titleauthors.Join(db.authors.Where(a => a.state == "CA"), p => p.au_id, a => a.au_id,
                (p, a) => new { FirstName = a.au_fname, LastName = a.au_lname, State = a.state, title_id = p.title_id }),
                t => t.title_id, p => p.title_id, (t, p) =>
                new { FirstName = p.FirstName, LastName = p.LastName, Type = t.type, State = p.State });


            dataGridView1.DataSource = result;

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            //-показать все магазины, которые продают книги в жанре 'business'(2 способа, подзапросы)

            /*
                        var result = from book in db.stores
                                      where (from ta in db.sales where (from a in db.titles where a.type == "business" select a.title_id).Contains(ta.title_id) select ta.stor_id).Contains(book.stor_id)
                                      select book;*/


            var result = db.stores.Where(book =>
                (db.sales.Where(ta =>
                (db.titles.Where(a => a.type == "business").Select(a => a.title_id)).Contains(ta.title_id))
                .Select(ta => ta.stor_id)).Contains(book.stor_id));

            dataGridView1.DataSource = result;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            //- для каждой книги показать количество магазинов, к которых она продаётся (2 способа)



            var result = db.titles.Where(book =>
               (db.sales.Where(ta =>
               (db.stores.Select(a => a.stor_id)).Contains(ta.stor_id))
               .Select(ta => ta.title_id)).Contains(book.title_id));

            dataGridView1.DataSource = result;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
   
            //-для каждого автора показать: среднюю цену книги, количество книг(2 способа)
          



              var result = from a in db.authors
                            join z in db.titleauthors on a.au_id equals z.au_id
                            join x in db.titles on z.title_id equals x.title_id
                            group x.price by a.au_fname into q
                            select new
                            {
                                Name = q.Key,
                                Averege = q.Average(),
                                Count_of_books = q.Count()

                            };
            dataGridView1.DataSource = result;
        }
    }
}
