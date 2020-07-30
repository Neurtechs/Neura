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
    public class TOULookup : XPCustomObject
    {
        public TOULookup(Session session) : base(session) { }

        int fOid;
        [Key(true)]
        [MemberDesignTimeVisibility(false)]
        public int Oid
        {
            get { return fOid; }
            set { SetPropertyValue<int>(nameof(Oid), ref fOid, value); }
        }
        string fTouLookupName;
        [RuleRequiredField(DefaultContexts.Save)]
        [Size(100)]
        public string TouLookupName
        {
            get { return fTouLookupName; }
            set { SetPropertyValue<string>(nameof(TouLookupName), ref fTouLookupName, value); }
        }
        string fPublisher;
        [RuleRequiredField(DefaultContexts.Save)]
        [Size(100)]
        public string Publisher
        {
            get { return fPublisher; }
            set { SetPropertyValue<string>(nameof(Publisher), ref fPublisher, value); }
        }
        string fTariffCode;
        [Size(100)]
        public string TariffCode
        {
            get { return fTariffCode; }
            set { SetPropertyValue<string>(nameof(TariffCode), ref fTariffCode, value); }
        }
        string fTariffName;
        [Size(100)]
        public string TariffName
        {
            get { return fTariffName; }
            set { SetPropertyValue<string>(nameof(TariffName), ref fTariffName, value); }
        }
        string fTariffDescription;
        [Size(100)]
        public string TariffDescription
        {
            get { return fTariffDescription; }
            set { SetPropertyValue<string>(nameof(TariffDescription), ref fTariffDescription, value); }
        }
        [Association(@"LookupTOUReferencesTOULookup")]
        public XPCollection<LookupTOU> LookupTOUs { get { return GetCollection<LookupTOU>(nameof(LookupTOUs)); } }
        [Association(@"TariffReferencesTOULookup")]
        public XPCollection<Tariff> Tariffs { get { return GetCollection<Tariff>(nameof(Tariffs)); } }
        [Association(@"TOUSeasonReferencesTOULookup")]
        public XPCollection<TOUSeason> TOUSeasons { get { return GetCollection<TOUSeason>(nameof(TOUSeasons)); } }
    }
}
