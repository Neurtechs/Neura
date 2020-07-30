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
    public class PublicHolidays : XPCustomObject
    {
        
        public PublicHolidays(Session session) : base(session) { }

        int fOid;
        [Key(true)]
        [MemberDesignTimeVisibility(false)]
        public int Oid
        {
            get { return fOid; }
            set { SetPropertyValue<int>(nameof(Oid), ref fOid, value); }
        }
        DateTime fDateHoliday;
        [RuleRequiredField(DefaultContexts.Save)]
        public DateTime DateHoliday
        {
            get { return fDateHoliday; }
            set { SetPropertyValue<DateTime>(nameof(DateHoliday), ref fDateHoliday, value); }
        }
        private DayOfWeek _dayOfWeek;
        [ColumnDefaultValue(1)]
        [RuleRequiredField(DefaultContexts.Save)]
        
        public DayOfWeek DayOfWeek
        {
            get { return _dayOfWeek; }
            set { SetPropertyValue("DayOfWeek", ref _dayOfWeek, value); }
        }
    }
    
}
