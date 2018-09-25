using System;
using System.Data;

namespace AdapterDemo.Test
{
    public class StubDbAdapter : IDbDataAdapter
    {
        public DataTable[] FillSchema(DataSet dataSet, SchemaType schemaType)
        {
            throw new NotImplementedException();
        }

        public int Fill(DataSet dataSet)
        {
            var myDataTable = new DataTable();
            myDataTable.Columns.Add(new DataColumn("Id", typeof (int)));
            myDataTable.Columns.Add(new DataColumn("Name", typeof (string)));
            myDataTable.Columns.Add(new DataColumn("Description", typeof (string)));

            var myRow = myDataTable.NewRow();
            myRow[0] = 1;
            myRow[1] = "Adapter";
            myRow[2] = "Adapter Description";
            myDataTable.Rows.Add(myRow);
            dataSet.Tables.Add(myDataTable);
            dataSet.AcceptChanges();

            return 1;
        }

        public IDataParameter[] GetFillParameters()
        {
            throw new NotImplementedException();
        }

        public int Update(DataSet dataSet)
        {
            throw new NotImplementedException();
        }

        public MissingMappingAction MissingMappingAction
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public MissingSchemaAction MissingSchemaAction
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public ITableMappingCollection TableMappings
        {
            get { throw new NotImplementedException(); }
        }

        public IDbCommand SelectCommand
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public IDbCommand InsertCommand
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public IDbCommand UpdateCommand
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public IDbCommand DeleteCommand
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}