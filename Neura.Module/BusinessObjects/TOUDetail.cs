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
    public class TOUDetail : XPCustomObject
    {
        public TOUDetail(Session session) : base(session) { }

        int fOid;
        [Key(true)]
        [MemberDesignTimeVisibility(false)]
        public int Oid
        {
            get { return fOid; }
            set { SetPropertyValue<int>(nameof(Oid), ref fOid, value); }
        }

        private DayOfWeek _dayOfWeek;

        [RuleRequiredField(DefaultContexts.Save)]

        public DayOfWeek DayOfWeek
        {
            get { return _dayOfWeek; }
            set { SetPropertyValue("DayOfWeek", ref _dayOfWeek, value); }
        }

        //int fDayOfWeek;
        //[RuleRequiredField(DefaultContexts.Save)]
        //public int DayOfWeek
        //{
        //    get { return fDayOfWeek; }
        //    set { SetPropertyValue<int>(nameof(DayOfWeek), ref fDayOfWeek, value); }
        //}
        string fTimeStart;
        [RuleRequiredField(DefaultContexts.Save)]
        [Size(100)]
        public string TimeStart
        {
            get { return fTimeStart; }
            set { SetPropertyValue<string>(nameof(TimeStart), ref fTimeStart, value); }
        }
        string fTimeEnd;
        [RuleRequiredField(DefaultContexts.Save)]
        [Size(100)]
        public string TimeEnd
        {
            get { return fTimeEnd; }
            set { SetPropertyValue<string>(nameof(TimeEnd), ref fTimeEnd, value); }
        }
        //int fCategory;
        //public int Category
        //{
        //    get { return fCategory; }
        //    set { SetPropertyValue<int>(nameof(Category), ref fCategory, value); }
        //}
        private Category _category;
        [RuleRequiredField(DefaultContexts.Save)]
        public Category Category
        {
            get { return _category; }
            set { SetPropertyValue("Category", ref _category, value); }
        }

        TOUSeason fTouSeason;
        [Association(@"TOUDetailReferencesTOUSeason")]
        public TOUSeason TouSeason
        {
            get { return fTouSeason; }
            set { SetPropertyValue<TOUSeason>(nameof(TouSeason), ref fTouSeason, value); }
        }
    }
    public enum Category { Peak, Standard, OffPeak, All, PeakAndStandard }
    public enum DayOfWeek { Weekdays, Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday }
}
