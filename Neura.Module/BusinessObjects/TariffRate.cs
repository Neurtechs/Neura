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
    [NavigationItem("Tariffs")]
    public class TariffRate : XPCustomObject
    {
        public TariffRate(Session session) : base(session) { }

        int fOid;
        [Key(true)]
        [MemberDesignTimeVisibility(false)]
        public int Oid
        {
            get { return fOid; }
            set { SetPropertyValue<int>(nameof(Oid), ref fOid, value); }
        }
        //string fTariffRateName;
        //[Size(45)]
        //public string TariffRateName
        //{
        //    get { return fTariffRateName; }
        //    set { SetPropertyValue<string>(nameof(TariffRateName), ref fTariffRateName, value); }
        //}

        string fYear;
        [RuleRequiredField(DefaultContexts.Save)]
        [Size(15)]
        public string Year
        {
            get { return fYear; }
            set { SetPropertyValue<string>(nameof(Year), ref fYear, value); }
        }

        DateTime fStart;
        [RuleRequiredField(DefaultContexts.Save)]
        public DateTime Start
        {
            get { return fStart; }
            set { SetPropertyValue<DateTime>(nameof(Start), ref fStart, value); }
        }
        DateTime fEnd;
        [RuleRequiredField(DefaultContexts.Save)]
        public DateTime End
        {
            get { return fEnd; }
            set { SetPropertyValue<DateTime>(nameof(End), ref fEnd, value); }
        }
        double fRate;
        [RuleRequiredField(DefaultContexts.Save)]
        public double Rate
        {
            get { return fRate; }
            set { SetPropertyValue<double>(nameof(Rate), ref fRate, value); }
        }


        TariffComponent fTariffComponent;
        [Association(@"TariffRateReferencesTariffComponent")]
        public TariffComponent TariffComponent
        {
            get { return fTariffComponent; }
            set { SetPropertyValue<TariffComponent>(nameof(TariffComponent), ref fTariffComponent, value); }
        }
    }
}
