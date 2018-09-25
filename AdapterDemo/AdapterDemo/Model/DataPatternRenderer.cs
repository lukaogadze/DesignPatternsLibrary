using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace AdapterDemo.Model
{
    public class DataPatternRendererAdapter : IDataPatternRendererAdapter
    {
        private DataRenderer _dataRenderer;

        public string ListPatterns(IEnumerable<Pattern> patterns)
        {
            var adaoter = new PatternCollectionDbAdapter(patterns);
            _dataRenderer = new DataRenderer(adaoter);


            var writer = new StringWriter();
            _dataRenderer.Render(writer);

            return writer.ToString();
        }

        internal class PatternCollectionDbAdapter : IDbDataAdapter
        {
            private readonly IEnumerable<Pattern> _patterns;

            public PatternCollectionDbAdapter(IEnumerable<Pattern> patterns)
            {
                _patterns = patterns;
            }

            public int Fill(DataSet dataSet)
            {
                var myDataTable = new DataTable();
                myDataTable.Columns.Add(new DataColumn("Id", typeof(int)));
                myDataTable.Columns.Add(new DataColumn("Name", typeof(string)));
                myDataTable.Columns.Add(new DataColumn("Description", typeof(string)));

                foreach (var pattern in _patterns)
                {
                    var myRow = myDataTable.NewRow();
                    myRow[0] = pattern.Id;
                    myRow[1] = pattern.Name;
                    myRow[2] = pattern.Description;
                    myDataTable.Rows.Add(myRow);
                }
                
                dataSet.Tables.Add(myDataTable);
                dataSet.AcceptChanges();

                return myDataTable.Rows.Count;
            }


            #region Not Implemented
            public IDbCommand SelectCommand { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
            public IDbCommand InsertCommand { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
            public IDbCommand UpdateCommand { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
            public IDbCommand DeleteCommand { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
            public MissingMappingAction MissingMappingAction { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
            public MissingSchemaAction MissingSchemaAction { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

            public ITableMappingCollection TableMappings => throw new System.NotImplementedException();



            public DataTable[] FillSchema(DataSet dataSet, SchemaType schemaType)
            {
                throw new System.NotImplementedException();
            }

            public IDataParameter[] GetFillParameters()
            {
                throw new System.NotImplementedException();
            }

            public int Update(DataSet dataSet)
            {
                throw new System.NotImplementedException();
            }
            #endregion
        }
    }
}