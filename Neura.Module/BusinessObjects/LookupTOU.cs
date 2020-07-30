using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Persistent.Validation;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace Neura.Module.BusinessObjects
{
    public class LookupTOU : XPCustomObject
    {
        public LookupTOU(Session session) : base(session) { }

        int fOid;
        [Key(true)]
        [MemberDesignTimeVisibility(false)]
        public int Oid
        {
            get { return fOid; }
            set { SetPropertyValue<int>(nameof(Oid), ref fOid, value); }
        }
        TOULookup fTouLookupId;
        [Association(@"LookupTOUReferencesTOULookup")]
        public TOULookup TouLookupId
        {
            get { return fTouLookupId; }
            set { SetPropertyValue<TOULookup>(nameof(TouLookupId), ref fTouLookupId, value); }
        }
        string fTime;
        public string Time
        {
            get { return fTime; }
            set { SetPropertyValue<string>(nameof(Time), ref fTime, value); }
        }
        int fCategory;
        public int Category
        {
            get { return fCategory; }
            set { SetPropertyValue<int>(nameof(Category), ref fCategory, value); }
        }
        int fSeason;
        public int Season
        {
            get { return fSeason; }
            set { SetPropertyValue<int>(nameof(Season), ref fSeason, value); }
        }
        int fDayOfWeek;
        public int DayOfWeek
        {
            get { return fDayOfWeek; }
            set { SetPropertyValue<int>(nameof(DayOfWeek), ref fDayOfWeek, value); }
        }

    }
}
