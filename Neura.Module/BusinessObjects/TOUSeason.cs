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
    [NavigationItem("Time-of-Use")]
    public class TOUSeason : XPCustomObject
    {
        public TOUSeason(Session session) : base(session) { }

        int fOid;
        [Key(true)]
        [MemberDesignTimeVisibility(false)]
        public int Oid
        {
            get { return fOid; }
            set { SetPropertyValue<int>(nameof(Oid), ref fOid, value); }
        }
        //int fTouSeasonName;
        //[RuleRequiredField(DefaultContexts.Save)]
        //public int TouSeasonName
        //{
        //    get { return fTouSeasonName; }
        //    set { SetPropertyValue<int>(nameof(TouSeasonName), ref fTouSeasonName, value); }
        //}
        private TouSeasonName _seasonName;
        [RuleRequiredField(DefaultContexts.Save)]
        public TouSeasonName TouSeasonName
        {
            get { return _seasonName; }
            set { SetPropertyValue("TouSeasonName", ref _seasonName, value); }
        }


        int fMonthStart;
        [RuleRequiredField(DefaultContexts.Save)]
        public int MonthStart
        {
            get { return fMonthStart; }
            set { SetPropertyValue<int>(nameof(MonthStart), ref fMonthStart, value); }
        }
        int fMonthEnd;
        [RuleRequiredField(DefaultContexts.Save)]
        public int MonthEnd
        {
            get { return fMonthEnd; }
            set { SetPropertyValue<int>(nameof(MonthEnd), ref fMonthEnd, value); }
        }
        TOULookup fTouLookup;
        [RuleRequiredField(DefaultContexts.Save)]
        [Association(@"TOUSeasonReferencesTOULookup")]
        public TOULookup TouLookup
        {
            get { return fTouLookup; }
            set { SetPropertyValue<TOULookup>(nameof(TouLookup), ref fTouLookup, value); }
        }
        [Association(@"TOUDetailReferencesTOUSeason")]
        public XPCollection<TOUDetail> TOUDetails { get { return GetCollection<TOUDetail>(nameof(TOUDetails)); } }
    }
    public enum TouSeasonName { High, Low, All }
}
