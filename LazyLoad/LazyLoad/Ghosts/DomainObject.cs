using System.Collections;
using System.Diagnostics;

namespace LazyLoad.Ghosts
{
    /// <summary>
    /// PoEAA page 206
    /// </summary>
    public abstract class DomainObject
    {
        public int Id { get; set; }
        private LoadStatus Status;

        public DomainObject(int id)
        {
            Id = id;
        }

        public bool IsGhost
        {
            get { return Status == LoadStatus.Ghost; }
        }

        public bool IsLoaded
        {
            get { return Status == LoadStatus.Loaded; }
        }

        public void MarkLoading()
        {
            Debug.Assert(IsGhost);
            Status = LoadStatus.Loading;
        }

        public void MarkLoaded()
        {
            Debug.Assert(Status == LoadStatus.Loading);
            Status = LoadStatus.Loaded;
        }

        // Template Method Pattern
        public virtual void Load()
        {
            if (!IsGhost) return;

            // ideally, persistence and mapping is done in separate classes
            // see PoEAA pages 207-214 for details as this is fairly advanced
            var dataRow = GetDataRow();
            LoadLine(dataRow);
        }

        // Template Method Pattern
        private void LoadLine(ArrayList dataRow)
        {
            if (!IsGhost) return;

            MarkLoading();
            DoLoadLine(dataRow);
            MarkLoaded();

        }

        protected abstract void DoLoadLine(ArrayList dataRow);
        protected abstract ArrayList GetDataRow();
    }
}