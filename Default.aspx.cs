using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["data"] == null)
        {
            Session["data"] = populateDataSet();
        }
        WebHierarchicalDataGrid1.DataSource = (DataSet)Session["data"];
        WebHierarchicalDataGrid1.DataBind();
    }

    private DataSet populateDataSet()
    {

        DataSet ds = new DataSet();
        DataTable Parent = new DataTable();
        Parent.TableName = "Parent";
        DataTable Child = new DataTable();
        Child.TableName = "Child";

        Parent.Columns.Add("ID");
        Parent.Columns.Add("Name");

        DataColumn[] col = new DataColumn[1];
        col[0] = Parent.Columns["ID"];
        Parent.PrimaryKey = col;

        DataRow row = Parent.NewRow();
        row.SetField<int>("ID", 0);
        row.SetField<string>("Name", "Alice");
        Parent.Rows.Add(row);

        row = Parent.NewRow();
        row.SetField<int>("ID", 1);
        row.SetField<String>("Name", "Bob");
        Parent.Rows.Add(row);


        Child.Columns.Add("ID");
        Child.Columns.Add("Address");
        Child.Columns.Add("Count", typeof(int));

        row = Child.NewRow();
        row.SetField<int>("ID", 0);
        row.SetField<string>("Address", "Paris");
        row.SetField<int>("Count", 5);
        Child.Rows.Add(row);

        row = Child.NewRow();
        row.SetField<int>("ID", 1);
        row.SetField<string>("Address", "Rome");
        row.SetField<int>("Count", 9);
        Child.Rows.Add(row);

        row = Child.NewRow();
        row.SetField<int>("ID", 1);
        row.SetField<string>("Address", "London");
        row.SetField<int>("Count", 2);
        Child.Rows.Add(row);

        row = Child.NewRow();
        row.SetField<int>("ID", 0);
        row.SetField<string>("Address", "LosAngeles");
        row.SetField<int>("Count", 9);
        Child.Rows.Add(row);

        ds.Tables.Add(Parent);
        ds.Tables.Add(Child);


        DataRelation relation = new DataRelation("IDRelation", Parent.Columns["ID"], Child.Columns["ID"]);
        ds.Relations.Add(relation);


        // Add the column in the parent DataTable which Sums the values from the children based on the id relation
        Parent.Columns.Add("Sum", typeof(int), "Sum(Child(IDRelation).Count)");

        return ds;
    }
    protected void WebHierarchicalDataGrid1_RowAdding(object sender, Infragistics.Web.UI.GridControls.RowAddingEventArgs e)
    {

        if (((Infragistics.Web.UI.GridControls.ContainerGrid)(sender)).Level == 0)
        {
            //parent
            DataSet parentTable = (DataSet)Session["data"];
            var row = parentTable.Tables["Parent"].NewRow();

            row["ID"] = e.Values["ID"];
            row["Name"] = e.Values["Name"];

            parentTable.Tables["Parent"].Rows.Add(row);

            WebHierarchicalDataGrid1.DataSource = parentTable;
            WebHierarchicalDataGrid1.DataBind();

            Session["data"] = parentTable;
        }
            //child
        else
        {
            DataSet childTable = (DataSet)Session["data"];
            var row = childTable.Tables["Child"].NewRow();

            row["ID"] = this.WebHierarchicalDataGrid1.Rows[this.WebHierarchicalDataGrid1.Rows.Count - 1].Items[0].Value;
            row["Address"] = e.Values["Address"];
            row["Count"] = e.Values["Count"];

            childTable.Tables["Child"].Rows.Add(row);

            WebHierarchicalDataGrid1.DataSource = childTable;
            WebHierarchicalDataGrid1.DataBind();

            Session["data"] = childTable;
        }
       

       
    }
}