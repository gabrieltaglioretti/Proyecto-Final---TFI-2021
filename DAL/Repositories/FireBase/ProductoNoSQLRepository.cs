using DAL.Contrats;
using DOMAIN;
using System;
using System.Collections.Generic;
using DAL.Tools;
using SERVICIOS;
using System.Data;
using System.Data.SqlClient;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;


namespace DAL.Repositories.FireBase

{
    internal class ProductoNoSQLRepository : IRepositoryProductoNoSQL<Producto>
    {

        private static IFirebaseConfig conNoSql = ApplicationSettings.Current.connNoSql;


        public void Add(Producto producto)
        {
            IFirebaseClient client = new FireSharp.FirebaseClient(conNoSql);
            var setter = client.Set("Productos/" + producto.idProducto, producto);
        }

        public IEnumerable<Producto> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Producto productoNoSQL)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Producto> GetOne(Guid id)
        {
            throw new NotImplementedException();
        }


    }
      

    //getall
    //    var result = client.Get("StudentList/" + rollTbox.Text);

    //    Student std = result.ResultAs<Student>();
    //    nameTbox.Text = std.FullName;
    //    gradeTobx.Text = std.Grade;
    //    secTbox.Text = std.Section;
    //}

    //private void UpdateBtn_Click(object sender, EventArgs e)
    //{
    //    Student std = new Student()
    //    {
    //        FullName = nameTbox.Text,
    //        RollNo = rollTbox.Text,
    //        Grade = gradeTobx.Text,
    //        Section = secTbox.Text
    //    };
    //    var setter = client.Update("StudentList/" + rollTbox.Text, std);
    //    MessageBox.Show("data inserted successfully");
    //}

    //private void DeleteBtn_Click(object sender, EventArgs e)
    //{
    //    var result = client.Delete("StudentList/" + rollTbox.Text);
    //    MessageBox.Show("data deleted successfully");
    //}
}

