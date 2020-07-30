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
    public  class Retailer : XPCustomObject
    {
        public Retailer(Session session) : base(session) { }

        int fOid;
        [Key(true)]
        [MemberDesignTimeVisibility(false)]
        public int Oid
        {
            get { return fOid; }
            set { SetPropertyValue<int>(nameof(Oid), ref fOid, value); }
        }
        string fRetailerName;
        [Size(45)]
        [RuleRequiredField(DefaultContexts.Save)]
        public string RetailerName
        {
            get { return fRetailerName; }
            set { SetPropertyValue<string>(nameof(RetailerName), ref fRetailerName, value); }
        }
        string fType;
        [Size(45)]
       
        public string RetailerType
        {
            get { return fType; }
            set { SetPropertyValue<string>(nameof(RetailerType), ref fType, value); }
        }
        //int fService;

        //public int Service
        //{
        //    get { return fService; }
        //    set { SetPropertyValue<int>(nameof(Service), ref fService, value); }
        //}
        private Service _service;
        [ColumnDefaultValue(0)]
        [RuleRequiredField(DefaultContexts.Save)]
        public Service Service
        {
            get { return _service; }
            set { SetPropertyValue("Service", ref _service, value); }
        }

        string fContact;
        [Size(100)]
        [RuleRequiredField(DefaultContexts.Save)]
        public string Contact
        {
            get { return fContact; }
            set { SetPropertyValue<string>(nameof(Contact), ref fContact, value); }
        }
        string fWebSite;
        [Size(45)]
        public string WebSite
        {
            get { return fWebSite; }
            set { SetPropertyValue<string>(nameof(WebSite), ref fWebSite, value); }
        }
        private Status _status;
        [ColumnDefaultValue(0)]
        [RuleRequiredField(DefaultContexts.Save)]
        public Status Status
        {
            get { return _status; }
            set { SetPropertyValue("Status", ref _status, value); }
        }


        //int fStatus;
        //public int Status
        //{
        //    get { return fStatus; }
        //    set { SetPropertyValue<int>(nameof(Status), ref fStatus, value); }
        //}
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
        ConcessionArea fConcessionArea;
        [Association(@"RetailerReferencesConcessionArea")]
        public ConcessionArea ConcessionArea
        {
            get { return fConcessionArea; }
            set { SetPropertyValue<ConcessionArea>(nameof(ConcessionArea), ref fConcessionArea, value); }
        }
        [Association(@"TariffReferencesRetailer")]
        public XPCollection<Tariff> Tariffs { get { return GetCollection<Tariff>(nameof(Tariffs)); } }
    }
    public enum Service { Electricity, Water, Both }
}
