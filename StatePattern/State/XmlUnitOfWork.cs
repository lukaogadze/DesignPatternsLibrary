using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using WorkItemDomain;

namespace WorkItemSimple
{
	public class XmlUnitOfWork : IUnitOfWork
	{
		private readonly string dataFileName;
		private readonly XmlRepository<IEntity> entities;

		public XmlUnitOfWork(string fileName)
		{
			dataFileName = fileName;
			entities = new XmlRepository<IEntity>();

			if (!File.Exists(fileName))
				Commit();

			foreach (var wi in ReadXml())
			{
				entities.Add(wi);
			}
		}

		#region IUnitOfWork Members

		public IRepository<IEntity> Entities
		{
			get { return entities; }
		}

		public void Commit()
		{
			using (XmlWriter writer = XmlWriter.Create(dataFileName))
			{
				writer.WriteStartDocument(true);
				writer.WriteStartElement("WorkItems");
				foreach (var y in Entities.FindAll())
				{
					var x = (WorkItem) y;
					writer.WriteStartElement("WorkItem");
					writer.WriteElementString("Id", x.Id.ToString());
					writer.WriteElementString("State", x.State);
					writer.WriteElementString("Title", x.Title);
					writer.WriteElementString("Description", x.Description);
					writer.WriteEndElement();
				}
				writer.WriteEndElement();
				writer.WriteEndDocument();
			}
		}

		#endregion

		private IEnumerable<WorkItem> ReadXml()
		{
			// ReSharper disable PossibleNullReferenceException
			return
				XDocument.Load(dataFileName)
					.Element("WorkItems")
					.Elements("WorkItem")
					.Select(r => new WorkItem
					             	{
					             		Id = int.Parse(r.Element("Id").Value),
					             		State = r.Element("State").Value,
					             		Title = r.Element("Title").Value,
					             		Description = r.Element("Description").Value
					             	});
			// ReSharper restore PossibleNullReferenceException
		}
	}
}