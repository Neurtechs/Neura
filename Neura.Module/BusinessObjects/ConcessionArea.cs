using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Persistent.Validation;
using DevExpress.Persistent.Base;

namespace Neura.Module.BusinessObjects
{
    [NavigationItem("Registration")]
    // [DefaultClassOptions ]
    [ImageName("BO_Address")]
    public class ConcessionArea : XPCustomObject
    {
       public ConcessionArea (Session session) : base (session) { }

        int fOid;
        [Key(true)]
        [MemberDesignTimeVisibility(false)]
        public int Oid
        {
            get { return fOid; }
            set { SetPropertyValue<int>(nameof(Oid), ref fOid, value); }
        }
        [Size(100)]
        string fConcessionAreaName;
        [RuleRequiredField(DefaultContexts.Save)]
        public string ConcessionAreaName
        {
            get { return fConcessionAreaName; }
            set { SetPropertyValue<string>(nameof(ConcessionAreaName), ref fConcessionAreaName, value); }
        }
        [Size(45)]
        string fCountry;
        [RuleRequiredField(DefaultContexts.Save)]
        public string Country
        {
            get { return fCountry; }
            set { SetPropertyValue<string>(nameof(Country), ref fCountry, value); }
        }
        [Size(100)]
        string fContact;
        [RuleRequiredField(DefaultContexts.Save)]
        public string Contact
        {
            get { return fContact; }
            set { SetPropertyValue<string>(nameof(Contact), ref fContact, value); }
        }
       
        private Status _status;
        [ColumnDefaultValue(0)]
        [RuleRequiredField(DefaultContexts.Save)]
        public Status Status
        {
            get { return _status; }
            set { SetPropertyValue("Status", ref _status, value); }
        }

        DateTime fConcessionStart;
        [RuleRequiredField(DefaultContexts.Save)]
        public DateTime ConcessionStart
        {
            get { return fConcessionStart; }
            set { SetPropertyValue<DateTime>(nameof(ConcessionStart), ref fConcessionStart, value); }
        }
        DateTime fConcessionEnd;
        [RuleRequiredField(DefaultContexts.Save)]
        public DateTime ConcessionEnd
        {
            get { return fConcessionEnd; }
            set { SetPropertyValue<DateTime>(nameof(ConcessionEnd), ref fConcessionEnd, value); }
        }
        private ConcessionType _concessiontype;
        [ColumnDefaultValue(0)]
        [RuleRequiredField(DefaultContexts.Save)]
        public ConcessionType ConcessionType
        {
            get { return _concessiontype; }
            set { SetPropertyValue("ConcessionType", ref _concessiontype, value); }
        }
        [Association(@"LocationReferencesConcessionArea")]
        public XPCollection<Location> Locations { get { return GetCollection<Location>(nameof(Locations)); } }

        [Association(@"RetailerReferencesConcessionArea")]
        public XPCollection<Retailer> Retailers { get { return GetCollection<Retailer>(nameof(Retailers)); } }
    }
    public enum ConcessionType { Municipality, Community }
    public enum Status { Active, Inactive }
}
